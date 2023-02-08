using UnityEngine;
using Puerts;
using System;
public class CSMonoBehaviour : MonoBehaviour
{
    public Action AwakeAction;
    public Action StartAction;
    public Action OnDestroyAction;
    public Action OnDisableAction;
    public Action OnEnableAction;
    public string jsScript;
    void Awake()
    {
        string scriptName;
        if (this.jsScript.EndsWith(".mjs"))
        {
            scriptName = this.jsScript;
        }
        else if (this.jsScript.EndsWith(".mts"))
        {
            scriptName = this.jsScript.Replace(".mts", ".mjs");
        }
        else
        {
            scriptName = this.jsScript + ".mjs";
        }

        JSObject jSObject = App.jsEnvManager.jsEnv.ExecuteModule<JSObject>(scriptName, "default");
        Action<JSObject, CSMonoBehaviour> action = App.jsEnvManager.jsEnv.ExecuteModule<Action<JSObject, CSMonoBehaviour>>("Game/BehaviourManager.mjs", "CreateJsBehaviour");
        action(jSObject, this);
        GameUtils.RunAction(AwakeAction);
    }

    void Start()
    {
        GameUtils.RunAction(StartAction);
    }

    void OnEnable()
    {
        GameUtils.RunAction(OnEnableAction);
    }

    void OnDisable()
    {
        GameUtils.RunAction(OnDisableAction);
    }

    void OnDestroy()
    {
        GameUtils.RunAction(OnDestroyAction);
        this.AwakeAction = null;
        this.StartAction = null;
        this.OnDestroyAction = null;
        this.OnDisableAction = null;
        this.OnEnableAction = null;
    }
}