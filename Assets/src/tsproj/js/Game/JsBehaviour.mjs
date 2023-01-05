import App from "../App.mjs";
import { Utils } from "./GameTools.mjs";
/**
 * update等可以随时开关
 */
export default class JsBehaviour {
    constructor() {
    }
    _OnEnable() {
        this.startUpdate();
        this.startFixedUpdate();
        this.startLateUpdate();
        //玩家可能没实现OnEnable 只实现了update runFun里会过滤掉
        Utils.runFun(this, "OnEnable" /* BehaviourFunName.OnEnable */);
    }
    _OnDisable() {
        this.stopUpdate();
        this.stopFixedUpdate();
        this.stopLateUpdate();
        Utils.runFun(this, "OnDisable" /* BehaviourFunName.OnDisable */);
    }
    startUpdate() {
        if (Utils.haveFun(this, "Update" /* BehaviourFunName.Update */)) {
            App.updateManager.addUpdate(this);
        }
    }
    stopUpdate() {
        if (Utils.haveFun(this, "Update" /* BehaviourFunName.Update */)) {
            App.updateManager.removeUpdate(this);
        }
    }
    startFixedUpdate() {
        if (Utils.haveFun(this, "FixedUpdate" /* BehaviourFunName.FixedUpdate */)) {
            App.updateManager.addFixedUpdate(this);
        }
    }
    stopFixedUpdate() {
        if (Utils.haveFun(this, "FixedUpdate" /* BehaviourFunName.FixedUpdate */)) {
            App.updateManager.removeFixedUpdate(this);
        }
    }
    startLateUpdate() {
        if (Utils.haveFun(this, "LateUpdate" /* BehaviourFunName.LateUpdate */)) {
            App.updateManager.addLateUpdate(this);
        }
    }
    stopLateUpdate() {
        if (Utils.haveFun(this, "LateUpdate" /* BehaviourFunName.LateUpdate */)) {
            App.updateManager.removeLateUpdate(this);
        }
    }
    _gameObject = null;
    get gameObject() {
        if (this._gameObject == null) {
            this._gameObject = this.csMonoBehaviour.gameObject;
        }
        return this._gameObject;
    }
    _transform = null;
    get transform() {
        if (this._transform == null) {
            this._transform = this.csMonoBehaviour.transform;
        }
        return this._transform;
    }
    csMonoBehaviour = null;
    setCSMonoBehaviour(csMonoBehaviour) {
        this.csMonoBehaviour = csMonoBehaviour;
        if (Utils.haveFun(this, "Awake" /* BehaviourFunName.Awake */)) {
            csMonoBehaviour.AwakeAction = Utils.handlerByMethodName(this, "Awake" /* BehaviourFunName.Awake */);
        }
        if (Utils.haveFun(this, "Start" /* BehaviourFunName.Start */)) {
            csMonoBehaviour.StartAction = Utils.handlerByMethodName(this, "Start" /* BehaviourFunName.Start */);
        }
        if (Utils.haveFun(this, "OnDestroy" /* BehaviourFunName.OnDestroy */)) {
            csMonoBehaviour.OnDestroyAction = Utils.handlerByMethodName(this, "OnDestroy" /* BehaviourFunName.OnDestroy */);
        }
        let haveUpdate = Utils.haveFun(this, "Update" /* BehaviourFunName.Update */) || Utils.haveFun(this, "FixedUpdate" /* BehaviourFunName.FixedUpdate */) || Utils.haveFun(this, "LateUpdate" /* BehaviourFunName.LateUpdate */);
        if (haveUpdate || Utils.haveFun(this, "OnEnable" /* BehaviourFunName.OnEnable */)) {
            csMonoBehaviour.OnEnableAction = Utils.handlerByMethodName(this, "_" + "OnEnable" /* BehaviourFunName.OnEnable */);
        }
        if (haveUpdate || Utils.haveFun(this, "OnDisable" /* BehaviourFunName.OnDisable */)) {
            csMonoBehaviour.OnDisableAction = Utils.handlerByMethodName(this, "_" + "OnDisable" /* BehaviourFunName.OnDisable */);
        }
    }
}
