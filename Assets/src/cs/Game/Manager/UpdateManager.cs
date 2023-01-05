using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 分成三个接口 用哪个实现哪个 **/

public interface IUpdate
{
    public void onUpdate();
}

public interface IFixedUpdate
{
    public void onFixedUpdate();
}

public interface ILateUpdate
{
    public void onLateUpdate();
}

enum UpdateType
{
    Update = 1,
    FixedUpdate = 2,
    LateUpdate = 3
}

public class UpdateManager
{
    public void init()
    {
        GameObject gameObject = new GameObject("GameTick");
        gameObject.AddComponent<GameTickBehaviour>();
        GameObject.DontDestroyOnLoad(gameObject);
    }

    private List<IUpdate> updateList = new List<IUpdate>();
    private List<IFixedUpdate> fixedUpdateList = new List<IFixedUpdate>();
    private List<ILateUpdate> lateUpdateList = new List<ILateUpdate>();
    private bool needRemove = false;

    private void _update<T>(List<T> list, UpdateType type)
    {
        if (list.Count == 0)
        {
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            T t = list[i];
            if (t != null)
            {
                if (type == UpdateType.Update)
                {
                    ((IUpdate)t).onUpdate();
                }
                else if (type == UpdateType.FixedUpdate)
                {
                    ((IFixedUpdate)t).onFixedUpdate();
                }
                else if (type == UpdateType.LateUpdate)
                {
                    ((ILateUpdate)t).onLateUpdate();
                }
            }
            else
            {
                this.needRemove = true;
            }
        }
        if (this.needRemove)
        {
            this.needRemove = false;
            list.RemoveAll(e => e == null);
        }
    }

    public void update()
    {
        this._update<IUpdate>(this.updateList, UpdateType.Update);
    }

    public void fixedUpdate()
    {
        this._update<IFixedUpdate>(this.fixedUpdateList, UpdateType.FixedUpdate);
    }

    public void lateUpdate()
    {
        this._update<ILateUpdate>(this.lateUpdateList, UpdateType.LateUpdate);
    }

    private void add<T>(List<T> list, T t)
    {
        if (list.Contains(t) == false)
        {
            list.Add(t);
        }
    }

    private void remove<T>(List<T> list, T t)
    {
        int index = list.IndexOf(t);
        if (index != -1)
        {
            list[index] = default(T);
        }
    }

    public void addUpdate(IUpdate iUpdate)
    {
        this.add<IUpdate>(this.updateList, iUpdate);
    }

    public void removeUpdate(IUpdate iUpdate)
    {
        this.remove<IUpdate>(this.updateList, iUpdate);
    }

    public void addFixedUpdate(IFixedUpdate iFixedUpdate)
    {
        this.add<IFixedUpdate>(this.fixedUpdateList, iFixedUpdate);
    }

    public void removeFixedUpdate(IFixedUpdate iFixedUpdate)
    {
        this.remove<IFixedUpdate>(this.fixedUpdateList, iFixedUpdate);
    }

    public void addLateUpdate(ILateUpdate iLateUpdate)
    {
        this.add<ILateUpdate>(this.lateUpdateList, iLateUpdate);
    }

    public void removeLateUpdate(ILateUpdate iLateUpdate)
    {
        this.remove<ILateUpdate>(this.lateUpdateList, iLateUpdate);
    }
}