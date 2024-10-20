using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMovement : Movement
{
    // Start is called before the first frame update
    void Start()
    {
        GridManager.objects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        

        //look for object
        
        bool objectFound = false;
        int objNum = 0;
        

        for (int i = 0; i < GridManager.objects.Count; i++){
            if (GridManager.objects[i] == gameObject) { 

                //x and y of this object
                int x;
                x = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.x;
                int y;
                y = GridManager.objects[i].GetComponent<Movement>().gridPos.gridPosition.y;
                
                //get the object in x - 1 / left
                for (int j = 0; j < GridManager.objects.Count; j++){
                    if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == (x - 1)
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y){
                        //print("object left");
                        objectFound = true;
                        objNum = j;
                        CheckState(objNum);
                    }

                    if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == (x + 1)
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y){
                        //print("object right");
                        objectFound = true;
                        objNum = j;
                        CheckState(objNum);
                    }

                    if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == (y - 1)){
                        //print("object down");
                        objectFound = true;
                        objNum = j;
                        CheckState(objNum);
                    }

                    if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == (y + 1)){
                        //print("object up");
                        objectFound = true;
                        objNum = j;
                        CheckState(objNum);
                    }
                }
            }
        }

        if (objectFound){
            //CheckState(objNum);
        }
        
        //print(gameObject.name + ": left: " + left + ", right: " + right + ", up: " + up + ", down: " + down);
    }

    void LateUpdate(){
        
    }

    public void CheckState(int j){

        //edge check
        if (gridPos.gridPosition.x != PlayerMovement.minX){
            if (GridManager.objects[j].GetComponent<Movement>().left){
                left = true;
            }
            else left = false;
        }
        else left = false;

        if (gridPos.gridPosition.x != PlayerMovement.maxX){
            if (GridManager.objects[j].GetComponent<Movement>().right){
                right = true;
            }
            else right = false;
        }
        else right = false;

        if (gridPos.gridPosition.y != PlayerMovement.minY){
            if (GridManager.objects[j].GetComponent<Movement>().up){
                up = true;
            }
            else up = false;
        }
        else up = false;

        if (gridPos.gridPosition.y != PlayerMovement.maxY){
            if (GridManager.objects[j].GetComponent<Movement>().down){
                down = true;
            }
            else down = false;
        }
        else down = false;
    }
}
