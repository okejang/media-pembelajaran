using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    private bool loadScene = false;

    public float loadingTime;
    public Image loadingBar;
    //public Text percent;

    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private Text text1;
    [SerializeField]
    private Text text2;

    void Start(){
        loadingBar.fillAmount = 0;
    }

    // Updates once per frame
    void Update() {

        if (loadingBar.fillAmount <= 1){
            loadingBar.fillAmount += 1.0f / loadingTime * Time.deltaTime;
        }
        text1.text = (loadingBar.fillAmount * 100).ToString("f0");

        if (loadScene == false) {
            loadScene = true;
            loadingText.text = "Loading...";
            StartCoroutine(LoadNewScene());

        }
        if (loadScene == true) {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
            text1.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
            text2.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }

	}
    
    IEnumerator LoadNewScene() {
        yield return new WaitForSeconds(6);
        AsyncOperation async = Application.LoadLevelAsync(scene);

        while (!async.isDone) {
            yield return null;
        }

    }

}
