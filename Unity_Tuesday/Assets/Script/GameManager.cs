using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject car;
    [SerializeField]
    GameObject flag;
    [SerializeField]
    Text distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;
        distance.text = "ÉSÅ[ÉãÇ‹Ç≈" + length.ToString("F2") + "m";
    }
}
