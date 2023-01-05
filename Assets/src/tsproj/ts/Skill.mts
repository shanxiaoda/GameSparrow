import JsBehaviour from "./Game/JsBehaviour.mjs";

export default class Skill extends JsBehaviour {
    constructor() {
        super();
        console.log("new skill");
    }

    // public Awake(): void {
    //     console.log("this is skill awake");
    // }

    public Update(): void {
        // console.log("skill update");
        let v3 = CS.UnityEngine.Vector3.op_Multiply(CS.UnityEngine.Vector3.one, 0.7);
        this.gameObject.transform.Rotate(v3);
    }

    public OnEnable(): void {
        console.log("OnEnable");
        let go: CS.UnityEngine.GameObject = null;
        // go.transform;
        // CS.System.type
        // puerts.evalScript
        console.log(puerts.$typeof(CS.UnityEngine.GameObject));
    }

    public OnDisable(): void {
        console.log("OnDisable");
    }
}