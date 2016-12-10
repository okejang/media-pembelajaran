using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

    public GameObject panelExit, panelSetting, panelPause, panelArchieve, panelHelp;

    void Update(){
        if (Input.GetKey("escape")){
            //Application.Quit();
            panelExit.gameObject.SetActive(true);
        }
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }	

    public void quitGame(int exit) {
        Debug.Log("Game is exiting....!");
        //panelSetting.gameObject.SetActive(true);
        if(exit == 2) {
            Application.Quit();
        }else if (exit == 1) {
            panelExit.gameObject.SetActive(true);
        }
        else if (exit == 0) {
            panelExit.gameObject.SetActive(false);
        }           

    }

    public void resetGame(){
        PlayerPrefs.DeleteAll();
    }

    public void menuSetting(int exit) {
        if (exit == 1){
            panelSetting.gameObject.SetActive(true);
        }
        else if (exit == 0){
            panelSetting.gameObject.SetActive(false);
            
        }
    }

    public void menuArchieve(int exit)
    {
        if (exit == 2)
        {
            panelArchieve.gameObject.SetActive(true);
        }
        else if (exit == 1)
        {
            panelHelp.gameObject.SetActive(true);
            
        }
        else if (exit == 0)
        {
            panelArchieve.gameObject.SetActive(false);
            panelHelp.gameObject.SetActive(false);
        }
    }

}
