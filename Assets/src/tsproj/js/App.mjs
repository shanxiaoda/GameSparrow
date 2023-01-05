import TimerManager from "./Game/TimerManager.mjs";
import UpdateManager from "./Game/UpdateManager.mjs";
export default class App {
    static updateManager = new UpdateManager();
    static timer = new TimerManager();
    constructor() {
    }
}
