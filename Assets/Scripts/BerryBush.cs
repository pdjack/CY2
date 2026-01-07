using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
            float berryX = Random.Range(-0.25f, 0.25f);
            float berryY = Random.Range(-0.25f, 0.25f);
            Vector3 spawnPos = new Vector3(berryX, berryY, transform.position.z);
            
            GameObject berry =  Instantiate(berryPre, gameObject.transform.position + new Vector3(berryX, berryY, 0), Quaternion.identity, transform);
            
            berryCount++;

            int makeTime =  Random.Range(3, 6);
            Invoke("MakeBerry", makeTime);
        }
        
    }
    
    // void SpawnWithoutOverlap()
    // {
    //     Vector2 spawnPos;
    //     bool canSpawn = false;
    //
    //     while (!canSpawn)
    //     {
    //         spawnPos = new Vector2(Random.Range(-spawnRange.x, spawnRange.x), Random.Range(-spawnRange.y, spawnRange.y));
    //     
    //         // 해당 위치에 'Obstacle' 레이어를 가진 콜라이더가 있는지 체크
    //         Collider2D hit = Physics2D.OverlapCircle(spawnPos, prefabRadius);
    //     
    //         if (hit == null) {
    //             Instantiate(prefab, spawnPos, Quaternion.identity);
    //             canSpawn = true;
    //         }
    //     }

    
}