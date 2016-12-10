using UnityEngine;
using System.Collections;

public class AddButtons1 : MonoBehaviour {
    [SerializeField]
    private Transform puzzleField1;

    [SerializeField]
    private Transform puzzleField2;

    [SerializeField]
    private GameObject btn1, btn2;

    void Awake() {
        for (int i = 0; i < 8; i++) {
            GameObject button = Instantiate(btn1);
            button.name = "" + i;
            button.transform.SetParent(puzzleField1, false);
            //button.transform.SetParent(puzzleField2, false);
        }
        for (int i = 0; i < 8; i++)
        {
            GameObject button = Instantiate(btn2);
            button.name = "" + i;
            button.transform.SetParent(puzzleField2, false);
            //button.transform.SetParent(puzzleField2, false);
        }
    }
}//addbutton
