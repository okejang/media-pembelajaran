using UnityEngine;
using System.Collections;

public class rocketHit : MonoBehaviour {

    public float weaponDamage;

    projectileControler myPC;

    public GameObject explotionEffect;

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<projectileControler>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("ShootAble")) {
            myPC.removeForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy") {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
            myPC.removeForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy") {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

}
