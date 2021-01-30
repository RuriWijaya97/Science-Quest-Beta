using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public GameObject LevelPanel, chapterPanel, menuPanel, csPanel, panelExit;
    int sceneIndex;
    public RectTransform mainMenu,helpMenu, settingMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 1f);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            panelExit.SetActive(true);
        }
    }
    //Go To Chapter Select
    public void ChapterMenuSelect() {
       chapterPanel.SetActive(true);
       //menuPanel.SetActive(false);
       csPanel.SetActive(false);
    }
    //Go To Level Select
    public void LevelMenuSelect() {
       //SceneManager.LoadScene("LevelSelectScene");
       LevelPanel.SetActive(true);
       chapterPanel.SetActive(false);
    }
    public void closeLevel() {
        LevelPanel.SetActive(false);
        chapterPanel.SetActive(true);
    }
    public void closeChapter() {
       chapterPanel.SetActive(false);
       menuPanel.SetActive(true);
    }
    public void playCs() {
        csPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void closeCs() {
        csPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void BackMenuHelp() {
        //SceneManager.LoadScene (sceneIndex - 1);
        helpMenu.DOAnchorPos(new Vector2(-937, 0),1f);
        mainMenu.DOAnchorPos(new Vector2(0, 0),1f);
        settingMenu.DOAnchorPos(new Vector2(937, 0),1f);
    }
   
    public void helpSelect() {
        helpMenu.DOAnchorPos(new Vector2(0, 0),1f);
        mainMenu.DOAnchorPos(new Vector2(937, 0),1f);
        settingMenu.DOAnchorPos(new Vector2(1874, 0), 1f);
    }
    public void settingSelect() {
        helpMenu.DOAnchorPos(new Vector2(-1874, 0),1f);
        mainMenu.DOAnchorPos(new Vector2(-937, 0),1f);
        settingMenu.DOAnchorPos(new Vector2(0, 0), 1f);
    }
    public void CloseChapterSelect() {
        mainMenu.DOAnchorPos(new Vector2(0, 0),1f);
        
    }
    
    public void exitPanel () {
        panelExit.SetActive(true);
    }
    public void cancel() {
        panelExit.SetActive(false);
    }


    public void exit() {
        Debug.Log("Exit This Game");
        Application.Quit();
    }
}
