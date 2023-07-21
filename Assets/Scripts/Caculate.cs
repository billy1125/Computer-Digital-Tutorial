using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caculate : MonoBehaviour
{
    public List<Text> AllInputFields;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double answer = 0;
        float power = 0;
        for (int i = 0; i < AllInputFields.Count; i++)
        {
            if (AllInputFields[i].text == "0" || AllInputFields[i].text == "1") 
            { 
                power = 7 - i;
                answer += Mathf.Pow(2, power) * int.Parse(AllInputFields[i].text);
            }
            else
                answer += 0;
        }

        GetComponent<InputField>().text = answer.ToString();
    }
}
