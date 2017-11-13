using System.Collections.Generic;
using UnityEngine;

public class SceneActiveControl : MonoBehaviour
{
    private List<GameObject> children = new List<GameObject>();
    private bool activateState = true;

    public bool ActivateState
    {
        get
        {
            return activateState;
        }

        set
        {
            activateState = value;
        }
    }

    // Use this for initialization
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }
        var data = LoadFromJson<SettingData>.Load("/Setting.json");
        if(data == null)
        {
            data = new SettingData();
        }
        var ison = data.isGearCounterEnabled;

		ActivateState = ison;
		Activatechildren(false);
    }

    // Update is called once per frame
	private bool preActivateState,PreRejectionScene,RejectionScene;

    private void Update()
    {
        var ischanged = preActivateState ^ ActivateState;
		RejectionScene = DeniedSceneList.RejectionDetection ();
		var rejectSceneChanged = PreRejectionScene ^ RejectionScene;
		if (ischanged & !RejectionScene)
        {
            Activatechildren(ActivateState);
        }
		if (rejectSceneChanged & !RejectionScene) 
		{
			Activatechildren(ActivateState);
		}
		if (RejectionScene) 
		{
			Activatechildren(false);
		}
			
        preActivateState = ActivateState;
		PreRejectionScene = RejectionScene;
    }

    private void Activatechildren(bool isOn)
    {
        if (children != null)
        {
            foreach (var local in children)
            {
                local.SetActive(isOn);
            }
        }
    }
}