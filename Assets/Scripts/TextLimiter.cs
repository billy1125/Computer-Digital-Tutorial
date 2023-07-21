using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLimiter : MonoBehaviour
{


    public void CheckText()
    {
        if (GetComponent<InputField>().text != "0" && GetComponent<InputField>().text != "1")
        {
            GetComponent<InputField>().text = "0";
            GetComponent<InputField>().Select();
        }
    }


}
