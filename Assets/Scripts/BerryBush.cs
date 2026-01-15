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

    private List<Berry> bPosListCopy;
    private List<Berry> bPosList;
    
    private void Start()
    {
        bPosList = new List<Berry> {new Berry{x = 0.3f, y =0.1f}, new Berry{x = -0.2f, y = 0.2f},new Berry{x = 0.1f, y = -0.3f}};
        bPosListCopy = new List<Berry>(bPosList);
        
        MakeBerry();
        
    }

    private void MakeBerry()
    {
        
        if (bPosListCopy.Count != 0)
        {
            if (bPosListCopy.Count == 0)
            {
                bPosListCopy = new List<Berry>(bPosList);
                Debug.Log("bPosListCopy 리스트 리셋");
            }
            
            int randomIndex = Random.Range(0, bPosListCopy.Count);
            float randomValueX = bPosListCopy[randomIndex].x;
            float randomValueY = bPosListCopy[randomIndex].y;
            bPosListCopy.RemoveAt(randomIndex);
            Debug.Log("randomValueX : " + randomValueX + "randomValueY : " + randomValueY);
            
            Vector3 spawnPos = gameObject.transform.position + new Vector3(randomValueX, randomValueY, transform.position.z);
            Debug.Log("spawnPos : " + spawnPos);
            GameObject berry =  Instantiate(berryPre, spawnPos, Quaternion.identity, transform);

            int makeTime =  Random.Range(3, 6);
            Invoke("MakeBerry", makeTime);
        }
        
    }
}