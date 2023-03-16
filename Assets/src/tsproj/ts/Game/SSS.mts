import { Debug } from "../Type.mjs";
import UI_SSS from "../UI/Game/UI_SSS.mjs";

export default class SSS extends UI_SSS {
    constructor() {
        super();
    }

    public Update(): void {
        // Debug.Log("ccccccccc");
        // this.lbl1_TextMeshProUGUI.text = "dddddadcasdfsadf";
        // this.Img1;
        // new GameObject();
        // let a = new GameObject();
        //  new GameObject();
        // Debug.Log(this.Img1);
    }

    public OnEnable(): void {
        this.aaa1();
    }

    public aaa1(): void {
        this.aaa2();
    }

    public aaa2(): void {
        this.aaa3();
    }

    public aaa3(): void {
        this.aaa4();
    }

    public aaa4(): void {
        this.aaa5();
    }

    public aaa5(): void {
        this.aaa6();
    }

    public aaa6(): void {
        let an:any = this;
        let aa: any = an["aaaa" + "eee"];
        let ac = aa.game1.trans;
    }
}