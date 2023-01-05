export class GameTools {
    constructor() {
        setInterval(() => {
            var GameObject = CS.UnityEngine.GameObject.Find("Cube");
            let a = CS.UnityEngine.Vector3.op_Multiply(CS.UnityEngine.Vector3.one, 0.1);
            GameObject.transform.Rotate(a);
        }, 1000 / 60);
    }
}
export class Utils {
    static getFun(obj, funName) {
        return obj[funName];
    }
    static runFun(obj, funName) {
        if (Utils.haveFun(obj, funName)) {
            return obj[funName]();
        }
        return null;
    }
    static haveFun(obj, funName) {
        return Utils.getFun(obj, funName) != null;
    }
    static handlerByMethodName(caller, methodName) {
        if (Utils.haveFun(caller, methodName)) {
            return () => {
                caller[methodName]();
            };
        }
        else {
            return null;
        }
    }
    static handler(caller, method) {
        return () => {
            return method.apply(caller);
        };
    }
}
