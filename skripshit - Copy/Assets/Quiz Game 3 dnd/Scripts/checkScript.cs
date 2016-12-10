using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class checkScript : MonoBehaviour, IHasChanged {

    public Transform slots;
    public Text timeRemainingTxt;
    //public Text remainingInt;

    float timeRemaining = 10;
    public int nilais;

    private int check;
    private int idLevel;
    private bool timeIsTrue = true;

    void Start()
    {
        idLevel = PlayerPrefs.GetInt("idLevel");
        //HasChanged();
        timeRemainingTxt = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if(timeIsTrue) {
            timeRemaining -= Time.deltaTime;
            check = PlayerPrefs.GetInt("nilaiFinalTemp" + idLevel.ToString());
            print(check);
            timeRemainingTxt.text = "Time Remaining : " + timeRemaining.ToString("f0");
            if (check == 100 || timeRemaining <= 0)
            {
                timeRemainingTxt.text = "Time Up's";
                Application.LoadLevel("finalScore");
            }
        }
    }

    public void HasChanged(){               
        foreach (Transform slotTransform in slots){
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {               
                nilais += 25;
            }
        }

        int nilai = nilais/4;
        print(nilai);
        if (nilai > PlayerPrefs.GetInt("nilaiFinal" + idLevel.ToString()))
        {
            PlayerPrefs.SetInt("nilaiFinal" + idLevel.ToString(), nilai);                
        }
        PlayerPrefs.SetInt("nilaiFinalTemp" + idLevel.ToString(), nilai);
                        
    }
    
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}