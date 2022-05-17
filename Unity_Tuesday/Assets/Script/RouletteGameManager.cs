using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteGameManager : MonoBehaviour
{
    [SerializeField]
    Text result;
    [SerializeField]
    GameObject rouletteStop;

    RouletteScript RouletteScript;
    float num;

    // Start is called before the first frame update
    void Start()
    {
        RouletteScript = rouletteStop.GetComponent<RouletteScript>();
    }

    // Update is called once per frame
    void Update()
    {
        num = RouletteScript.Rot;
        while(true)
        {
            if((Mathf.Abs(num) > 360))
            {
                num -= 360;
            }
            else
            {
                break;
            }
        }

           if (num > 0)
            {

                if(331 <= num || num <= 30)
                {
                result.text = "‹¥";
                }
                else if(31 <= num && num <= 90)
                {
                    result.text = "‘å‹g";
                }
                else if (91 <= num && num <= 150)
                {
                    result.text = "‘å‹¥";
                }
                else if (151 <= num && num <= 210)
                {
                    result.text = "¬‹g";
                }
                else if (211 <= num && num <= 270)
                {
                    result.text = "––‹g";
                }
                else if (271 <= num && num <= 330)
                {
                    result.text = "’†‹g";
                }

            }
            else
            {
                if (-331 >= num || num >= -30)
                {
                    result.text = "‹¥";
                }
                else if (-31 >= num && num >= -90)
                {
                    result.text = "’†‹g";
                }
                else if (-91 >= num && num >= -150)
                {
                    result.text = "––‹g";
                }
                else if (-151 >= num && num >= -210)
                {
                    result.text = "¬‹g";
                }
                else if (-211 >= num && num >= -270)
                {
                    result.text = "‘å‹¥";
                }
                else if (-271 >= num && num >= -330)
                {
                    result.text = "‘å‹g";
                }
            }
        
    }
}
