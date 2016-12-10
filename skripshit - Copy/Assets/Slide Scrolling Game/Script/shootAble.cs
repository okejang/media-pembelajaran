using UnityEngine;
using System.Collections;

public class shootAble : MonoBehaviour {

    public GameObject spore;
    public float shootTime;
    public int chanceShoot;
    public Transform shootFrom;

    float nextShoot;
    Animator canonAnim;

	// Use this for initialization
	void Start () {
        canonAnim = GetComponentInChildren<Animator>();
        nextShoot = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && nextShoot < Time.time) {
            nextShoot = Time.time + shootTime;
            if(Random.Range(0, 10) >= chanceShoot) {
                Instantiate(spore, shootFrom.position, Quaternion.identity);
                canonAnim.SetTrigger("canonShoot");
            }
        }
    }

}
