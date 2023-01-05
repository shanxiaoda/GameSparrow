using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("aaa", 3);
    }

    void aaa()
    {
        GameObject.Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        // this.gameObject.transform.Rotate(Vector3.one);
        // if (this.gameObject.transform.rotation.x > 1.0f)
        // {

        // }
        // UnityEngine.Debug.Log("aaaaaaaaaaaa");
    }

    private void OnEnable()
    {
        UnityEngine.Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        UnityEngine.Debug.Log("OnDisable aaaaaaaaaaa ");
    }

    private void OnDestroy()
    {
        UnityEngine.Debug.Log("OnDestroy aaaaaaaaaaaa ");
    }
}
