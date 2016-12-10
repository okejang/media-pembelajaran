using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameLevels : MonoBehaviour {

     private int idLevel;

    // Use this for initialization
    void Start()
    {
        idLevel = 0;
    }

    public void pilihLevel(int i)
    {
        idLevel = i;
        //numeroQuestoes = perguntas.Length;
        PlayerPrefs.SetInt("idLevel", idLevel);

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
