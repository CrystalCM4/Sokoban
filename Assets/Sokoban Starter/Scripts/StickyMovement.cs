using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMovement : Movement
{   

    void Start()
    {
        GridManager.objects.Add(gameObject);
        GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = gameObject;
    }

    // Update is called once per frame
    void Update()
    {   
        GameObject objectLeft = gameObject;
        GameObject objectRight = gameObject;
        GameObject objectUp = gameObject;
        GameObject objectDown = gameObject;

        left = false;
        right = false;
        up = false;
        down = false;

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
                        break;
                    }
                }
                break;
            }
        }

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
                        break;
                    }
                }
                break;
            }
        }

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
                        break;
                    }
                }
                break;
            }
        }

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
                        break;
                    }
                }
                break;
            }
        }

        //real code starts here
        if (gridPos.gridPosition.x != PlayerMovement.minX) {

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectLeft.GetComponent<Movement>().left){
                left = true;
                
                //if (gridPos.gridPosition.x != PlayerMovement.minX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectLeft.GetComponent<Movement>().left){
                        left = false;
                    }
                //}
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectLeft.GetComponent<Movement>().right){
                right = true;

                //if (gridPos.gridPosition.x != PlayerMovement.maxX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectRight.GetComponent<Movement>().right){
                        right = false;
                    }
                //} 
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectLeft.GetComponent<Movement>().up){
                up = true;

                //if (gridPos.gridPosition.y != PlayerMovement.minY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                    && !objectUp.GetComponent<Movement>().up){
                        up = false;
                    }
                //}
            }   

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectLeft.GetComponent<Movement>().down){
                down = true;

                //if (gridPos.gridPosition.y != PlayerMovement.maxY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                    && !objectDown.GetComponent<Movement>().down){
                        down = false;
                    }
                //}
            }
        }
        else left = false;

        if (gridPos.gridPosition.x != PlayerMovement.maxX) {

            if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectRight.GetComponent<Movement>().left){
                left = true;

                //if (gridPos.gridPosition.x != PlayerMovement.minX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectLeft.GetComponent<Movement>().left){
                        left = false;
                    }
                //}
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectRight.GetComponent<Movement>().right){
                right = true;

                //if (gridPos.gridPosition.x != PlayerMovement.maxX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectRight.GetComponent<Movement>().right){
                        right = false;
                    }
                //} 
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectRight.GetComponent<Movement>().up){
                up = true;

                //if (gridPos.gridPosition.y != PlayerMovement.minY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                    && !objectUp.GetComponent<Movement>().up){
                        up = false;
                    }
                //}
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectRight.GetComponent<Movement>().down){
                down = true;

                //if (gridPos.gridPosition.y != PlayerMovement.maxY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                    && !objectDown.GetComponent<Movement>().down){
                        down = false;
                    }
                //}
            }
        }
        else right = false;

        if (gridPos.gridPosition.y != PlayerMovement.minY) {

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                && objectUp.GetComponent<Movement>().left){            
                left = true;

                //if (gridPos.gridPosition.x != PlayerMovement.minX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectLeft.GetComponent<Movement>().left){
                        left = false;
                    }
                //}
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                && objectUp.GetComponent<Movement>().right){            
                right = true;

                //if (gridPos.gridPosition.x != PlayerMovement.maxX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectRight.GetComponent<Movement>().right){
                        right = false;
                    }
                //} 
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                && objectUp.GetComponent<Movement>().up){            
                up = true;

                //if (gridPos.gridPosition.y != PlayerMovement.minY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                    && !objectUp.GetComponent<Movement>().up){
                        up = false;
                    }
                //}
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                && objectUp.GetComponent<Movement>().down){            
                down = true;

                //if (gridPos.gridPosition.y != PlayerMovement.maxY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                    && !objectDown.GetComponent<Movement>().down){
                        down = false;
                    }
                //}
            }
        }
        else up = false;

        if (gridPos.gridPosition.y != PlayerMovement.maxY) {

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                && objectDown.GetComponent<Movement>().left){       
                left = true;

                //if (gridPos.gridPosition.x != PlayerMovement.minX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectLeft.GetComponent<Movement>().left){
                        left = false;
                    }
                //}
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                && objectDown.GetComponent<Movement>().right){       
                right = true;

                //if (gridPos.gridPosition.x != PlayerMovement.maxX){
                    if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
                    && !objectRight.GetComponent<Movement>().right){
                        right = false;
                    }
                //} 
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                && objectDown.GetComponent<Movement>().up){       
                up = true;

                //if (gridPos.gridPosition.y != PlayerMovement.minY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                    && !objectUp.GetComponent<Movement>().up){
                        up = false;
                    }
                //}
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                && objectDown.GetComponent<Movement>().down){       
                down = true;
                
                //if (gridPos.gridPosition.y != PlayerMovement.maxY) {
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                    && !objectDown.GetComponent<Movement>().down){
                        down = false;
                    }
                //}
                
            }
        }
        else down = false;
    }
}
