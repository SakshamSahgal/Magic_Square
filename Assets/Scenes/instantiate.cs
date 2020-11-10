using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class instantiate : MonoBehaviour
{

    int startvalue = 0;
    public Text value;
    public GameObject instantiateit;
    public Vector3 itsposition;
    // Start is called before the first frame update
    void Start()
    {
        itsposition.x = 1;
        itsposition.y = 2;
        itsposition.z = 5;
        Instantiate(instantiateit);
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(itsposition.x);
            itsposition.x = itsposition.x + 2;
            Instantiate(instantiateit,itsposition,transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namepos = Camera.main.WorldToScreenPoint(this.transform.position);
        instantiateit.transform.GetChild(0).gameObject.SetActive(false);
        value.text = startvalue.ToString();
    }
}
