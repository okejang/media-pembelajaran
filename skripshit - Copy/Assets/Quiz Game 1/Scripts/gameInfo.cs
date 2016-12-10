using UnityEngine;
using System.Collections;

public class gameInfo : MonoBehaviour {

    public int idLevel;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int nilaiFinal;
    private int nilaiFinals;

    // Use this for initialization
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        nilaiFinals = PlayerPrefs.GetInt("nilaiFinal" + idLevel.ToString());

        if (nilaiFinals == 100)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (nilaiFinals >= 70)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (nilaiFinals >= 50)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

}
