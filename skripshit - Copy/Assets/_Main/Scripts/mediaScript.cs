using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mediaScript : MonoBehaviour {

    public Image iqraPage;
    public Sprite[] pic;

    private int idAct;

    // Use this for initialization
    void Start () {
        idAct = 0;
        iqraPage.GetComponentInChildren<Image>().sprite = pic[idAct];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
