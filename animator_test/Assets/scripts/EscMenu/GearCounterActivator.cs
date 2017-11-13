using UnityEngine;
using UnityEngine.UI;

public class GearCounterActivator : MonoBehaviour
{
    private Toggle toggle;
    private SceneActiveControl gearcounter;

    // Use this for initialization
    private void Start()
    {
        toggle = transform.GetComponentInChildren<Toggle>();
        var SceneActiveControls = FindObjectsOfType<SceneActiveControl>();
        for (int i = 0; i < SceneActiveControls.Length; i++)
        {
            if (SceneActiveControls[i].gameObject.name == "GearCount")
            {
                gearcounter = SceneActiveControls[i];
            }
        }
        var ison = LoadFromJson<SettingData>.Load("/Setting.json");
        if (ison == null)
        {
            ison = new SettingData();
        }
        if (ison != null&& gearcounter!=null)
        {
            gearcounter.ActivateState = ison.isGearCounterEnabled;
        }
        
        if (gearcounter != null)
        {
            toggle.isOn = gearcounter.transform.GetChild(0).gameObject.activeInHierarchy;
        }
        else
        {
            throw new System.NullReferenceException();
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ToggleChanged()
    {
        if (gearcounter != null)
        {
            gearcounter.ActivateState = toggle.isOn;
        }
        else
        {
            throw new System.NullReferenceException();
        }
    }
}