using System;
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
        
            GameObject berry =  Instantiate(berryPre, gameObject.transform.position + new Vector3(berryX, berryY, 0), Quaternion.identity, transform);
            berry.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            
            berryCount++;

            int makeTime =  Random.Range(3, 6);
            Invoke("MakeBerry", makeTime);
        }
        
    }
}