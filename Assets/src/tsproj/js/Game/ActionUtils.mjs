import App from "../App.mjs";
import { Utils } from "./GameTools.mjs";
export function setUpdateAction(actionParam) {
    actionParam.updateAction = Utils.handler(App.updateManager, App.updateManager.update);
    actionParam.fixedUpdateAction = Utils.handler(App.updateManager, App.updateManager.fixedUpdate);
    actionParam.lateUpdateAction = Utils.handler(App.updateManager, App.updateManager.lateUpdate);
}
