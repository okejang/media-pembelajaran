using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour {

	public float loadingTime;
	public Image loadingBar;
	public Text percent;
	public AudioSource musik;
	public GameObject objekMain;
	public GameObject objekSetting;
	public GameObject objekCategory;

	// Use this for initialization
	void Start () {

		loadingBar.fillAmount = 0;
		objekMain.SetActive (false);
		objekSetting.SetActive (false);
		objekCategory.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (loadingBar.fillAmount <= 1) {
			loadingBar.fillAmount += 1.0f / loadingTime * Time.deltaTime;
		}
		percent.text = "Persiapan " + (loadingBar.fillAmount * 100).ToString ("f0") + " %";
		if (loadingBar.fillAmount == 1.0f) {
			//aksi
			percent.text = "Yuk Belajar . . . ";
			Destroy(gameObject);
			musik.Play ();
			musik.volume = 1f;
			objekMain.SetActive (true);
		}

	}
}
