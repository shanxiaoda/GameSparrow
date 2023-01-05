import { BehaviourFunName } from "./ActionUtils.mjs";
import { Utils } from "./GameTools.mjs";
import JsBehaviour from "./JsBehaviour.mjs";

export default class UpdateManager {
    constructor() {

    }

    private updateList: Array<JsBehaviour> = [];
    private fixedUpdateList: Array<JsBehaviour> = [];
    private lateUpdateList: Array<JsBehaviour> = [];

    private needRemove: boolean = false;

    private _update(list: Array<JsBehaviour>, funName: string): void {
        for (let i = 0; i < list.length; i++) {
            let jsBehaviour = list[i];
            if (jsBehaviour) {
                Utils.runFun(jsBehaviour, funName);
            } else {
                this.needRemove = true;
            }
        }
        //移除多个时 为了避免多次后面数据补位 手动移动后面的数据
        if (this.needRemove) {
            this.needRemove = false;
            let removeCount: number = 0;
            for (let i = 0; i < list.length; i++) {
                let item = list[i];
                if (item == null) {
                    removeCount++;
                } else {
                    if (removeCount > 0) {
                        list[i - removeCount] = item;
                        list[i] = null;
                    }
                }
            }
            list.splice(list.length - removeCount);
        }
    }

    public update(): void {
        this._update(this.updateList, BehaviourFunName.Update);
    }

    public fixedUpdate(): void {
        this._update(this.fixedUpdateList, BehaviourFunName.FixedUpdate);
    }

    public lateUpdate(): void {
        this._update(this.lateUpdateList, BehaviourFunName.LateUpdate);
    }

    private add(jsBehaviour: JsBehaviour, list: Array<JsBehaviour>): void {
        if (list.includes(jsBehaviour) == false) {
            list.push(jsBehaviour);
        }
    }

    private remove(jsBehaviour: JsBehaviour, list: Array<JsBehaviour>): void {
        let i = list.indexOf(jsBehaviour);
        if (i != -1) {
            list[i] = null;
        }
    }

    public addUpdate(jsBehaviour: JsBehaviour): void {
        this.add(jsBehaviour, this.updateList);
    }

    public removeUpdate(jsBehaviour: JsBehaviour): void {
        this.remove(jsBehaviour, this.updateList);
    }

    public addFixedUpdate(jsBehaviour: JsBehaviour): void {
        this.add(jsBehaviour, this.fixedUpdateList);
    }

    public removeFixedUpdate(jsBehaviour: JsBehaviour): void {
        this.remove(jsBehaviour, this.fixedUpdateList);
    }

    public addLateUpdate(jsBehaviour: JsBehaviour): void {
        this.add(jsBehaviour, this.lateUpdateList);
    }

    public removeLateUpdate(jsBehaviour: JsBehaviour): void {
        this.remove(jsBehaviour, this.lateUpdateList);
    }
}