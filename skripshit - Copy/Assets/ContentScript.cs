using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class item {

    public string name;
    public string score;
    public Sprite image;
    public bool isChampion;

}

public class ContentScript : MonoBehaviour {

    public GameObject sampleButton;
    public Transform contentPanel;
    public List<item> itemList;

	// Use this for initialization
	void Start () {
        popolateList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void popolateList() {
        foreach(var item in itemList) {
            GameObject newButton = Instantiate(sampleButton) as GameObject;
            archieveImageScript buttonScript = newButton.GetComponent<archieveImageScript>();
            buttonScript.nameLabel.text = item.name;
            buttonScript.scoreLabel.text = item.score;
            buttonScript.image.sprite = item.image;
            buttonScript.starImage.SetActive(item.isChampion);

            newButton.transform.SetParent(contentPanel);
        }
    }

}
