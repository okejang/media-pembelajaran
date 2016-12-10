using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class questionBegin : MonoBehaviour {

    private int idLevel;

    public Text aksi;
    public Image soalGambar;
    public Text jawabanA;
    public Text jawabanB;
    public Text infoJawaban;

    public string[] acts;
    public Sprite[] pic;
    public string[] alternativeA;
    public string[] alternativeB;
    public string[] jawabanBenar;

    private int idAct;

    private float benar;
    private float soal;
    private float media;
    private int nilaiFinal;

    // Use this for initialization
    void Start()
    {
        idLevel = PlayerPrefs.GetInt("idLevel");
        idAct = 0;
        soal = acts.Length;

        aksi.text = acts[idAct];
        soalGambar.GetComponentInChildren<Image>().sprite = pic[idAct];
        jawabanA.text = alternativeA[idAct];
        jawabanB.text = alternativeB[idAct];

        infoJawaban.text = "Menjawab " + (idAct + 1).ToString() + " dari " + soal.ToString() + " soal";

    }

    public void jawaban(string alternativa)
    {
        if (alternativa == "A")
        {
            if (alternativeA[idAct] == jawabanBenar[idAct])
            {
                benar += 1;
            }
        }
        else if (alternativa == "B")
        {
            if (alternativeB[idAct] == jawabanBenar[idAct])
            {
                benar += 1;
            }
        }

        nextSoal();
    }

    void nextSoal()
    {
        idAct += 1;

        if (idAct <= (soal - 1))
        {
            aksi.text = acts[idAct];
            soalGambar.GetComponentInChildren<Image>().sprite = pic[idAct];
            jawabanA.text = alternativeA[idAct];
            jawabanB.text = alternativeB[idAct];
            
            infoJawaban.text = "Menjawab " + (idAct + 1).ToString() + " dari " + soal.ToString() + " soal";
        }
        else {
            media = 100 * (benar / soal);
            nilaiFinal = Mathf.RoundToInt(media);

            if (nilaiFinal > PlayerPrefs.GetInt("nilaiFinal" + idLevel.ToString()))
            {
                PlayerPrefs.SetInt("nilaiFinal" + idLevel.ToString(), nilaiFinal);
                PlayerPrefs.SetInt("benar" + idLevel.ToString(), (int)benar);
            }

            PlayerPrefs.SetInt("nilaiFinalTemp" + idLevel.ToString(), nilaiFinal);
            PlayerPrefs.SetInt("benarTemp" + idLevel.ToString(), (int)benar);

            Application.LoadLevel("finalScore");
        }


    }
}
