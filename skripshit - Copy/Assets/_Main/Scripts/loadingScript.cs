using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loadingScript : MonoBehaviour {

    public float loadingTime;
    public Image loadingBar;
    public Text percent;

	// Use this for initialization
	void Start () {
        loadingBar.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(loadingBar.fillAmount <= 1) {
            loadingBar.fillAmount += 1.0f / loadingTime * Time.deltaTime;
        }
        if(loadingBar.fillAmount == 1.0f) {
            Application.LoadLevel(1);
        }
        percent.text = (loadingBar.fillAmount * 100).ToString("f0");
	}
}
