using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class question : MonoBehaviour {

    private int idLevel;

    public Text aksi;
    public AudioSource quest;
    public Text jawabanA;
    public Image ansA;
    public Text jawabanB;
    public Image ansB;
    public Text jawabanC;
    public Image ansC;
    public Text jawabanD;
    public Image ansD;
    public Text infoJawaban;

    public string[] acts;
    public AudioClip[] quesAudio;
    public string[] alternativeA;
    public Sprite[] alterA;
    public string[] alternativeB;
    public Sprite[] alterB;
    public string[] alternativeC;
    public Sprite[] alterC;
    public string[] alternativeD;
    public Sprite[] alterD;
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
        quest = GetComponent<AudioSource>();

        aksi.text = acts[idAct];
        quest.clip = quesAudio[idAct];
        quest.PlayDelayed(1f);
        //AudioSource.PlayClipAtPoint(quest, transform.position);
        jawabanA.text = alternativeA[idAct];
        ansA.GetComponentInChildren<Image>().sprite = alterA[idAct];
        jawabanB.text = alternativeB[idAct];
        ansB.GetComponentInChildren<Image>().sprite = alterB[idAct];
        jawabanC.text = alternativeC[idAct];
        ansC.GetComponentInChildren<Image>().sprite = alterC[idAct];
        jawabanD.text = alternativeD[idAct];
        ansD.GetComponentInChildren<Image>().sprite = alterD[idAct];

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
        else if (alternativa == "C")
        {
            if (alternativeC[idAct] == jawabanBenar[idAct])
            {
                benar += 1;
            }
        }
        else if (alternativa == "D")
        {
            if (alternativeD[idAct] == jawabanBenar[idAct])
            {
                benar += 1;
            }
        }

        nextSoal();
    }

    public void reload() {
        quest.clip = quesAudio[idAct];
        quest.PlayDelayed(1f);
    }

    void nextSoal()
    {
        idAct += 1;

        if (idAct <= (soal - 1))
        {
            aksi.text = acts[idAct];
            quest.clip = quesAudio[idAct];
            quest.PlayDelayed(1f);
            //AudioSource.PlayClipAtPoint(quest, transform.position);
            jawabanA.text = alternativeA[idAct];
            ansA.GetComponentInChildren<Image>().sprite = alterA[idAct];
            jawabanB.text = alternativeB[idAct];
            ansB.GetComponentInChildren<Image>().sprite = alterB[idAct];
            jawabanC.text = alternativeC[idAct];
            ansC.GetComponentInChildren<Image>().sprite = alterC[idAct];
            jawabanD.text = alternativeD[idAct];
            ansD.GetComponentInChildren<Image>().sprite = alterD[idAct];

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
