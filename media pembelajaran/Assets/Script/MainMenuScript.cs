using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
	public GameObject objekSetting;
	public GameObject objekMenu;
	public GameObject objekCategory;
	public AudioSource musik;
	public Toggle toggleMute;
	public Slider sliderMusic;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){

		objekCategory.SetActive (true);
		objekMenu.SetActive (false);

	}

	public void SettingGame(){

		objekSetting.SetActive (true);
		objekMenu.SetActive (false);

	}

	public void QuitGame(){

		Application.Quit ();

	}

	public void BackMenuGame(){

		objekCategory.SetActive (false);
		objekSetting.SetActive (false);
		objekMenu.SetActive (true);

	}

	public void setSound(float vol){
		
		if (toggleMute.isOn == false) {
			musik.volume = vol;
		}

	}

	public void setMute(){

		if (toggleMute.isOn == true) {
			musik.volume = 0f;
		}else {
			musik.volume = sliderMusic.value;
		}

	}

}
