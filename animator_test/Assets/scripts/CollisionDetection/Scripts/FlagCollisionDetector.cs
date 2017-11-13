using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollisionDetector : MonoBehaviour
{

    private SaveManeger savemaneger;

    [SerializeField]
    private string flag;

    // Use this for initialization
    private void Start()
    {
        if (SaveManeger.Instance != null)
        {
            savemaneger = SaveManeger.Instance;
        }
        if (savemaneger.GetFlag(flag))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (savemaneger.GetFlag(flag))
        {
            Destroy(this.gameObject);
        }
    }
}
