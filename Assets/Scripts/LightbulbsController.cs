using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

[System.Serializable]
public class Lightbulb
{
    public bool isOn;
    public GameObject LightbulbObject;
    public GameObject Text0;
    public GameObject Text1;
}

public class LightbulbsController : MonoBehaviour
{
    public List<Lightbulb> Lightbulbs;
    public List<Material> LightMaterials;

    // Start is called before the first frame update
    void Start()
    {
        LightControll();
    }

    private void OnEnable()
    {
        foreach (var item in Lightbulbs)
        {
            item.isOn = false;
        }
        LightControll();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            { 
                int BulbNumber = int.Parse(hit.transform.tag);
                if (Lightbulbs[BulbNumber].isOn)
                    Lightbulbs[BulbNumber].isOn = false;
                else
                    Lightbulbs[BulbNumber].isOn = true;
            }
            LightControll();
        }
    }

    void LightControll()
    {
        foreach (var item in Lightbulbs)
        {
            if (item.isOn) { 
                item.LightbulbObject.GetComponent<MeshRenderer>().material = LightMaterials[1];
                item.Text0.SetActive(false);
                item.Text1.SetActive(true);
            }
            else
            {
                item.LightbulbObject.GetComponent<MeshRenderer>().material = LightMaterials[0];
                item.Text0.SetActive(true);
                item.Text1.SetActive(false);
            }                
        }
    }
}
