export function Init(): void {
    if (CS.UnityEngine.Application.isEditor) {
       puer.require("puerts/console-track");
       puer.require("puerts/puerts-source-map-support");
    }
}