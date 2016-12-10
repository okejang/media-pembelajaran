using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelGame : MonoBehaviour {

    public Button btnPlay;
    public Text txtNamaLevel;

    public GameObject infoLevel;
    public Text txtInfoLevel;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public Text txtScoreLevel;

    public string[] namaLevel;
    public int banyakSoal;

    private int idLevel;
    

    // Use this for initialization
    void Start()
    {
        idLevel = 0;
        txtNamaLevel.text = namaLevel[idLevel];
        txtScoreLevel.text = "0";
        txtInfoLevel.text = "Jawaban yang benar X dari X soal";
        infoLevel.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        btnPlay.interactable = false;
    }

    public void pilihLevel(int i)
    {
        idLevel = i;
        //numeroQuestoes = perguntas.Length;
        PlayerPrefs.SetInt("idLevel", idLevel);

        txtNamaLevel.text = namaLevel[i];

        int nilaiFinal = PlayerPrefs.GetInt("nilaiFinal" + idLevel.ToString());
        int benar = PlayerPrefs.GetInt("benar" + idLevel.ToString());

        if (nilaiFinal == 100)
        {
            txtScoreLevel.text = nilaiFinal.ToString();
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (nilaiFinal >= 70)
        {
            txtScoreLevel.text = nilaiFinal.ToString();
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (nilaiFinal >= 50)
        {
            txtScoreLevel.text = nilaiFinal.ToString();
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }

        txtInfoLevel.text = "Jawaban yang benar " + benar.ToString() + " dari " + banyakSoal.ToString() + " soal";
        infoLevel.SetActive(true);
        btnPlay.interactable = true;
    }

    public void mulai()
    {
        Application.LoadLevel("Level" + idLevel.ToString());
    }

}
