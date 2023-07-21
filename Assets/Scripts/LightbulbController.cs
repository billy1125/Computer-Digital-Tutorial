using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightbulbController : MonoBehaviour
{
    public Text InputText;
    public List<Material> LightMaterials;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputText.text == "0")
        {
            GetComponent<MeshRenderer>().material = LightMaterials[0];
        }else if(InputText.text == "1")
        {
            GetComponent<MeshRenderer>().material = LightMaterials[1];
        }
        else
        {
            GetComponent<MeshRenderer>().material = LightMaterials[0];
        }
    }
}
