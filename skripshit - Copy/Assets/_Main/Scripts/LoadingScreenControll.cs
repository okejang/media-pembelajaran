using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreenControll : MonoBehaviour {

    AsyncOperation ao;
    public GameObject loadingScreenBG;
    public Slider progressBar;
    public Text loadingText;
    public Text text1;
    public Text text2;

    public bool fakeLoadingBar = false;
    public float fakeIncrement = 0f;
    public float fakeTiming = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel() {
        loadingScreenBG.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        loadingText.text = "Loading ... ";

        if(!fakeLoadingBar) {
            StartCoroutine(LoadLevelWithRealProgress());
        }else {
            StartCoroutine(LoadLevelWithFakeProgress());
        }
    }

    IEnumerator LoadLevelWithRealProgress() {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync(1);
        ao.allowSceneActivation = false;

        while(!ao.isDone) {
            progressBar.value = ao.progress;

            if(ao.progress == 0.9f) {
                loadingText.text = "touch the screen";
                if(Input.GetKeyDown(KeyCode.F)) {
                    ao.allowSceneActivation = true;
                }
            }

            Debug.Log(ao.progress);
            yield return null;
        }
    }

    IEnumerator LoadLevelWithFakeProgress() {
        yield return new WaitForSeconds(1);

        while (progressBar.value != 1f) {
            progressBar.value += fakeIncrement;
            yield return new WaitForSeconds(fakeTiming);
        }

        while(progressBar.value == 1f) {
            loadingText.text = "touch the screen";

            if(Input.GetKeyDown(KeyCode.F)) {
                SceneManager.LoadScene(1);
            }
            yield return null;
        }
    }

}
