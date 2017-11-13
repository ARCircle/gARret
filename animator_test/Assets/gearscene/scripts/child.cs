using UnityEngine;

public class child : MonoBehaviour
{
    public GameObject parents;

    // Use this for initialization
    private void Start()
    {
        parents = transform.parent.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        this.transform.position = parents.transform.position;//ずっと親の位置に追従
    }
}