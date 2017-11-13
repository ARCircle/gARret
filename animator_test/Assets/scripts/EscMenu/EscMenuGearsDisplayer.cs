using System.Collections.Generic;
using UnityEngine;

public class EscMenuGearsDisplayer : MonoBehaviour
{
    private List<GameObject> gearList;

    // Use this for initialization
    private void Start()
    {
        var count = transform.childCount;
        if (Player.Instance != null)
        {
            for (int i = 0; i < Player.Instance.gearManeger.Gears.Count; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
