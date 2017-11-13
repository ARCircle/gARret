using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingManager : SingletonMonoBehaviour<SettingManager>
{
    [SerializeField]
    Slider Master, BGM, SE;
    [SerializeField]
    Toggle isGearCounterEnabled;
	// Use this for initialization
    void Start ()
    {
        var settingdata = LoadFromJson<SettingData>.Load("/Setting.json");
        if(settingdata != null)
        {
            Master.value = settingdata.Master;
            BGM.value = settingdata.BGM;
            SE.value = settingdata.SE;
            isGearCounterEnabled.isOn = settingdata.isGearCounterEnabled;
        }
    }

    private void ReturnToEscMainMenu()
    {
        SettingData settingdata = new SettingData()
        {
            Master = Master.value,
            BGM = BGM.value,
            SE = SE.value,
            isGearCounterEnabled = isGearCounterEnabled.isOn
        };
        SaveToJson.Save(settingdata, "/Setting.json");
    }
}
