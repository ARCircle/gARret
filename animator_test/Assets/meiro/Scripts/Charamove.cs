using UnityEngine;

public class Charamove : MonoBehaviour
{
    private Rigidbody2D ridgid;

    // Use this for initialization
    private void Start()
    {
        ridgid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
            ridgid.AddForceAtPosition(new Vector2(UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Horizontal"), UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Vertical")), this.transform.position += new Vector3(UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Horizontal")*(Screen.width/500), UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Vertical")*(Screen.height / 250), 0));
    }
}