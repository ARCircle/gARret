using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WebGLVideooLoader : MonoBehaviour
{
    [SerializeField] string url;
    // Use this for initialization
    void Start()
    {
/*#if UNITY_WEBGL
        GetComponent<VideoPlayer>().source = VideoSource.Url;
        GetComponent<VideoPlayer>().url = url;
#endif*/

    }
}
