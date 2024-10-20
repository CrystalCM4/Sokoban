using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClingyMovement : Movement
{

    // Start is called before the first frame update
    void Start()
    {
        GridManager.objects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject objectLeft = gameObject;
        GameObject objectRight = gameObject;
        GameObject objectUp = gameObject;
        GameObject objectDown = gameObject;

        //real code starts here
        if (gridPos.gridPosition.x != PlayerMovement.minX) {

            //GameObject objectLeft = gameObject; //temporary object
            //bool objectFound = false;

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
                            //objectFound = true;
                            break;
                        }
                    }
                    break;
                }
            }

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectLeft.GetComponent<Movement>().left){
                left = true;
                if (!objectLeft.GetComponent<Movement>().left){
                    left = false;
                }
            }
            else left = false;
        }
        else left = false;

        if (gridPos.gridPosition.x != PlayerMovement.maxX) {

            //GameObject objectRight = gameObject; //temporary object

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

            if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
            && objectRight.GetComponent<Movement>().right){
                right = true;

                if (!objectRight.GetComponent<Movement>().right){
                    right = false;
                }
            }
            else right = false;
        }
        else right = false;

        if (gridPos.gridPosition.y != PlayerMovement.minY) {
           
            //GameObject objectUp = gameObject; //temporary object

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

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                && objectUp.GetComponent<Movement>().up){            
                up = true;

                if (!objectUp.GetComponent<Movement>().up){
                    up = false;
                }
            }
            else up = false;
        }
        else up = false;

        if (gridPos.gridPosition.y != PlayerMovement.maxY) {
            
            //GameObject objectDown = gameObject; //temporary object

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

            if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                && objectLeft.GetComponent<Movement>().left){       
                down = true;
                if (!objectDown.GetComponent<Movement>().down){
                    down = false;
                }
            }
            else down = false;
        }
        else down = false;

        
        //sticky check
        //look for sticky
        for (int i = 0; i < GridManager.objects.Count; i++){
            if (GridManager.objects[i] == gameObject) {

                //x and y of this object
                int x;
                x = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.x;
                int y;
                y = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.y;
                
                //get the object in x - 1 / left
                for (int j = 0; j < GridManager.objects.Count; j++){
                    if ((GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == (x - 1)
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y)

                    || (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == (x + 1)
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y)

                    || (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == (y - 1))

                    || (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == (y + 1))){
                        
                        if (GridManager.objects[j].CompareTag("Sticky")){
                            stickyFound = true;
                            DetectSticky(j);
                        }
                        else {
                            stickyFound = false;
                        } 
                    }
                }
            }
        }


        //print(gameObject.name + ": left: " + left + ", right: " + right + ", up: " + up + ", down: " + down);
    }

    public void DetectSticky(int j){
        if (GridManager.objects[j].GetComponent<Movement>().left){
            stickyLeft = true;
        }

        if (GridManager.objects[j].GetComponent<Movement>().right){
            stickyRight = true;
        }

        if (GridManager.objects[j].GetComponent<Movement>().up){
            stickyUp = true;
        }

        if (GridManager.objects[j].GetComponent<Movement>().down){
            stickyDown = true;
        }
    }
}
