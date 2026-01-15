using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

struct Berry
{
    public float x;
    public float y;
}

public class BerryBush : MonoBehaviour
{
    public GameObject berryPre;

    public int berryCount;
    
    private void Start()
    {
        MakeBerry();
    }

    private void MakeBerry()
    {
        if (berryCount <= 6)
        {
            List<Berry> bPosList = new List<Berry> {new Berry{x = 0.3f, y =0.1f}, new Berry{x = -0.2f, y = 0.2f},new Berry{x = 0.1f, y = -0.3f}};
            List<Berry> bPosListCopy = new List<Berry>(bPosList);

            
            if (bPosListCopy.Count > 0)
            {
                int randomIndex = Random.Range(0, bPosListCopy.Count);
            
                float randomValueX = bPosListCopy[randomIndex].x;
                float randomValueY = bPosListCopy[randomIndex].y;
                
                bPosListCopy.RemoveAt(randomIndex);
                
                //Debug.Log("random Index : " + randomIndex);
                //Debug.Log("list count : " + bPosListCopy.Count);
                //Debug.Log(" X값: " + randomValueX + " Y값: " + randomValueY);
            }
            
            float berryX = Random.Range(-0.25f, 0.25f);
            float berryY = Random.Range(-0.25f, 0.25f);
            Vector3 spawnPos = new Vector3(berryX, berryY, transform.position.z);
            
            GameObject berry =  Instantiate(berryPre, gameObject.transform.position + new Vector3(berryX, berryY, 0), Quaternion.identity, transform);
            
            berryCount++;

            int makeTime =  Random.Range(3, 6);
            Invoke("MakeBerry", makeTime);
        }
        
    }
}