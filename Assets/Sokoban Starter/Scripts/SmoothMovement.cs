using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public GridObject gridPos;

    public bool left;
    public bool right;
    public bool up;
    public bool down;

    // Start is called before the first frame update
    void Start()
    {
        GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "smooth";
    }

    // Update is called once per frame
    void Update()
    {
        print("left: " + left + ", right: " + right + ", up: " + up + ", down: " + down);

        if (gridPos.gridPosition.x != PlayerMovement.minX) {
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1].Equals("")){
                //left is open 
                left = true;
            }
            else left = false;
        }
        else left = false;

        if (gridPos.gridPosition.x != PlayerMovement.maxX) {
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 + 1, gridPos.gridPosition.y - 1].Equals("")){
                //right is open 
                right = true;
            }
            else right = false;
        }
        else right = false;

        if (gridPos.gridPosition.y != PlayerMovement.minY) {
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1].Equals("")){
                //up is open 
                up = true;
            }   
            else up = false;
        }
        else up = false;

        if (gridPos.gridPosition.y != PlayerMovement.maxY) {
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 + 1].Equals("")){
                //down is open 
                down = true;
            }
            else down = false;
        }
        else down = false;

        if (Input.GetKeyDown(KeyCode.W) && up && !down) { //up
            
            //MAKE IT SO THAT IT DOESNT CHECK THE THING WHEN DOWN IS FALSE
            //maybe if (down) {}
            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 + 1].Equals("player")){;

                //move the object in the 2d array
                GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] = "smooth";
                GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

                gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x, gridPos.gridPosition.y - 1);
            }
        }   
        if (Input.GetKeyDown(KeyCode.S) && down && !up) { //down

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1].Equals("player")){

                //move the player in the 2d array
                GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] = "smooth";
                GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

                gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x, gridPos.gridPosition.y + 1);
            }
        }    
        if (Input.GetKeyDown(KeyCode.A) && left && !right) { //left

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 + 1, gridPos.gridPosition.y - 1].Equals("player")){

                //move the player in the 2d array
                GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] = "smooth";
                GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

                gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x - 1, gridPos.gridPosition.y);
            }
        }   
        if (Input.GetKeyDown(KeyCode.D) && right && !left) { //right

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1].Equals("player")){

                //move the player in the 2d array
                GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] = "smooth";
                GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

                gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x + 1, gridPos.gridPosition.y);
            }
        }    
    }
}
