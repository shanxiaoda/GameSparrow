import TimerManager from "./Game/TimerManager.mjs";
import UpdateManager from "./Game/UpdateManager.mjs";

export default class App {
    public static updateManager: UpdateManager = new UpdateManager();
    public static timer: TimerManager = new TimerManager();
}