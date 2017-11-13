using UnityEngine;
using UnityEngine.UI;

public class SetAudioLevel : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        GetComponent<Slider>().value = transform.parent.GetComponent<AudioVolumeChanger>().GetVolume(this.gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}