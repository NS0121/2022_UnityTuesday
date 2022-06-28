using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject Score_text = null;
    [SerializeField] GameObject Destory_obj = null; 
    string score;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        Text score_text = Score_text.GetComponent<Text>();
        score = num.ToString("000");
        // テキストの表示を入れ替える
        score_text.text = score;
    }

    // Update is called once per frame
    void Update()
    {

        if (Destory_obj.GetComponent<DestroyScript>().isDest)
        {
            Text score_text = Score_text.GetComponent<Text>();
            num += 10;
            score = num.ToString("000");
            score_text.text = score;
            Destory_obj.GetComponent<DestroyScript>().isDest = false;
        }
    }
}
