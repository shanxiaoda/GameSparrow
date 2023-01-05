import App from "../App.mjs";
import { Utils } from "./GameTools.mjs";

export function setUpdateAction(actionParam: any): void {
    actionParam.updateAction = Utils.handler(App.updateManager, App.updateManager.update);
    actionParam.fixedUpdateAction = Utils.handler(App.updateManager, App.updateManager.fixedUpdate);
    actionParam.lateUpdateAction = Utils.handler(App.updateManager, App.updateManager.lateUpdate);
}

export const enum BehaviourFunName {
    Update = "Update",
    FixedUpdate = "FixedUpdate",
    LateUpdate = "LateUpdate",
    Awake = "Awake",
    Start = "Start",
    OnEnable = "OnEnable",
    OnDisable = "OnDisable",
    OnDestroy = "OnDestroy"
}