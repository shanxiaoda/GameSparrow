using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class JoyCube : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook freeLook;
    public CharacterController cc;
    public Joystick joystick;
    public float speed = 1.0f;

    public Vector3 v = new Vector3();

    public Animator animator;

    public GameObject tempgo;

    public GameObject scalego;

    public static Lean.Touch.LeanFingerFilter Use = new Lean.Touch.LeanFingerFilter(true);
    // public UnityEngine.Transform t;

    public CinemachineFreeLook.Orbit[] orbitList = null;

    private void Start()
    {
        this.orbitList = (CinemachineFreeLook.Orbit[])this.freeLook.m_Orbits.Clone();
    }

    void Update()
    {
        // freeLook.

        var fingers = Use.UpdateAndGetFingers();

        // scalego.transform.localScale *= Lean.Touch.LeanGesture.GetPinchScale(fingers);

        // Cinemachine.CinemachineFreeLook.Orbit o = this.freeLook.m_Orbits[1];

        // this.freeLook.m_Lens.FieldOfView *= Lean.Touch.LeanGesture.GetPinchScale(fingers);

        // Debug.Log(this.freeLook.m_Lens.FieldOfView  );
        Cinemachine.CinemachineFreeLook.Orbit o = this.freeLook.m_Orbits[1];
        float scale = Lean.Touch.LeanGesture.GetPinchScale(fingers);
        if (scale != 1)
        {
            scale = 2 - scale;
            for (int i = 0; i < this.freeLook.m_Orbits.Length; i++)
            {
                var now = this.freeLook.m_Orbits[i];
                var old = this.orbitList[i];
                float newScale = now.m_Radius * scale;
                newScale = Math.Min(newScale, old.m_Radius * 2);
                newScale = Math.Max(newScale, old.m_Radius * 0.5f);
                Cinemachine.CinemachineFreeLook.Orbit o1 = new Cinemachine.CinemachineFreeLook.Orbit(old.m_Height, newScale);
                this.freeLook.m_Orbits[i] = o1;
            }
        }

        v.x = this.joystick.Horizontal;
        v.z = this.joystick.Vertical;
        if (v.x == 0 && v.z == 0)
        {
            this.animator.SetFloat("runfloat", 0.0f);
            return;
        }
        else
        {
            this.animator.SetFloat("runfloat", 0.2f);
        }
        Vector3 startV3 = new Vector3(this.freeLook.transform.position.x, 0, this.freeLook.transform.position.z);
        Vector3 endV3 = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        Vector3 n = (endV3 - startV3).normalized;
        this.transform.forward = n;
        v = v.normalized;
        Vector3 v3 = this.transform.forward * v.z + this.transform.right * v.x;

        // Vector3 v3 = this.tempgo.transform.forward * v.z + this.tempgo.transform.right * v.x;

        // this.transform.forward = n;

        // Vector3 v3 = this.freeLook.transform.forward * v.z + this.freeLook.transform.right * v.x;

        // Debug.Log(v3);

        this.transform.LookAt(this.transform.position + v3);

        // this.cc.Move(this.transform.position + v3.normalized * speed * Time.deltaTime);

        // this.freeLook.LookAt
        // this.t.RotateAround

        // this.t.position = 

        // Quaternion.AngleAxis

        // Vector3 n1 = n + v;

        // Vector3 v3 = this.freeLook.transform.forward;

        // Vector3 vv = new Vector3(v3.x, 0, v3.y);

        // this.transform.position += v3.normalized * speed * Time.deltaTime;
        this.transform.position += v3 * 0.01f;

        // this.cc.Move((this.transform.position + v3.normalized) * speed * Time.deltaTime);

        // transform.LookAt(transform.position + n);


    }
}
