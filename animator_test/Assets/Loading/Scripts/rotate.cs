using UnityEngine;

public class rotate : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 euler = transform.localEulerAngles;
        euler.z += 2f;
        transform.localEulerAngles = euler;
    }
}