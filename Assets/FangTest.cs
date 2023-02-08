using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FangTest : MonoBehaviour
{
    public GameObject cc;
    public GameObject zhuan;

    public GameObject move;

    public
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v =  this.transform.position - this.cc.transform.position;
        this.transform.forward = v;

        Vector3 yaoganv = this.zhuan.transform.position.normalized;


        Vector3 v1 = this.transform.forward * yaoganv.z;
        Vector3 v2 = this.transform.right * yaoganv.x;

        Vector3 v3 = v1 + v2;

        Debug.Log(v3);

        this.move.transform.position = this.transform.position + v3;

        // Quaternion.AngleAxis(angle, axis) * (position - center) + center;
    }
}
