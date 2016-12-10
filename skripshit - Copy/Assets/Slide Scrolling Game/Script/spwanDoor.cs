using UnityEngine;
using System.Collections;

public class spwanDoor : MonoBehaviour {

    bool activated = false;
    public Transform whereSpawnDoor;
    public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !activated) {
            activated = true;
            Instantiate(door, whereSpawnDoor.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
