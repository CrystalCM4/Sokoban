using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public GridObject gridPos;
    // Start is called before the first frame update
    void Start()
    {
        GridManager.gridPoint[gridPos.gridPosition.x - 1, gridPos.gridPosition.y - 1] = "wall";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
