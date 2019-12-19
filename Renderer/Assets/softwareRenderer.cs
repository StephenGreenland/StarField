using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class softwareRenderer : MonoBehaviour
{
    

    public int xSize;
    public int ySize;
    private int zeroX;
    private int zeroY;

    public byte[,] backBuffer;

    private float timer;
    
    public GameObject quadRenderer;


    private Texture2D tex;
    public Vector3 star;
    public List<Vector3> stars;

    // Start is called before the first frame update
    void Start()
    {
        timer = .5f;
        
      // backBuffer = new byte[xSize,ySize];

      zeroX = xSize / 2;
      zeroY = ySize / 2;
      
        
        tex = new Texture2D(xSize,ySize,TextureFormat.RGB24,false);
        tex.filterMode = FilterMode.Point;
        gameObject.GetComponent<MeshRenderer>().material.mainTexture = tex;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Makestar();
            StartCoroutine(MoveZ());
            timer = .5f;
        }
        
        drawThings();
        
    }
    
    IEnumerator MoveZ()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            yield return new WaitForSeconds(1);

            stars[i] = new Vector3(stars[i].x, stars[i].y, stars[i].z +1f);
        }

        yield return null;
    }

    private void Makestar()
    {
        stars.Add(new Vector3(UnityEngine.Random.Range((int)xSize/8 *-1,xSize/8),UnityEngine.Random.Range(ySize/8 *-1,ySize/8),0));
    }

    void drawThings()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                tex.SetPixel(i,j,Color.black);
            }
        }

        if (stars.Count > 0)
        {
            
            for (int i = 0; i < stars.Count; i++)
            {
                
                if (zeroX + (int) stars[i].x * (int) stars[i].z < xSize &&
                    zeroX + (int) stars[i].x * (int) stars[i].z > xSize * -1)
                {
                    if (zeroY + (int) stars[i].y * (int) stars[i].z < ySize &&
                        zeroY + (int) stars[i].y * (int) stars[i].z > ySize * -1)
                    {
                        tex.SetPixel(zeroX + (int) stars[i].x * (int) stars[i].z,
                            zeroY + (int) stars[i].y * (int) stars[i].z, Color.white);

                    }
                }
            }
            
        }
        tex.Apply(true);
    }
    
}
