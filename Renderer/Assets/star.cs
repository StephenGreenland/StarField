using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class star : MonoBehaviour
{

    public softwareRenderer render;

    public Vector3 starLocation;
    
    
    // Start is called before the first frame update
    void Start()
    {
        starLocation = new Vector3(Random.Range(render.xSize *-1,render.xSize),Random.Range(render.ySize *-1,render.ySize),0);
      
        render.stars.Add(starLocation);
       
        StartCoroutine(MoveZ());
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveZ()
    {
        for (int i = 0; i < 120; i++)
        {
            yield return new WaitForSeconds(1);
            
            starLocation = new Vector3(starLocation.x,starLocation.y,i);
        }
        
        Destroy(this.gameObject);
        yield return null;
    }

    private void OnDestroy()
    {
        render.stars.Remove(starLocation);
    }
}
