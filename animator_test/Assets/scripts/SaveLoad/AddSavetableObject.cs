using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddSavetableObject : MonoBehaviour
{
    Rigidbody2D component;
    private void Awake()
    {
        component = GetComponent<Rigidbody2D>();
        if (component != null)
        {
            component.simulated = false;
        }
    }
    // Use this for initialization
    void Start()
    {
        if (component != null)
        {
            component.gameObject.transform.position += new Vector3(0, 1.0f, 0);
            component.simulated = true;
        }
        for (int i = 0; i < SaveManeger.Instance.ImportantPotitionObject.Count(); i++)
        {
            if(SaveManeger.Instance.ImportantPotitionObject[i].name+"(Clone)" ==gameObject.name)
            {
                SaveManeger.Instance.ImportantPotitionObject[i] = gameObject;
            }
        }
    }

}
