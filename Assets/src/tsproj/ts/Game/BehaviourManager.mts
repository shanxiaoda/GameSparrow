import JsBehaviour from "./JsBehaviour.mjs";

export function CreateJsBehaviour(JsBehaviourClass: any, csMonoBehaviour: any): void {
    let jsBehaviour: JsBehaviour = new JsBehaviourClass();
    jsBehaviour.setCSMonoBehaviour(csMonoBehaviour);
}