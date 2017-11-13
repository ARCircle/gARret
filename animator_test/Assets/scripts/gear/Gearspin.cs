using UnityEngine;

public class Gearspin : MonoBehaviour
{
    [SerializeField]
    bool isrightrotate;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (isrightrotate)
        {
            transform.Rotate(0, 0, 0.3f);
        }
        else
        {
            transform.Rotate(0, 0, -0.3f);
        }

    }
}