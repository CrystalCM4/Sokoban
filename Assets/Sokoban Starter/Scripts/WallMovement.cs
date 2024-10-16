using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : Movement
{
    
    // Start is called before the first frame update
    void Start()
    {
        GridManager.objects.Add(gameObject);

        left = false;
        right = false;
        up = false;
        down = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
