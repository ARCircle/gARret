using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSporn : MonoBehaviour
{
    public GameObject box;
    private GameObject prefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (prefab == null)
        {
            var instanced = GameObject.Find(box.name + "(Clone)");
            if (instanced ==null)
            {
                prefab = Instantiate(box, this.transform.position + new Vector3(-2.5f, 0, 0), this.transform.rotation);
            }
            else
            {
                prefab = instanced;
                prefab.transform.position = this.transform.position + new Vector3(-2.5f, 0, 0);
                prefab.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        else
        {
            prefab.transform.position = this.transform.position + new Vector3(-2.5f, 0, 0);
        }
    }
}