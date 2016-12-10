using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerHurt;
    public AudioClip playerDeath;

    float currentHealth;

    playerController controlMovement;

    AudioSource playerAS;

    //HUD variable
    public Slider sliderHealth;
    public Image damageScreen;
    public Text gameOverTxt;
    public Text gameWinTxt;
    public restartGame gameOverManage;

    bool damaged = false;
    Color damageColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;

	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;

        controlMovement = GetComponent<playerController>();

        //HUD initialization
        sliderHealth.maxValue = fullHealth;
        sliderHealth.value = fullHealth;

        damaged = false;

        playerAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(damaged) {
            damageScreen.color = damageColor;
        }else {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
	}

    public void addDamage(float damage) {
        if (damage <= 0) return;
        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();
        //playerAS.PlayOneShot(playerHurt);

        sliderHealth.value = currentHealth;
        damaged = true;

        if(currentHealth<=0) {
            makeDead();
        }
    }

    public void addHealth(float healthAmount) {
        currentHealth += healthAmount;
        if(currentHealth > fullHealth) {
            currentHealth = fullHealth;
        }
        sliderHealth.value = currentHealth;
    }

    public void makeDead() {
        AudioSource.PlayClipAtPoint(playerDeath, transform.position);
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        damageScreen.color = damageColor;
        Animator gameOverAnim = gameOverTxt.GetComponent<Animator>();
        gameOverAnim.SetTrigger("gameOver");
        gameOverManage.theRestartGame();
    }

    public void winGame() {
        Destroy(gameObject);
        gameOverManage.theRestartGame();
        Animator winAnim = gameWinTxt.GetComponent<Animator>();
        winAnim.SetTrigger("gameOver");
    }

}
