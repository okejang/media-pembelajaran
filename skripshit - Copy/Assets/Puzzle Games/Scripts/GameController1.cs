using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController1 : MonoBehaviour {
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzle1 = new List<Sprite>();
    public List<Sprite> gamePuzzle2 = new List<Sprite>();

    public List<Button> btns1 = new List<Button>();
    public List<Button> btns2 = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses1, gameGuesses2;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private float nilai;

    void Awake() {
        puzzles = Resources.LoadAll<Sprite>("Sprite/Jelly");
    }

    void Start() {
        GetButtons();
        GetButtons1();
        AddListeners1();
        AddListeners2();
        AddGamePuzzles1();
        AddGamePuzzles2();
        Shuffle(gamePuzzle1);
        Shuffle(gamePuzzle2);
        gameGuesses1 = gamePuzzle1.Count / 2;
        gameGuesses2 = gamePuzzle2.Count / 2;
    }

    void GetButtons() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i = 0; i < objects.Length; i++) {
            btns1.Add(objects[i].GetComponent<Button>());
            btns1[i].image.sprite = bgImage;
        }
    }

    void GetButtons1()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton1");

        for (int i = 0; i < objects.Length; i++)
        {
            btns2.Add(objects[i].GetComponent<Button>());
            btns2[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles1() {
        int looper = btns1.Count;
        int index = 0;

        for(int i = 0; i < looper; i++) {
            if (index == looper / 2){
                index = 0;
            }

            gamePuzzle1.Add(puzzles[index]);

            index++;
        }
    }

    void AddGamePuzzles2()
    {
        int looper = btns2.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }

            gamePuzzle2.Add(puzzles[index]);

            index++;
        }
    }

    void AddListeners1() {
        foreach (Button btn in btns1)
        {
            btn.onClick.AddListener(() => PickAPuzzle1());
        }
    }

    void AddListeners2()
    {
        foreach (Button btn in btns2)
        {
            btn.onClick.AddListener(() => PickAPuzzle2());
        }
    }

    public void PickAPuzzle1() {
        
        if(!firstGuess) {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzle1[firstGuessIndex].name;
            btns1[firstGuessIndex].image.sprite = gamePuzzle1[firstGuessIndex];
        }else if(!secondGuess) {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzle1[secondGuessIndex].name;
            btns1[secondGuessIndex].image.sprite = gamePuzzle1[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    public void PickAPuzzle2()
    {

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzle2[firstGuessIndex].name;
            btns2[firstGuessIndex].image.sprite = gamePuzzle2[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzle2[secondGuessIndex].name;
            btns2[secondGuessIndex].image.sprite = gamePuzzle2[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch1());
        }
    }


    IEnumerator CheckIfThePuzzlesMatch() {
        
        yield return new WaitForSeconds (1f);

        if(firstGuessPuzzle == secondGuessPuzzle) {

            yield return new WaitForSeconds(.5f) ;

            btns1[firstGuessIndex].interactable = false;
            btns1[secondGuessIndex].interactable = false;

            //btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            //btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinised();

        }else {

            yield return new WaitForSeconds(.5f);

            btns1[firstGuessIndex].image.sprite = bgImage;
            btns1[secondGuessIndex].image.sprite = bgImage;
            
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    IEnumerator CheckIfThePuzzlesMatch1()
    {

        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {

            yield return new WaitForSeconds(.5f);

            btns2[firstGuessIndex].interactable = false;
            btns2[secondGuessIndex].interactable = false;

            //btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            //btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinised1();

        }
        else {

            yield return new WaitForSeconds(.5f);

            btns2[firstGuessIndex].image.sprite = bgImage;
            btns2[secondGuessIndex].image.sprite = bgImage;

        }

        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinised() {
        countCorrectGuesses++;
        
        if (countCorrectGuesses == gameGuesses1) {
            nilai += 25;
            Debug.Log("Game FInised");
            Debug.Log("It Took You " + countGuesses + " many Guess");
            Debug.Log("Your score " + nilai);
        }
        
    }

    void CheckIfTheGameIsFinised1()
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses2)
        {
            nilai += 25;
            Debug.Log("Game FInised");
            Debug.Log("It Took You " + countGuesses + " many Guess");
            Debug.Log("Your score " + nilai);
        }

    }

    void Shuffle(List<Sprite> list) {

        for(int i = 0; i < list.Count; i++) {

            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;

        }    

    }
}
