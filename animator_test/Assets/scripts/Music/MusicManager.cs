using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : SingletonMonoBehaviour<MusicManager>
{
    [SerializeField]
    private AudioMixer mixer;

    private void Start()
    {
        var setting = LoadFromJson<SettingData>.Load("/Setting.json");
        if (setting != null)
        {
            var value = AudioVolumeChanger.CalcSetVolume(setting.Master);
            mixer.SetFloat("Master", AudioVolumeChanger.CalcSetVolume(setting.Master));
            mixer.SetFloat("BGM", AudioVolumeChanger.CalcSetVolume(setting.BGM));
            mixer.SetFloat("SE", AudioVolumeChanger.CalcSetVolume(setting.SE));
        }
        else
        {
            setting = new SettingData();
            SaveToJson.Save(setting, "/Setting.json");
        }
    }
}