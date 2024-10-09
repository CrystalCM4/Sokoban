using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform pos;
    public GridObject gridPos;

    public static int minY;
    public static int maxY;
    public static int minX;
    public static int maxX;

    public bool left;
    public bool right;
    public bool up;
    public bool down;

    // Start is called before the first frame update
    void Start()
    {
        minY = 1;
        maxY = 5;
        minX = 1;
        maxX = 10;

        //print("" + (gridPos.gridPosition.x - 1) + ", " + (gridPos.gridPosition.y - 1));
        left = true;
        right = true;
        up = true;
        down = true;

        GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "player";
    }

    // Update is called once per frame
    void Update()
    {   

        if (gridPos.gridPosition.x != minX) {

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1].Equals("")){
                //left is open 
                left = true;
            }
            else left = false;
        }
        else left = false;

        if (gridPos.gridPosition.x != maxX) {
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 + 1, gridPos.gridPosition.y - 1].Equals("")){
                //right is open 
                right = true;
            }
            else right = false;
        }
        else right = false;

        if (gridPos.gridPosition.y != minY) {
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1].Equals("")){
                //up is open 
                up = true;
            }   
            else up = false;
        }
        else up = false;

        if (gridPos.gridPosition.y != maxY) {
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 + 1].Equals("")){
                //down is open 
                down = true;
            }
            else down = false;
        }
        else down = false;

        if (Input.GetKeyDown(KeyCode.W) && up) { //up
            
            //move the player in the 2d array
            GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] = "player";
            GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

            gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x, gridPos.gridPosition.y - 1);

        }   
        if (Input.GetKeyDown(KeyCode.S) && down) { //down

            //move the player in the 2d array
            GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] = "player";
            GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

            gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x, gridPos.gridPosition.y + 1);
        }    
        if (Input.GetKeyDown(KeyCode.A) && left) { //left

            //move the player in the 2d array
            GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] = "player";
            GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

            gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x - 1, gridPos.gridPosition.y);
        }   
        if (Input.GetKeyDown(KeyCode.D) && right) { //right

            //move the player in the 2d array
            GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] = "player";
            GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

            gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x + 1, gridPos.gridPosition.y);
        }    
    }
}
