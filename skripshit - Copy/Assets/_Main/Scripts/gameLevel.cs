using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameLevel : MonoBehaviour {

    public Button btnPlay;
    public Text txtNamaLevel;

    public GameObject infoLevel;
    //public Text txtInfoLevel;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public string[] namaLevel;
    public int banyakSoal;

    private int idLevel;



    // Use this for initialization
    void Start()
    {
        idLevel = 0;
        txtNamaLevel.text = namaLevel[idLevel];
        //txtInfoLevel.text = "Jawaban yang benar X dari X soal";
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
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (nilaiFinal >= 70)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (nilaiFinal >= 50)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }

        //txtInfoLevel.text = "Jawaban yang benar " + benar.ToString() + " dari " + banyakSoal.ToString() + " soal";
        infoLevel.SetActive(true);
        btnPlay.interactable = true;
    }

    public void mulai()
    {
        Application.LoadLevel("Level" + idLevel.ToString());
    }

    public void mulaiSlideScroll()
    {
        Application.LoadLevel("LevelSlide" + idLevel.ToString());
    }

    public void mulaiQuis1()
    {
        Application.LoadLevel("LevelQuiz1" + idLevel.ToString());
    }

    public void mulaiQuiz2()
    {
        Application.LoadLevel("LevelQuiz2" + idLevel.ToString());
    }

    public void mulaiQuiz3()
    {
        Application.LoadLevel("LevelQuiz3" + idLevel.ToString());
    }

    public void mulaiPuzzle()
    {
        Application.LoadLevel("LevelPuzzle" + idLevel.ToString());
    }
}
