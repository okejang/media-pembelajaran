using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManage : MonoBehaviour {

    public int level;
    public int row, col, countStep;
    public int rowBlank, colBlank;
    public int sizeRow, sizeCol;
    int countPoint = 0;
    int countImageKey = 0;
    int countComplete=0;

    public bool startControl = false;
    public bool checkComplete;
    public bool gameIsComplete;

    GameObject temp;

    public List<GameObject> imageKeyList;
    public List<GameObject> imageOfpictureList;
    public List<GameObject> checkPointList;

    GameObject[,] imageKeyMatrix;
    GameObject[,] imageOfPictureMatrix;
    GameObject[,] checkPointMatrix;

    // Use this for initialization
    void Start () {
        imageKeyMatrix = new GameObject[sizeRow, sizeCol];
        imageOfPictureMatrix = new GameObject[sizeRow, sizeCol];
        checkPointMatrix = new GameObject[sizeRow, sizeCol];

        if(level == 1) {
            ImageOfEasyLevel();
        }else if (level == 2) {
            ImageOfNormalLevel();
        }else if (level == 3) {
            ImageOfHardLevel();
        }
        
        CheckPointManager();
        ImageKeyManager();

        for (int r = 0; r < sizeRow; r++) {
            for (int c = 0; c < sizeCol; c++) {
                if(imageOfPictureMatrix[r, c].name.CompareTo("blank") == 0) {
                    rowBlank = r;
                    colBlank = c;
                    break;
                }
            }
        }
    }
	
    void CheckPointManager() {
        for (int r = 0; r < sizeRow; r++){
            for (int c = 0; c < sizeCol; c++){
                checkPointMatrix[r, c] = checkPointList[countPoint];
                countPoint++;
            }
        }
    }

    void ImageKeyManager() {
        for (int r = 0; r < sizeRow; r++){
            for (int c = 0; c < sizeCol; c++){
                imageKeyMatrix[r, c] = imageKeyList[countImageKey];
                countImageKey++;
            }
        }
    }

	// Update is called once per frame
	void Update () {
	    if(startControl) {
            startControl = false;
            if(countStep == 1) {
                if(imageOfPictureMatrix[row, col] != null && imageOfPictureMatrix[row, col].name.CompareTo("blank") != 0) {
                    if(rowBlank != row && colBlank == col) {
                        if(Mathf.Abs(row-rowBlank)==1) {
                            SortImage();
                            countStep = 0;//move, reset count step    
                        }
                        
                    }else if (rowBlank == row && colBlank != col) {
                        if(Mathf.Abs(col-colBlank)==1) {
                            SortImage();
                            countStep = 0;//move    
                        }
                        
                    }else if ((rowBlank == row && colBlank == col) || (rowBlank != row && colBlank != col)) {
                        countStep = 0;//not move
                    }
                }else {
                    countStep = 0; //not move
                }
            }
        }
	}

    void FixedUpdate() {
        if(checkComplete) {
            checkComplete = false;
            for(int r=0; r<sizeRow; r++) {
                for(int c=0; c<sizeCol; c++) {
                    if(imageKeyMatrix[r,c].gameObject.name.CompareTo(imageOfPictureMatrix[r,c].gameObject.name)==0){
                        countComplete++;
                    }else {
                        break; //out loop
                    }
                }
            }
            if(countComplete==checkPointList.Count) { //if imageOfPicture = imageKey (in 2 array) ( checkpointlist.count )
                gameIsComplete = true;
                Debug.Log("game is completed");
            }else {
                countComplete = 0;
            }
        }
    }

    void SortImage() {
        //sort
        temp = imageOfPictureMatrix[rowBlank, colBlank];
        imageOfPictureMatrix[rowBlank, colBlank] = null;
        imageOfPictureMatrix[rowBlank, colBlank] = imageOfPictureMatrix[row, col];
        imageOfPictureMatrix[row, col] = null;
        imageOfPictureMatrix[row, col] = temp;

        //set move image
        imageOfPictureMatrix[rowBlank, colBlank].GetComponent<ImageController>().target = checkPointMatrix[rowBlank, colBlank];
        imageOfPictureMatrix[row, col].GetComponent<ImageController>().target = checkPointMatrix[row, col];
        
        imageOfPictureMatrix[rowBlank, colBlank].GetComponent<ImageController>().startMove = true;
        imageOfPictureMatrix[row, col].GetComponent<ImageController>().startMove = true;

        //set row and col image
        rowBlank = row;//position touch
        colBlank = col;

    }

    void ImageOfEasyLevel() {
        imageOfPictureMatrix[0, 0] = imageOfpictureList[0];
        imageOfPictureMatrix[0, 1] = imageOfpictureList[2];
        imageOfPictureMatrix[0, 2] = imageOfpictureList[5];
        imageOfPictureMatrix[1, 0] = imageOfpictureList[4];
        imageOfPictureMatrix[1, 1] = imageOfpictureList[1];
        imageOfPictureMatrix[1, 2] = imageOfpictureList[7];
        imageOfPictureMatrix[2, 0] = imageOfpictureList[3];
        imageOfPictureMatrix[2, 1] = imageOfpictureList[6];
        imageOfPictureMatrix[2, 2] = imageOfpictureList[8];
    }

    void ImageOfNormalLevel() {
        imageOfPictureMatrix[0, 0] = imageOfpictureList[4];
        imageOfPictureMatrix[0, 1] = imageOfpictureList[0];
        imageOfPictureMatrix[0, 2] = imageOfpictureList[1];
        imageOfPictureMatrix[0, 3] = imageOfpictureList[2];
        imageOfPictureMatrix[1, 0] = imageOfpictureList[8];
        imageOfPictureMatrix[1, 1] = imageOfpictureList[6];
        imageOfPictureMatrix[1, 2] = imageOfpictureList[7];
        imageOfPictureMatrix[1, 3] = imageOfpictureList[11];
        imageOfPictureMatrix[2, 0] = imageOfpictureList[12];
        imageOfPictureMatrix[2, 1] = imageOfpictureList[5];
        imageOfPictureMatrix[2, 2] = imageOfpictureList[14];
        imageOfPictureMatrix[2, 3] = imageOfpictureList[10];
        imageOfPictureMatrix[3, 0] = imageOfpictureList[13];
        imageOfPictureMatrix[3, 1] = imageOfpictureList[9];
        imageOfPictureMatrix[3, 2] = imageOfpictureList[15];
        imageOfPictureMatrix[3, 3] = imageOfpictureList[3];
    }

    void ImageOfHardLevel() {
        imageOfPictureMatrix[0, 0] = imageOfpictureList[5];
        imageOfPictureMatrix[0, 1] = imageOfpictureList[2];
        imageOfPictureMatrix[0, 2] = imageOfpictureList[3];
        imageOfPictureMatrix[0, 3] = imageOfpictureList[4];
        imageOfPictureMatrix[0, 4] = imageOfpictureList[9];
        imageOfPictureMatrix[1, 0] = imageOfpictureList[10];
        imageOfPictureMatrix[1, 1] = imageOfpictureList[1];
        imageOfPictureMatrix[1, 2] = imageOfpictureList[12];
        imageOfPictureMatrix[1, 3] = imageOfpictureList[7];
        imageOfPictureMatrix[1, 4] = imageOfpictureList[8];
        imageOfPictureMatrix[2, 0] = imageOfpictureList[15];
        imageOfPictureMatrix[2, 1] = imageOfpictureList[6];
        imageOfPictureMatrix[2, 2] = imageOfpictureList[13];
        imageOfPictureMatrix[2, 3] = imageOfpictureList[14];
        imageOfPictureMatrix[2, 4] = imageOfpictureList[19];
        imageOfPictureMatrix[3, 0] = imageOfpictureList[20];
        imageOfPictureMatrix[3, 1] = imageOfpictureList[11];
        imageOfPictureMatrix[3, 2] = imageOfpictureList[22];
        imageOfPictureMatrix[3, 3] = imageOfpictureList[17];
        imageOfPictureMatrix[3, 4] = imageOfpictureList[18];
        imageOfPictureMatrix[4, 0] = imageOfpictureList[21];
        imageOfPictureMatrix[4, 1] = imageOfpictureList[16];
        imageOfPictureMatrix[4, 2] = imageOfpictureList[23];
        imageOfPictureMatrix[4, 3] = imageOfpictureList[24];
        imageOfPictureMatrix[4, 4] = imageOfpictureList[0];
    }

}
