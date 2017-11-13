using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICrossFade : MonoBehaviour
{
    private Image[] images_Main, images_Menu;
    private TextMeshProUGUI[] texts_Main, texts_Menu;

    [SerializeField]
    private GameObject root_Main, root_Menu;

    // Use this for initialization
    private void Awake()
    {
        root_Menu.SetActive(true);
    }

    private void Start()
    {
        images_Main = root_Main.transform.GetComponentsInChildren<Image>();
        texts_Main = root_Main.transform.GetComponentsInChildren<TextMeshProUGUI>();
        images_Menu = root_Menu.transform.GetComponentsInChildren<Image>();
        texts_Menu = root_Menu.transform.GetComponentsInChildren<TextMeshProUGUI>();
        root_Menu.SetActive(false);
    }

    public void CrossFadeMainToOption()
    {
        CrossFadeFunc(true);
    }

    public void CrossFadeOptionToMain()
    {
        CrossFadeFunc(false);
    }
    private bool finishedProcessIsMain;
    private void CrossFadeFunc(bool isMain)
    {
        finishedProcessIsMain = isMain;
        if (isMain)
        {
            root_Menu.SetActive(true);
        }
        else
        {
            root_Main.SetActive(true);
        }
            foreach (var item in images_Main)
            {
                StartCoroutine(FadeCalc(item,1.0f,isMain));
            }
            foreach (var item in images_Menu)
            {
                 StartCoroutine(FadeCalc(item,1.0f,!isMain));
            }

            foreach (var item in texts_Main)
            {
                 StartCoroutine(FadeCalc(item,1.0f,isMain));
            }
            foreach (var item in texts_Menu)
            {
                 StartCoroutine(FadeCalc(item,1.0f,!isMain));
            }
    }
    void FinieshedProcess()
    {
        if (finishedProcessIsMain)
        {
            root_Main.SetActive(false);
        }
        else
        {
            root_Menu.SetActive(false);
        }
    }
    int CorutineEndCount;
    IEnumerator FadeCalc(Image target,float interval,bool isMain)
    {   
        float  lastRealTime=0,realDeltaTime=0;
//だんだん暗く
        float time = 0;
        Color fadecolor = target.color;
        while (time <= interval)
        {
            fadecolor.a = Mathf.Lerp(isMain ? 1f : 0f,isMain ? 0f : 1f, time / interval);
            target.color = fadecolor;
            if(lastRealTime == 0) {
			lastRealTime = Time.realtimeSinceStartup;
		}
		realDeltaTime = Time.realtimeSinceStartup - lastRealTime;
		lastRealTime = Time.realtimeSinceStartup;
            time += realDeltaTime;
            yield return 0;
        }
        CorutineEndCount++;
        if(CorutineEndCount==4)
        {
            FinieshedProcess();
        CorutineEndCount=0;
        }
    }

        IEnumerator FadeCalc(TMPro.TextMeshProUGUI target,float interval,bool isMain)
    {   float  lastRealTime=0,realDeltaTime=0;
        //だんだん暗く
        float time = 0;
        Color fadecolor = target.color;
        while (time <= interval)
        {
            fadecolor.a = Mathf.Lerp(isMain ? 1f : 0f,isMain ? 0f : 1f, time / interval);
            target.color = fadecolor;
            if(lastRealTime == 0) {
			lastRealTime = Time.realtimeSinceStartup;
		}
		realDeltaTime = Time.realtimeSinceStartup - lastRealTime;
		lastRealTime = Time.realtimeSinceStartup;
            time += realDeltaTime;
            yield return 0;
        }

    }

}