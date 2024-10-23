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
        GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //real code starts here
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

            //chain check
            for (int k = gridPos.gridPosition.x - 1; k < PlayerMovement.maxX - 1; k ++){
                if (GridManager.gridPoint[k + 1, gridPos.gridPosition.y - 1] != null
                && GridManager.gridPoint[k + 1, gridPos.gridPosition.y - 1].CompareTag("Smooth")){
                    left = false;
                }
                else if (GridManager.gridPoint[k + 1, gridPos.gridPosition.y - 1] == null){
                    left = false;
                    break;
                }
                else if (GridManager.gridPoint[k + 1, gridPos.gridPosition.y - 1] != null
                && GridManager.gridPoint[k + 1, gridPos.gridPosition.y - 1].CompareTag("Player")){
                    
                    if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
                    && (!objectFound || objectLeft.GetComponent<Movement>().left)){
                        left = true;
                    }
                    else left = false;
                    break;
                }
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

            //chain check
            for (int k = gridPos.gridPosition.x - 1; k > PlayerMovement.minX - 1; k --){

                if (GridManager.gridPoint[k - 1, gridPos.gridPosition.y - 1] != null
                && GridManager.gridPoint[k - 1, gridPos.gridPosition.y - 1].CompareTag("Smooth")){
                    right = false;
                }
                else if (GridManager.gridPoint[k - 1, gridPos.gridPosition.y - 1] == null){
                    right = false;
                    break;
                }
                else if (GridManager.gridPoint[k - 1, gridPos.gridPosition.y - 1] != null
                && GridManager.gridPoint[k - 1, gridPos.gridPosition.y - 1].CompareTag("Player")){

                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
                    && (!objectFound || objectRight.GetComponent<Movement>().right)){
                        
                        right = true;
                    }
                    else right = false;
                    
                    break;
                }
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

            //chain check
            for (int k = gridPos.gridPosition.y - 1; k < PlayerMovement.maxY - 1; k ++){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1, k + 1] != null
                && GridManager.gridPoint[gridPos.gridPosition.x - 1, k + 1].CompareTag("Smooth")){
                    up = false;
                }
                else if (GridManager.gridPoint[gridPos.gridPosition.x - 1, k + 1] == null){
                    up = false;
                    break;
                }
                else if (GridManager.gridPoint[gridPos.gridPosition.x - 1, k + 1] != null
                && GridManager.gridPoint[gridPos.gridPosition.x - 1, k + 1].CompareTag("Player")){
                    
                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                    && (!objectFound || objectUp.GetComponent<Movement>().up)){
                        up = true;
                    }
                    else up = false;
                    break;
                }
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

            //chain check
            for (int k = gridPos.gridPosition.y - 1; k > PlayerMovement.minY - 1; k --){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1, k - 1] != null
                && GridManager.gridPoint[gridPos.gridPosition.x - 1, k - 1].CompareTag("Smooth")){
                    down = false;
                }
                else if (GridManager.gridPoint[gridPos.gridPosition.x - 1, k - 1] == null){
                    down = false;
                    break;
                }
                else if (GridManager.gridPoint[gridPos.gridPosition.x - 1, k - 1] != null
                && GridManager.gridPoint[gridPos.gridPosition.x - 1, k - 1].CompareTag("Player")){

                    if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                    && (!objectFound || objectDown.GetComponent<Movement>().down)){
                        down = true;
                    }
                    else down = false;
                    break;
                }
            }

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
                            //print("sticky found");
                            //DetectSticky(j);
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

    /*
    public void DetectSticky(int j){
        
        if (GridManager.objects[j].GetComponent<Movement>().left){
            //stickyLeft = true;
            if (gridPos.gridPosition.x != PlayerMovement.minX){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
                && GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1].GetComponent<Movement>().left){
                    left = true;
                }
                else if (GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1] != null
                && !GridManager.gridPoint[gridPos.gridPosition.x - 1 - 1, gridPos.gridPosition.y - 1].GetComponent<Movement>().left){
                    left = false;
                }
            }
        }

        if (GridManager.objects[j].GetComponent<Movement>().right){
            //stickyRight = true;
            if (gridPos.gridPosition.x != PlayerMovement.maxX){
                if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
                && GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1].GetComponent<Movement>().right){
                    right = true;
                }
                else if (GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1] != null
                && !GridManager.gridPoint[gridPos.gridPosition.x + 1 - 1, gridPos.gridPosition.y - 1].GetComponent<Movement>().right){
                    right = false;
                }      
            }
        }

        if (GridManager.objects[j].GetComponent<Movement>().up){
            //stickyUp = true;
            if (gridPos.gridPosition.y != PlayerMovement.minY){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                && !GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1].GetComponent<Movement>().up){
                    up = true;
                }
                else if(GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1] != null
                && !GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1 - 1].GetComponent<Movement>().up){
                    up = false;
                }
            }
            
        }

        if (GridManager.objects[j].GetComponent<Movement>().down){
            //stickyDown = true;
            if (gridPos.gridPosition.y != PlayerMovement.maxY){
                if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                && GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1].GetComponent<Movement>().down){
                    down = true;
                }
                else if (GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1] != null
                && !GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y + 1 - 1].GetComponent<Movement>().down){
                    down = false;
                }
            }
        }
        
    }
    */
}
