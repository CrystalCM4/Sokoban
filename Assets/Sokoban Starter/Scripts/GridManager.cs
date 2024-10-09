using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static string[,] gridPoint = new string[10, 5];

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
    void Update()
    {
        
    }
}
