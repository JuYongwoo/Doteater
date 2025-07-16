using UnityEngine;

public class ManagerObject : MonoBehaviour
{
    static ManagerObject s_instance;
    static ManagerObject Instance { get { Init(); return s_instance; } }


    #region Core
    private InputManager _input = new InputManager();
    private PoolManager _pool = new PoolManager();
    private ResourceManager _resource = new ResourceManager();

    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
	#endregion

	void Start()
    {
        Screen.SetResolution(1600, 900, false);

        Init();
	}

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
			GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<ManagerObject>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<ManagerObject>();

            s_instance._pool.Init();
        }		
	}

    public static void Clear()
    {
        Input.Clear();
        Pool.Clear();
    }
}
