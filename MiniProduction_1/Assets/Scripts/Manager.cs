using UnityEngine;

public abstract class Manager<T> : MonoBehaviour where T : Manager<T>
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        Instance = Instance == null ? this as T : Instance;
        if (Instance != this)
        {
            Destroy(this);
            return;
        }
        onAwake();
    }

    protected virtual void onAwake() { }
}
