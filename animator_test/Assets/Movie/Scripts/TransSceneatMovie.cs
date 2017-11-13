using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class TransSceneatMovie : MonoBehaviour
{
    private VideoPlayer player;
    private int i, j;

    [SerializeField]
    private string Scene;

    [SerializeField]
    private float BeginFadeTime;

    private bool isTriggered;

    // Use this for initialization
    private void Start()
    {
        player = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.isPlaying != true)
        {
            i += 2;
        }
        else if (UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButton("Intractive") || Input.GetMouseButton(0))
        {
            j += 2;
        }
        if (i > 0)
        {
            i--;
        }
        if (j > 0)
        {
            j--;
        }
        if (i > 10)
        {
            StartCoroutine(LoadStage(BeginFadeTime));
        }
        if (j > 10)
        {
            StartCoroutine(LoadStage(0.0f));
        }
    }

    private IEnumerator LoadStage(float FadeTime)
    {
        if (!isTriggered)
        {
            isTriggered = true;
            yield return new WaitForSeconds(FadeTime);
            FadeManager.Instance.LoadScene(Scene, 1.0f);
        }
    }
}