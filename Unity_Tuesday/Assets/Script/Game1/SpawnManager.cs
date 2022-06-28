using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject item = null;
    //DestroyScript destroyScript = null;
    // Start is called before the first frame update
    void Start()
    {
        ItemDetekuru();
        //destroyScript = item.GetComponent<DestroyScript>().isDest;
        StartCoroutine(itemspawn());
    }


    IEnumerator itemspawn()
    {
        while (true)
        {
            //bool isDestroy = item.GetComponent<DestroyScript>().isDest;
            //if (isDestroy)
            //{
            //    ItemDetekuru();
            //    item.GetComponent<DestroyScript>().isDest = false;
            //}
            yield return null;

        }
    }

    void ItemDetekuru()
    {
        GameObject instance = (GameObject)Instantiate(item,
            new Vector3(Random.Range(-7, 7), Random.Range(-3, 3), 0),
            Quaternion.identity);

    }
}
