using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    private Image image;
    private float alpha = 1.0f;
    public bool isenable;
    // Use this for initialization
    private void Start()
    {
        image = this.GetComponent<Image>();
        try
        {
            EscManager.Instance.FadeEvent.Add(FadeInOutFunc(0.5f,false));
        }
        catch
        {
        }
        if (isenable)
        {
            StartCoroutine(FadeInOutFunc(0.5f,true));
        }
    }

    private IEnumerator FadeInOutFunc(float interval,bool isFadeIn)
    {
        float time = 0; 
        float  lastRealTime=0,realDeltaTime=0;
        var fadecolor = new Color(image.color.r, image.color.g, image.color.b, 0);
        image.color = fadecolor;
        while (time <= interval)
        {
            fadecolor.a = Mathf.Lerp(isFadeIn ? 0f : 1f,isFadeIn ? 1f : 0f, time / interval);
            image.color = fadecolor;
            if(lastRealTime == 0) 
            {
			    lastRealTime = Time.realtimeSinceStartup;
		    }
		    realDeltaTime = Time.realtimeSinceStartup - lastRealTime;
		    lastRealTime = Time.realtimeSinceStartup;
            time += realDeltaTime;
            yield return 0;
        }
    }


    // Update is called once per frame
    private void Update()
    {
    }
}