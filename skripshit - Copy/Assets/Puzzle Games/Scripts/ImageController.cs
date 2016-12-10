﻿using UnityEngine;
using System.Collections;

public class ImageController : MonoBehaviour {

    public GameObject target;
    public bool startMove = false;
    GameManage gameMN;

	// Use this for initialization
	void Start () {
        GameObject gameManager = GameObject.Find("GameController");
        gameMN = gameManager.GetComponent<GameManage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (startMove) {
            startMove = false;
            this.transform.position = target.transform.position;//move to new position
            gameMN.checkComplete = true;
        }
    }
}
