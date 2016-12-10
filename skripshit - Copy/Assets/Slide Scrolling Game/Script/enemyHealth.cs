using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;

    public GameObject enemyDeathFX;
    public Slider enemyBar;
    public AudioClip enemyDeath;

    public bool drops;
    public GameObject theDrop;

    //AudioSource enemyAS;

    float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
        enemyBar.maxValue = currentHealth;
        enemyBar.value = currentHealth;

        //enemyAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addDamage(float damage) {
        enemyBar.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyBar.value = currentHealth;
        //enemyAS.PlayOneShot(enemyDeath);

        if (currentHealth <= 0) {
            //enemyAS.PlayOneShot(enemyDeath);
            makeDead();
            
        }
    }

    void makeDead() {
        //enemyAS.PlayOneShot(enemyDeath);
        Destroy(gameObject.transform.parent.gameObject);
        AudioSource.PlayClipAtPoint(enemyDeath, transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if(drops) {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }

}
