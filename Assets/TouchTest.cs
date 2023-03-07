using System;
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

    private float startX = 0;

    public int backX = 0;
    public int backY = 0;

    public Transform aat = null;
    void Update()
    {
        //缩放也应该reset
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("aaaaaaaaaaaaaaaaaa");
            Debug.Log(this.aat.localEulerAngles.y);
            Debug.Log(look.m_XAxis.Value);
            this.backX = 1;
            this.backY = 1;
        }
        float tweenTime = 0.1f;
        if (backX == 1)
        {
            // float targetX = 0;
            float targetX = this.aat.localEulerAngles.y;
            float a = targetX % 360;
            float b = look.m_XAxis.Value % 360;

            if (Math.Abs(a - b) < 180)
            {
                targetX = a;
            }
            else
            {
                targetX = a + 360;
            }

            // targetX - look.m_XAxis.Value;
            // look.m_XAxis.Value > 180 ? 360 : 0;
            // look.m_XAxis.Value > 180 ? 360 : 0

            float speedX = 360.0f / tweenTime;
            look.m_XAxis.Value = Mathf.Lerp(look.m_XAxis.Value, targetX, speedX * Time.deltaTime / 360);
            if (Math.Abs(look.m_XAxis.Value - targetX) < 0.1f)
            {
                this.backX = 0;
                look.m_XAxis.Value = targetX;
            }
        }
        if (this.backY == 1)
        {
            float speedY = 1.0f / tweenTime;
            look.m_YAxis.Value = Mathf.Lerp(look.m_YAxis.Value, 0.75f, speedY * Time.deltaTime / 1);
            if (Math.Abs(look.m_YAxis.Value - 0.75f) < 0.01)
            {
                look.m_YAxis.Value = 0.75f;
                this.backY = 0;
            }
        }

        if (this.backX == 1 || this.backY == 1)
        {
            return;
        }

        if (JoyCube.Use.UpdateAndGetFingers().Count >= 2)
        {
            return;
        }
        if (this.isClick())
        {
            this.drag = true;
            this.startY = look.m_YAxis.Value;
            this.startX = look.m_XAxis.Value;
            this.lasty = Input.mousePosition.y;
            // this.lastx = Input.mousePosition.x / Screen.width;
            this.lastx = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.drag = false;
        }
        if (this.drag)
        {
            float pery = (this.lasty - Input.mousePosition.y) / Screen.height;
            look.m_YAxis.Value = this.startY + pery;

            float perx = (this.lastx - Input.mousePosition.x) / Screen.width;
            look.m_XAxis.Value = this.startX - perx * 360;

            // float perx = Input.mousePosition.x / Screen.width;
            // look.m_XAxis.Value = -360.0f * (this.lastx - perx);
            // this.lastx = perx;
        }
    }

    private void startMove()
    {

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
