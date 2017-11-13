using UnityEngine;

public class GearCounter : MonoBehaviour
{
    private Rect Pos = new Rect(10, 10, 100, 100);

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void OnGUI()
    {
        if (DebugManager.isDebug)
        {
            int count = Player.Instance != null ? Player.Instance.gearManeger.Gears.Count : 0;
            GUIStyle style = new GUIStyle();
            style.fontSize = 10;
            GUI.Label(Pos, count.ToString(), style);
        }
    }
}