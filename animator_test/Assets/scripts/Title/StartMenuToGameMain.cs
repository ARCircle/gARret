using System;
using System.IO;
using UnityEngine;

public class StartMenuToGameMain : MonoBehaviour
{
    public AudioClip se;

    private void OnMouseEnter()
    {
        GetComponent<AudioSource>().PlayOneShot(se);
    }

    // Use this for initialization
    private void ClickandRun_first()
    {
        try
        {
#if UNITY_STANDALONE
            File.Delete(Application.dataPath + "/SaveData.json");
		
#else
            PlayerPrefs.DeleteKey("/SaveData.json");

#endif

        }
        catch (Exception e)
        {
            Debug.Log("通らないで(祈り)" + "Error" + e.ToString());
        }
        FadeManager.Instance.LoadScene("Op_Movie", 3.0f);
    }

    private void ClickandRun_Continue()
    {
        FadeManager.Instance.LoadScene(LoadFromJson<SaveData>.Load().SceneName, 1.0f);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}