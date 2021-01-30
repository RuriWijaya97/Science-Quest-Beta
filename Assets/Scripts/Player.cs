using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour {
	public static Player instance = null;
	
	int sceneIndex, levelPassed;

	public float speedX;
	public float jumpSpeedY;
	public float delayBeforeDoubleJump;

	bool facingRight,Jumping, isGrounded, canDoubleJump;
	float speed;

	public int ourHealth;
	public int maxHealth;
	public int energy;
	public int scoring;

	Animator anim;
	Rigidbody2D rb;

	public GameObject playerLose, panelLose, portal, panelQuiz, panelWin;


	private AudioSource audioSource;
	public AudioClip JumpSound;
	public AudioClip Coin;
	public AudioClip Energy;
	public AudioClip Life;
	public AudioClip EnemyGone;
	//public AudioClip Win;

	
	public Text score;
	public Text scoreWin;
	public Text poin;
	public Text scoreGame;
	
	
	public RectTransform popUp;


	// Use this for initialization
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
		facingRight = true;

		ourHealth = maxHealth;
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		//score.text = PlayerPrefs.GetInt ("Score").ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		MovePlayer(speed);
		//left
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			speed = -speedX;
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			speed = 0;
		}
		//right
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			speed = speedX;
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			speed = 0;
		}
		//jump
		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
			Jump();
			audioSource.PlayOneShot(JumpSound);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && canDoubleJump) {
			Jump();
			audioSource.PlayOneShot(JumpSound);
			
		}
		Flip();

		if(ourHealth > maxHealth) {
			ourHealth = maxHealth;
		}
		if(ourHealth <= 0) {
			Die();
		}
		if(energy == 5) {
			Portal();
		}
		
	}

	void Portal () {
		portal.SetActive(true);
	}
	void Die () 
	{
		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		panelLose.SetActive (true);
		playerLose.SetActive(false);
		score.text = PlayerPrefs.GetInt ("Score").ToString();

	}
	
	//Buat Player bergerak
	void MovePlayer(float playerSpeed) {

		if(playerSpeed < 0  && !Jumping || playerSpeed > 0 && !Jumping) {
			anim.SetInteger("State", 1);
		}
		if(playerSpeed == 0 && !Jumping)
        {
            anim.SetInteger("State", 0);
        }

        rb.velocity = new Vector3 (speed, rb.velocity.y, 0);
	}

	void Flip() {
		if(speed > 0 && !facingRight || speed < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 temp = transform.localScale;
			temp.x *= -1;	
			transform.localScale = temp;
		}
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "GROUND") 
        {
			canDoubleJump = false;
			isGrounded = true;
            Jumping = false;
			anim.SetInteger ("State", 0);
			
        }
		if(other.gameObject.tag == "Enemy") {
			ourHealth --;
		}

	
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Koin") {
			scoring++;
			scoreGame.text = "X" + scoring + " ";
			Destroy (coll.gameObject);
			audioSource.PlayOneShot(Coin);
			PlayerPrefs.SetInt("Score", scoring);
			PlayerPrefs.SetInt("Score1", scoring);
			//audioSource.clip = Coin;
			//audioSource.Play (); 
		} 
		if (coll.tag == "Energy") {
			energy++;
            poin.text = "X" + energy + " ";
			Destroy (coll.gameObject);
			
			audioSource.PlayOneShot(Energy);
			//audioSource.clip = Coin;
			//audioSource.Play (); 
		} 
		

		if(coll.gameObject.tag == "Vortex") 
        {
			panelQuiz.SetActive(true);
			
			//PlayerPrefs.SetInt("LevelPassed",sceneIndex);
			//SceneManager.LoadScene (sceneIndex + 1);
        }
	
		if (coll.tag == "DeadZone") {
			Die();
			ourHealth = 0;
        }
		if(coll.gameObject.tag == "Enemy") {
			Destroy(coll.gameObject);
			//audioSource.PlayOneShot(EnemyGone);
			
		}
		if(coll.gameObject.tag == "Heart") {
			ourHealth ++;
			Destroy (coll.gameObject);
			audioSource.PlayOneShot(Life);
		}
	}
	public void betul () {
		panelWin.SetActive(true);
		panelQuiz.SetActive(false);
		scoreWin.text = PlayerPrefs.GetInt("Score1").ToString();
	}
	public void salah () {
		ourHealth--;
		if(ourHealth == 0) {
			panelLose.SetActive(true);
			panelQuiz.SetActive(false);
		}
	}

	public void WalkLeft() {
		speed = -speedX;
	}

	public void WalkRight() {
		speed = speedX;
	}
	public void StopMoving() {
		speed = 0;
	}
	public void Jump() {
		//single jump
		if (isGrounded)	{
			Jumping = true;
			isGrounded = false;
			rb.AddForce (new Vector2 (rb.velocity.x, jumpSpeedY));
			anim.SetInteger ("State", 2);
			Invoke("EnableDoubleJump", delayBeforeDoubleJump);
			audioSource.PlayOneShot(JumpSound);
		}

		//double jump
		if (canDoubleJump) {
			canDoubleJump = false;
			rb.AddForce (new Vector2 (rb.velocity.x, jumpSpeedY));
			anim.SetInteger ("State", 2);
			audioSource.PlayOneShot(JumpSound);
		}
	}
	void EnableDoubleJump() {
		canDoubleJump = true;
	}
	public void RestartGameLose() {
		panelLose.SetActive(false);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		playerLose.SetActive(true);
		PlayerPrefs.DeleteKey("Score");
	}

	public void RestartGameWin() {
		panelWin.SetActive(false);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		playerLose.SetActive(true);
		PlayerPrefs.DeleteKey("Score1");
	}
	public void NextLevel () {
		PlayerPrefs.SetInt("LevelPassed",sceneIndex);
		SceneManager.LoadScene (sceneIndex + 1);
		PlayerPrefs.DeleteKey("Score1");
	}
}
