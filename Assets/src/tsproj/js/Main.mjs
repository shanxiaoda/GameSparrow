import { GameTools } from "./Game/GameTools.mjs";
const GameObject = CS.UnityEngine.GameObject;
new GameTools();
let gameObject = new CS.UnityEngine.GameObject();
gameObject.name = "bbbbb";
GameObject.Destroy(gameObject);
setInterval(() => {
    // console.log(gameObject == null);
    // console.log(CS.GameUtils.IsNull(gameObject));
}, 1000);
function update() {
    // console.log("update");
}
function fixedUpdate() {
    // console.log("fixedUpdate");
}
function lateUpdate() {
    // console.log("lateUpdate");
}
function setInitParameter(initParameter) {
    initParameter.updateAction = update;
    initParameter.fixedUpdateAction = fixedUpdate;
    initParameter.lateUpdateAction = lateUpdate;
}
export { setInitParameter };
