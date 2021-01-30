using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarManager : MonoBehaviour
{
    [SerializeField]
    private float units;

    [SerializeField]
    private Image fill; 

    private float fillAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildUnits());
    }
    public IEnumerator BuildUnits() {
        for (int i=0; i <= units; i++) {
            fillAmount = i / units;
            
            //Instantiate(Quaternion.identity);
            yield return null;

        }
        SceneManager.LoadScene ("NewMainMenuScene");
    }
    // Update is called once per frame
    void Update()
    {
        UpdateBar();    
    }
    private void UpdateBar() {
        fill.fillAmount = fillAmount;
    }
}
