import { Utils } from "./GameTools.mjs";
export default class UpdateManager {
    constructor() {
    }
    updateList = [];
    fixedUpdateList = [];
    lateUpdateList = [];
    needRemove = false;
    _update(list, funName) {
        for (let i = 0; i < list.length; i++) {
            let jsBehaviour = list[i];
            if (jsBehaviour) {
                Utils.runFun(jsBehaviour, funName);
            }
            else {
                this.needRemove = true;
            }
        }
        //移除多个时 为了避免多次后面数据补位 手动移动后面的数据
        if (this.needRemove) {
            this.needRemove = false;
            let removeCount = 0;
            for (let i = 0; i < list.length; i++) {
                let item = list[i];
                if (item == null) {
                    removeCount++;
                }
                else {
                    if (removeCount > 0) {
                        list[i - removeCount] = item;
                        list[i] = null;
                    }
                }
            }
            list.splice(list.length - removeCount);
        }
    }
    update() {
        this._update(this.updateList, "Update" /* BehaviourFunName.Update */);
    }
    fixedUpdate() {
        this._update(this.fixedUpdateList, "FixedUpdate" /* BehaviourFunName.FixedUpdate */);
    }
    lateUpdate() {
        this._update(this.lateUpdateList, "LateUpdate" /* BehaviourFunName.LateUpdate */);
    }
    add(jsBehaviour, list) {
        if (list.includes(jsBehaviour) == false) {
            list.push(jsBehaviour);
        }
    }
    remove(jsBehaviour, list) {
        let i = list.indexOf(jsBehaviour);
        if (i != -1) {
            list[i] = null;
        }
    }
    addUpdate(jsBehaviour) {
        this.add(jsBehaviour, this.updateList);
    }
    removeUpdate(jsBehaviour) {
        this.remove(jsBehaviour, this.updateList);
    }
    addFixedUpdate(jsBehaviour) {
        this.add(jsBehaviour, this.fixedUpdateList);
    }
    removeFixedUpdate(jsBehaviour) {
        this.remove(jsBehaviour, this.fixedUpdateList);
    }
    addLateUpdate(jsBehaviour) {
        this.add(jsBehaviour, this.lateUpdateList);
    }
    removeLateUpdate(jsBehaviour) {
        this.remove(jsBehaviour, this.lateUpdateList);
    }
}
