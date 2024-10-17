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


        left = false;
        right = false;
        up = false;
        down = false;

        //look for object
        /*
        bool objectFound = false;
        int objNum = 0;
        */

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
                        CheckState(j);
                    }

                    if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == (x + 1)
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == y){
                        CheckState(j);
                    }

                    if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == (y - 1)){
                        CheckState(j);
                    }

                    if (GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.x == x
                    && GridManager.objects[j].GetComponent<Movement>().gridPos.gridPosition.y == (y + 1)){
                        CheckState(j);
                    }
                }
            }
        }
        
        //print(gameObject.name + ": left: " + left + ", right: " + right + ", up: " + up + ", down: " + down);
    }

    void LateUpdate(){
        if (gridPos.gridPosition.x == PlayerMovement.minX){
            left = false;
        }
        if (gridPos.gridPosition.x == PlayerMovement.maxX){
            right = false;
        }
        if (gridPos.gridPosition.y == PlayerMovement.minY){
            up = false;
        }
        if (gridPos.gridPosition.y == PlayerMovement.maxY){
            down = false;
        }
    }

    public void CheckState(int j){

        left = GridManager.objects[j].GetComponent<Movement>().left;

        right = GridManager.objects[j].GetComponent<Movement>().right;

        up = GridManager.objects[j].GetComponent<Movement>().up;

        down = GridManager.objects[j].GetComponent<Movement>().down;
    }
}
