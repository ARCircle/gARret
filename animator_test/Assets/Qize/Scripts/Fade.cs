using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Animator animator;
    public GameObject[] questions;

    private List<Animator> anims = new List<Animator>();

    // Use this for initialization
    private void Start()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(transform.GetChild(0).gameObject);
        foreach (var local in questions)
        {
            anims.Add(local.GetComponent<Animator>());
        }
        foreach (var local in anims)
        {
            local.SetTrigger("clicked");
        }
    }
}