using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        // freeLook.

        var fingers = Use.UpdateAndGetFingers();

        // scalego.transform.localScale *= Lean.Touch.LeanGesture.GetPinchScale(fingers);

        // Cinemachine.CinemachineFreeLook.Orbit o = this.freeLook.m_Orbits[1];

        // this.freeLook.m_Lens.FieldOfView *= Lean.Touch.LeanGesture.GetPinchScale(fingers);

        // Debug.Log(this.freeLook.m_Lens.FieldOfView  );
        Cinemachine.CinemachineFreeLook.Orbit o = this.freeLook.m_Orbits[1];
        o.m_Radius *= Lean.Touch.LeanGesture.GetPinchScale(fingers);
        // this.freeLook.m_Orbits[1] = o;

        Cinemachine.CinemachineFreeLook.Orbit o1 = new Cinemachine.CinemachineFreeLook.Orbit(o.m_Height, o.m_Radius);
        this.freeLook.m_Orbits[1] = o1;

       

        // Debug.Log(this.freeLook.m_Orbits[0]);

        // this.freeLook.UpdateInputAxisProvider();

        // Vector3 v = new Vector3(this.joystick.Horizontal, 0, this.joystick.Vertical);
        // transform.LookAt(transform.position + v);
        v.x = this.joystick.Horizontal;
        v.z = this.joystick.Vertical;
        if (v.x == 0 && v.z == 0)
        {
            // this.animator.SetInteger("runint", 0);
            // this.animator.SetFloat("runfloat", 0.0f);
            // this.animator.SetTrigger("stop");
            // Debug.Log("aaaaaaaaaaa22222222222222222");
            // Debug.Log("stop");

            this.animator.SetFloat("runfloat", 0.0f);
            return;
        }
        else
        {
            // Debug.Log(this.animator.GetCurrentAnimatorStateInfo(0).IsName("Ellen_Run_Forward"));
            // Debug.Log("aaaaaaaaaaa");
            // if (this.animator.GetInteger("runint") == 0)
            // {
            // this.animator.SetTrigger("run");
            // this.animator.SetInteger("runint", 1);
            // this.animator.SetFloat("runfloat", 1.0f);
            // Debug.Log("aaaaaaaaaaa");
            // }
            this.animator.SetFloat("runfloat", 0.2f);
            // Debug.Log("run");
        }
        // Debug.Log( v.x );

        // this.t = Transform.Instantiate();

        // transform.LookAt(transform.position + v);

        // transform.LookAt(joystick.Direction);

        // transform.position += v * speed * Time.deltaTime;
        Vector3 startV3 = new Vector3(this.freeLook.transform.position.x, 0, this.freeLook.transform.position.z);
        Vector3 endV3 = new Vector3(this.transform.position.x, 0, this.transform.position.z);

        Vector3 n = (endV3 - startV3).normalized;

        // this.t.position.x = this.freeLook.transform.position.x;
        // this.t.position = this.transform.position;

        //  this.freeLook.transform.forward = n;
        // this.tempgo.transform.position = this.transform.position;
        // this.tempgo.transform.forward = n;


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
