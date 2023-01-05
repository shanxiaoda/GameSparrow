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
    public static getFun(obj: any, funName: string): any {
        return obj[funName];
    }

    public static runFun(obj: any, funName: string): any {
        if (Utils.haveFun(obj, funName)) {
            return obj[funName]();
        }
        return null;
    }

    public static haveFun(obj: any, funName: string): boolean {
        return Utils.getFun(obj, funName) != null;
    }

    public static handlerByMethodName(caller: any, methodName: string): any {
        if (Utils.haveFun(caller, methodName)) {
            return () => {
                caller[methodName]();
            }
        } else {
            return null;
        }
    }

    public static handler(caller: any, method: any): any {
        return () => {
            return method.apply(caller);
        }
    }
}