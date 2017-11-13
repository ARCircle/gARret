using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField]
    private AudioClip se;

    // Use this for initialization
    private void Start()
    {
        #if UNITY_WEBGL
        Destroy(this.gameObject);
        #endif
    }

    private void OnMouseEnter()
    {
        GetComponent<AudioSource>().PlayOneShot(se);
    }

    // Update is called once per frame
    private void OnAppQuit()
    {
        Application.Quit();
    }
}