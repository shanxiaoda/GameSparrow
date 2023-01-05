export function CreateJsBehaviour(JsBehaviourClass, csMonoBehaviour) {
    let jsBehaviour = new JsBehaviourClass();
    jsBehaviour.setCSMonoBehaviour(csMonoBehaviour);
}
