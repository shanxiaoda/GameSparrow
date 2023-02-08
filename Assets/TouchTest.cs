using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Cinemachine.CinemachineFreeLook look;

    private bool drag = false;
    private float startY = 0;
    // Update is called once per frame
    private float lastx = 0;
    private float lasty = 0;

    void Update()
    {
        if (JoyCube.Use.UpdateAndGetFingers().Count == 2)
        {
            // this.look.m_YAxis.m_MaxSpeed = 0;
            // this.look.m_XAxis.m_MaxSpeed = 0;
            return;
        }

        // this.look.m_YAxis.m_MaxSpeed = 2;
        // this.look.m_XAxis.m_MaxSpeed = 300;

        if (this.isClick())
        {
            this.drag = true;
            this.startY = look.m_YAxis.Value;
            this.lasty = Input.mousePosition.y;
            this.lastx = Input.mousePosition.x / Screen.width;
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.drag = false;
        }
        if (this.drag)
        {
            float pery = (this.lasty - Input.mousePosition.y) / Screen.height;
            look.m_YAxis.Value = this.startY + pery;
            float perx = Input.mousePosition.x / Screen.width;
            look.m_XAxis.Value = -360.0f * (this.lastx - perx);
            this.lastx = perx;
        }
    }

    private bool isClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                // Debug.Log("点到了ui");
                return false;
            }
            return true;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Touched the UI");
            }
        }
        return false;
    }
}
