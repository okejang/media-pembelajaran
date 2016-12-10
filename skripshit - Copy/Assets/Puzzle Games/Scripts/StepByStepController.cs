using UnityEngine;
using System.Collections;

public class StepByStepController : MonoBehaviour {

    public int row, col;
    GameManage gameMN;

    // Use this for initialization
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameController");
        gameMN = gameManager.GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Row " + row + " and Coloum " + col);
        gameMN.countStep += 1;
        gameMN.row = row;
        gameMN.col = col;
        gameMN.startControl = true;
    }

}
