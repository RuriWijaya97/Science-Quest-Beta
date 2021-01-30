using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight) {
            transform.Translate (2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (2,2);
        } else {
            transform.Translate (-2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (-2,2);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Turn")) {
            if (MoveRight) {
                MoveRight = false;
            } else {
                MoveRight = true;
            }
        }
    }
}
