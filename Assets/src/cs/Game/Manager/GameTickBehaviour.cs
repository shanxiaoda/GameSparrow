using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTickBehaviour : MonoBehaviour
{
    public void Update()
    {
        App.jsEnvManager.jsEnv.Tick();
        App.updateManager.update();
        Main.initParam.updateAction();
    }

    public void FixedUpdate()
    {
        App.updateManager.fixedUpdate();
        Main.initParam.fixedUpdateAction();
    }

    public void LateUpdate()
    {
        App.updateManager.lateUpdate();
        Main.initParam.lateUpdateAction();
    }
}
