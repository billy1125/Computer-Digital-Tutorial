using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDivide : MonoBehaviour
{
    int total;
    bool t;
    int q, r;

    public List<Text> RemainderTextList;
    public List<Text> QuotientTextList;

    public Text MiddleText;

    private void Start()
    {
        total = RemainderTextList.Count;
    }

    public void Caculate()
    {
        t = int.TryParse(GetComponent<InputField>().text, out q);
        if (t == true)
            for (int i = 0; i < total; i++)
            {
                r = q % 2;
                q = q / 2;

                RemainderTextList[i].text = r.ToString();
                QuotientTextList[i].text = q.ToString();
            }
        MiddleText.text = QuotientTextList[3].text;

        QuotientTextList[total - 1].GetComponent<Animator>().enabled = true;
        QuotientTextList[total - 1].GetComponent<Animator>().Rebind();

        for (int i = 0; i < total; i++)
        {
            RemainderTextList[i].GetComponent<Animator>().enabled = true;
            RemainderTextList[i].GetComponent<Animator>().Rebind();
        }
    }  
}
