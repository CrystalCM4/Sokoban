using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : Movement
{
    public Transform pos;

    public static int minY;
    public static int maxY;
    public static int minX;
    public static int maxX;

    // Start is called before the first frame update
    void Start()
    {
        GridManager.objects.Add(gameObject);

        minY = 1;
        maxY = 5;
        minX = 1;
        maxX = 10;

        //print("" + (gridPos.gridPosition.x - 1) + ", " + (gridPos.gridPosition.y - 1));
        left = true;
        right = true;
        up = true;
        down = true;
    }

    // Update is called once per frame
    void Update()
    {   
        //print(gameObject.name + ": left: " + left + ", right: " + right + ", up: " + up + ", down: " + down);

        if (gridPos.gridPosition.x != minX) {

            GameObject objectLeft = gameObject; //temporary object
            bool objectFound = false;

            for (int i = 0; i < GridManager.objects.Count; i++){
                if (GridManager.objects[i] == gameObject) {

                    //x and y of this object
                    int x;
                    x = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.x;
                    int y;
                    y = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.y;
                    
                    //get the object in x - 1 / left
                    for (int j = 0; j < GridManager.objects.Count; j++){
                        if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x - 1
                        && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y){
                            
                            //object on the left
                            objectLeft = GridManager.objects[j];
                            objectFound = true;
                            break;
                        }
                    }
                    break;
                }
            }

            if (objectLeft.GetComponent<Movement>().left || !objectFound){
                //the object on the left can move / no object on left
                left = true;
            }
            else left = false;
        }
        else left = false;

        if (gridPos.gridPosition.x != maxX) {

            GameObject objectRight = gameObject; //temporary object
            bool objectFound = false;

            for (int i = 0; i < GridManager.objects.Count; i++){
                if (GridManager.objects[i] == gameObject) {

                    //x and y of this object
                    int x;
                    x = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.x;
                    int y;
                    y = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.y;
                    
                    //get the object in x + 1 / right
                    for (int j = 0; j < GridManager.objects.Count; j++){
                        if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x + 1
                        && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y){
                            
                            //object on the right
                            objectRight = GridManager.objects[j];
                            objectFound = true;
                            break;
                        }
                    }
                    break;
                }
            }

            if (objectRight.GetComponent<Movement>().right || !objectFound){
                //the object on the right can move / no object on right
                right = true;
            }
            else right = false;
        }
        else right = false;

        if (gridPos.gridPosition.y != minY) {
           
            GameObject objectUp = gameObject; //temporary object
            bool objectFound = false;

            for (int i = 0; i < GridManager.objects.Count; i++){
                if (GridManager.objects[i] == gameObject) {

                    //x and y of this object
                    int x;
                    x = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.x;
                    int y;
                    y = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.y;
                    
                    //get the object in y - 1 / up
                    for (int j = 0; j < GridManager.objects.Count; j++){
                        if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                        && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y - 1){
                            
                            //object above
                            objectUp = GridManager.objects[j];
                            objectFound = true;
                            break;
                        }
                    }
                    break;
                }
            }

            if (objectUp.GetComponent<Movement>().up || !objectFound){
                //the object above can move / no object above
                up = true;
            }
            else up = false;
        }
        else up = false;

        if (gridPos.gridPosition.y != maxY) {
            
            GameObject objectDown = gameObject; //temporary object
            bool objectFound = false;

            for (int i = 0; i < GridManager.objects.Count; i++){
                if (GridManager.objects[i] == gameObject) {

                    //x and y of this object
                    int x;
                    x = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.x;
                    int y;
                    y = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.y;
                    
                    //get the object in y + 1 / down
                    for (int j = 0; j < GridManager.objects.Count; j++){
                        if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                        && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y + 1){
                            
                            //object below
                            objectDown = GridManager.objects[j];
                            objectFound = true;
                            break;
                        }
                    }
                    break;
                }
            }

            if (objectDown.GetComponent<Movement>().down || !objectFound){
                //the object below can move / no object under
                down = true;
            }
            else down = false;
        }
        else down = false;
    }
}
