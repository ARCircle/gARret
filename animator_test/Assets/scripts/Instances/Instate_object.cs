using UnityEngine;

public class Instate_object : MonoBehaviour
{
    [SerializeField]
    private GameObject gear;

    // Use this for initialization
    private void Start()
    {
        Instantiate(gear, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}