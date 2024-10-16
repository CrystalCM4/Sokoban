using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.Jobs;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static string[,] gridPoint = new string[10, 5];
    public static List<GameObject> objects = new();

    // Start is called before the first frame update
    void Awake()
    {     
        for (int i = 0; i < gridPoint.GetLength(0); i ++){
            for (int j = 0; j < gridPoint.GetLength(1); j ++){
                gridPoint[i,j] = "";
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    void LateUpdate()
    {
        //check hereasdafasdf
        for (int i = 0; i < objects.Count; i++){
            if (objects[i].GetComponent<Movement>().up) {
                if (Input.GetKeyDown(KeyCode.W)) {
                    MoveUp(i);
                }   
            }
            if (objects[i].GetComponent<Movement>().down) {
                if (Input.GetKeyDown(KeyCode.S)) {
                    MoveDown(i);
                }   
            }
            if (objects[i].GetComponent<Movement>().left) {
                if (Input.GetKeyDown(KeyCode.A)) {
                    MoveLeft(i);
                }   
            }
            if (objects[i].GetComponent<Movement>().right) {
                if (Input.GetKeyDown(KeyCode.D)) {
                    MoveRight(i);
                }   
            }
        }
    }
    

    public static void MoveUp(int i){
        string type = objects[i].GetComponent<Movement>().objectType;
        GridObject gridPos = objects[i].GetComponent<Movement>().gridPos;

        gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] = type;
        gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

        gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x, gridPos.gridPosition.y - 1);
    }

    public static void MoveDown(int i){
        string type = objects[i].GetComponent<Movement>().objectType;
        GridObject gridPos = objects[i].GetComponent<Movement>().gridPos;

        gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] = type;
        gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

        gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x, gridPos.gridPosition.y + 1);
    }

    public static void MoveLeft(int i){
        string type = objects[i].GetComponent<Movement>().objectType;
        GridObject gridPos = objects[i].GetComponent<Movement>().gridPos;

        gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] = type;
        gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

        gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x - 1, gridPos.gridPosition.y);
    }

    public static void MoveRight(int i){
        string type = objects[i].GetComponent<Movement>().objectType;
        GridObject gridPos = objects[i].GetComponent<Movement>().gridPos;

        gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] = type;
        gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "";

        gridPos.gridPosition = new Vector2Int(gridPos.gridPosition.x + 1, gridPos.gridPosition.y);
    }
}
