using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LblTest1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var a = this.GetComponent<TextMeshProUGUI>();
        a.text = "333333";
    }
}
