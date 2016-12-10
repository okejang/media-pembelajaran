using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    [SerializeField]
    private Sprite bgImage;

    public Text timeRemainingTxt;
    public Sprite[] puzzles;

    public List<Sprite> gamePuzzle = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;
    private bool timeIsTrue = true;

    public int gameFinish = 0;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;
    private int idLevel, nilaiFinal, check;

    public float timeRemaining = 10;

    private string firstGuessPuzzle, secondGuessPuzzle;
    
	void Awake() {
        puzzles = Resources.LoadAll<Sprite>("Sprite/Jelly");
    }

    void Start() {
        idLevel = PlayerPrefs.GetInt("idLevel");
        //timeRemainingTxt = GetComponent<Text>();
        check = 0;

        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzle);
        gameGuesses = gamePuzzle.Count / 2;
        
        //if (gameFinish > 0)
        //{
        //    Reload();
        //}
    }

    void Update() {
        if (timeIsTrue)
        {
            timeRemaining -= Time.deltaTime;
            check = gameFinish;
            print(check);
            timeRemainingTxt.text = "Time Remaining : " + timeRemaining.ToString("f0");
            if (check == 100 || timeRemaining <= 0){
                timeRemainingTxt.text = "Time Up's";
                Application.LoadLevel("finalScore");
            }else if (check == 70 || timeRemaining <= 0){
                timeRemainingTxt.text = "Time Up's";
                Application.LoadLevel("finalScore");
            }else if (check == 50 || timeRemaining <= 0){
                timeRemainingTxt.text = "Time Up's";
                Application.LoadLevel("finalScore");
            }else if(timeRemaining <= 0) {
                timeRemainingTxt.text = "Time Up's";
                Application.LoadLevel("finalScore");
            }
        }
    }

    void GetButtons() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i = 0; i < objects.Length; i++) {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles() {
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i < looper; i++) {
            if (index == looper / 2){
                index = 0;
            }

            gamePuzzle.Add(puzzles[index]);

            index++;
        }
    }

    void AddListeners() {
        foreach(Button btn in btns) {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle() {
        
        if(!firstGuess) {

            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzle[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzle[firstGuessIndex];

        }else if(!secondGuess) {

            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzle[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzle[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch() {
        
        yield return new WaitForSeconds (1f);

        if(firstGuessPuzzle == secondGuessPuzzle) {

            yield return new WaitForSeconds(.5f) ;

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            //btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            //btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinised();

        }else {

            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinised() {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses) {
            Debug.Log("Game FInised");
            Debug.Log("It Took You " + countGuesses + " many Guess");

            //StartCoroutine(Reload());
            print(countCorrectGuesses);
            if(countGuesses == countCorrectGuesses || countGuesses <= 8) {
                gameFinish = 100;
            }else if(countGuesses <= 12) {
                gameFinish = 70;
            }else if(countGuesses <= 16) {
                gameFinish = 50;
            }
            print(gameFinish);
            nilaiFinal = gameFinish;
            

            if (nilaiFinal > PlayerPrefs.GetInt("nilaiFinal" + idLevel.ToString()))
            {
                PlayerPrefs.SetInt("nilaiFinal" + idLevel.ToString(), nilaiFinal);
            }

            PlayerPrefs.SetInt("nilaiFinalTemp" + idLevel.ToString(), nilaiFinal);
            
            //Application.LoadLevel("finalScore");

        }
    }

    IEnumerator Reload() {
        Start();

        yield return new WaitForSeconds(.5f);

        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++){
            //btns.Add(objects[i].GetComponent<Button>());
            //btns[i].image.sprite = bgImage;
            btns[i].interactable = true;
        }

        firstGuess = secondGuess = true;
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
