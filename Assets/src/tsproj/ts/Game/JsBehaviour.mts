import App from "../App.mjs";
import { BehaviourFunName } from "./ActionUtils.mjs";
import { Utils } from "./GameTools.mjs";


/**
 * update等可以随时开关
 */
export default class JsBehaviour {
    constructor() {

    }

    public _OnEnable(): void {
        this.startUpdate();
        this.startFixedUpdate();
        this.startLateUpdate();
        //玩家可能没实现OnEnable 只实现了update runFun里会过滤掉
        Utils.runFun(this, BehaviourFunName.OnEnable);
    }

    public _OnDisable(): void {
        this.stopUpdate();
        this.stopFixedUpdate();
        this.stopLateUpdate();
        Utils.runFun(this, BehaviourFunName.OnDisable);
    }

    public startUpdate(): void {
        if (Utils.haveFun(this, BehaviourFunName.Update)) {
            App.updateManager.addUpdate(this);
        }
    }

    public stopUpdate(): void {
        if (Utils.haveFun(this, BehaviourFunName.Update)) {
            App.updateManager.removeUpdate(this);
        }
    }

    public startFixedUpdate(): void {
        if (Utils.haveFun(this, BehaviourFunName.FixedUpdate)) {
            App.updateManager.addFixedUpdate(this);
        }
    }

    public stopFixedUpdate(): void {
        if (Utils.haveFun(this, BehaviourFunName.FixedUpdate)) {
            App.updateManager.removeFixedUpdate(this);
        }
    }

    public startLateUpdate(): void {
        if (Utils.haveFun(this, BehaviourFunName.LateUpdate)) {
            App.updateManager.addLateUpdate(this);
        }
    }

    public stopLateUpdate(): void {
        if (Utils.haveFun(this, BehaviourFunName.LateUpdate)) {
            App.updateManager.removeLateUpdate(this);
        }
    }

    private _gameObject: CS.UnityEngine.GameObject = null;

    public get gameObject(): CS.UnityEngine.GameObject {
        if (this._gameObject == null) {
            this._gameObject = this.csMonoBehaviour.gameObject;
        }
        return this._gameObject;
    }

    private _transform: CS.UnityEngine.Transform = null;

    public get transform(): CS.UnityEngine.Transform {
        if (this._transform == null) {
            this._transform = this.csMonoBehaviour.transform;
        }
        return this._transform;
    }

    public csMonoBehaviour: any = null;

    public setCSMonoBehaviour(csMonoBehaviour: any): void {
        this.csMonoBehaviour = csMonoBehaviour;
        if (Utils.haveFun(this, BehaviourFunName.Awake)) {
            csMonoBehaviour.AwakeAction = Utils.handlerByMethodName(this, BehaviourFunName.Awake);
        }
        if (Utils.haveFun(this, BehaviourFunName.Start)) {
            csMonoBehaviour.StartAction = Utils.handlerByMethodName(this, BehaviourFunName.Start);
        }
        if (Utils.haveFun(this, BehaviourFunName.OnDestroy)) {
            csMonoBehaviour.OnDestroyAction = Utils.handlerByMethodName(this, BehaviourFunName.OnDestroy);
        }
        let haveUpdate: boolean = Utils.haveFun(this, BehaviourFunName.Update) || Utils.haveFun(this, BehaviourFunName.FixedUpdate) || Utils.haveFun(this, BehaviourFunName.LateUpdate);
        if (haveUpdate || Utils.haveFun(this, BehaviourFunName.OnEnable)) {
            csMonoBehaviour.OnEnableAction = Utils.handlerByMethodName(this, "_" + BehaviourFunName.OnEnable);
        }
        if (haveUpdate || Utils.haveFun(this, BehaviourFunName.OnDisable)) {
            csMonoBehaviour.OnDisableAction = Utils.handlerByMethodName(this, "_" + BehaviourFunName.OnDisable);
        }

        let pList: CS.System.Array$1<CS.TSProperties.ResultPair> = csMonoBehaviour.Pairs;
        for (let i = 0; i < pList.Length; i++) {
            let p: CS.TSProperties.ResultPair = pList.get_Item(i);
            let thisObj: any = this;
            thisObj[p.key] = p.value;
        }
    }
}