using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SmoothMovement : Movement
{

    // Start is called before the first frame update
    void Start()
    {
        GridManager.objects.Add(gameObject);

        objectType = "smooth";
        GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = objectType;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gridPos.gridPosition.x != PlayerMovement.minX) {

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

            //player on left and object on the left can move / no object on left
            if (gridPos.gridPosition.x + 1 <= PlayerMovement.maxX){
                if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1].Equals("player")
                && (objectLeft.GetComponent<Movement>().left || !objectFound)) {
                    left = true;
                }
                else left = false;
            }
        }
        else left = false;

        if (gridPos.gridPosition.x != PlayerMovement.maxX) {

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

            //player on left and object on the right can move / no object on right
            if (gridPos.gridPosition.x - 1 >= PlayerMovement.minX){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1].Equals("player")
                && (objectRight.GetComponent<Movement>().right || !objectFound)) {
                    right = true;
                }
                else right = false;
            }
            

        }
        else right = false;

        if (gridPos.gridPosition.y != PlayerMovement.minY) {
           
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

            //player below and object above can move / no object above
            if (gridPos.gridPosition.y + 1 <= PlayerMovement.maxY){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1].Equals("player")
                && (objectUp.GetComponent<Movement>().up || !objectFound)) {
                    up = true;
                }
                else up = false;
            }
        }
        else up = false;

        if (gridPos.gridPosition.y != PlayerMovement.maxY) {
            
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

            //player above and object below can move / no object below
            if (gridPos.gridPosition.y - 1 >= PlayerMovement.minY){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1].Equals("player")
                && (objectDown.GetComponent<Movement>().down || !objectFound)) {
                    down = true;
                }
                else down = false;
            }
        }
        else down = false;

        
        
        //print(gameObject.name + ": left: " + left + ", right: " + right + ", up: " + up + ", down: " + down);
    }
}
