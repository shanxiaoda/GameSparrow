using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTest : MonoBehaviour
{
    public CharacterController cc = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.cc.Move(Vector3.one * 0.01f);
    }
}
