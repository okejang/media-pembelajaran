using UnityEngine;
using System.Collections;

public class clearner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            playerHealth ph = other.GetComponent<playerHealth>();
            ph.makeDead();
        }else {
            Destroy(other.gameObject);
        }
    }

}
