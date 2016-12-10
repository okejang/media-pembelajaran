using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finalScore : MonoBehaviour {

    private int idLevel;

    public Text txtNilai;
    public Text txtInfoLevel;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int nilaiFinals;
    private int benar;
    public int banyakSoal;

    // Use this for initialization
    void Start()
    {
        idLevel = PlayerPrefs.GetInt("idLevel");

        nilaiFinals = PlayerPrefs.GetInt("nilaiFinalTemp" + idLevel.ToString());
        benar = PlayerPrefs.GetInt("benarTemp" + idLevel.ToString());

        txtNilai.text = nilaiFinals.ToString();
        txtInfoLevel.text = "Jawaban yang benar " + benar.ToString() + " dari " + banyakSoal.ToString() + " soal";

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

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

    public void ulang()
    {
        Application.LoadLevel("Level " + idLevel.ToString());
    }
}
