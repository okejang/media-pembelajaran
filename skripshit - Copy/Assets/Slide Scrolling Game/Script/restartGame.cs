using UnityEngine;
using System.Collections;

public class restartGame : MonoBehaviour {

    public float restarTime;
    bool restartNow = false;
    float resetTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(restartNow && resetTime <= Time.time) {
            Application.LoadLevel("gameStage1");
        }
	}

    public void theRestartGame() {
        restartNow = true;
        resetTime = Time.time + restarTime;
    }

}
