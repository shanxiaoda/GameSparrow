using UnityEngine;

public class TestMonoBehaviour2 : MonoBehaviour, IUpdate
{
    private void Start()
    {
        UnityEngine.Debug.Log(" test start ");
        App.updateManager.addUpdate(this);
    }

    private int a = 0;
    public void onUpdate()
    {
        a++;
        if (a == 6)
        {
            App.updateManager.removeUpdate(this);
        }
        UnityEngine.Debug.Log("test 2");
    }
}