using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSelectedPointer : MonoBehaviour
{
    [SerializeField] private GameObject selectobject;
    // Use this for initialization
    private void Start()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(selectobject);
    }
    private void OnEnable()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(selectobject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
