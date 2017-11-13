using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public static bool isDebug = true;

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(this);
        if (!Debug.isDebugBuild)
        {
            //Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isDebug = !isDebug;
        }
    }
}