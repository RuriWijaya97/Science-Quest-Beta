using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public Button Level2, Level3;
    Button[] LevelButtons;
    int levelPassed;
    void Start() {
        //PlayerPrefs.DeleteAll();
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Level2.interactable = false;
        Level3.interactable = false;

        switch (levelPassed)
        {
            case 1 :
                Level2.interactable = true;
                break;
            case 2 :
                Level2.interactable = true;
                Level3.interactable = true;
                break;
        }
    }
        public void PlayLevel(int Level)
        {
            SceneManager.LoadScene(Level);
        }
        
}
    //Button[] LevelButtons;
    
    /* public void Awake () {
        PlayerPrefs.DeleteAll();
        int LevelPassed = PlayerPrefs.GetInt("LevelPassed", 1);
        LevelButtons = new Button[transform.childCount];

        for (int i = 0; i < LevelButtons.Length; i++) {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();
            LevelButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            if(i + 1 > LevelPassed) {
                LevelButtons[i].interactable = false;
            }

            
        }

        
    }    
    public void PlayLevel(int Level)
        {
            SceneManager.LoadScene(Level);
        }
        */

        

