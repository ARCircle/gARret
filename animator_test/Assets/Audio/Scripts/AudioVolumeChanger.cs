using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeChanger : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.Audio.AudioMixer mixer;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetVolume(GameObject target)
    {
        var value = target.GetComponent<Slider>();
        if (value != null)
        {
            mixer.SetFloat(target.name, CalcSetVolume(value.value));
        }
    }

    public float GetVolume(GameObject target)
    {
        float value;
        mixer.GetFloat(target.name, out value);
        return CalcGetVolume(value);
    }

    public static float CalcGetVolume(float value)
    {
        return Mathf.InverseLerp(-40, 10, value);
    }

    public static float CalcSetVolume(float value)
    {
        if (value < 0.01f)
        {
            return -80f;
        }
        else
        {
            return Mathf.Lerp(-40, 10, value);
        }
    }
}