using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField]private GameObject okiagariEnemy;
    [SerializeField]private float waitEnemySpawn = 0f;
    void Start()
    {
        CreateObject();
    }

    public void CreateObject()
    {
        StartCoroutine(CreateEnemyCoroutine());
    }
    IEnumerator CreateEnemyCoroutine()
    {
        while (true)
        {
            GameObject obj = Instantiate(okiagariEnemy, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(waitEnemySpawn);
        }
    }
}
