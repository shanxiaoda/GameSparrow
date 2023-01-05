using UnityEngine;

public class TestMonoBehaviour : MonoBehaviour, IUpdate
{
    private void Start()
    {
        App.updateManager.addUpdate(this);
    }

    private int a = 0;
    public void onUpdate()
    {
        a++;
        if (a == 3)
        {
            App.updateManager.removeUpdate(this);
        }
        UnityEngine.Debug.Log("test 1");
    }
}