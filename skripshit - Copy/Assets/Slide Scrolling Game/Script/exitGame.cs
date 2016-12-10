using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey("escape")) {
            Application.Quit();
        }
	}

    public void closeGame() {
        Application.Quit();
    }

}
