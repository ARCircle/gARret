using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// シーン遷移時のフェードイン・アウトを制御するためのクラス
/// </summary>
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasScaler))]
[RequireComponent(typeof(Image))]
public class FadeManager : SingletonMonoBehaviour<FadeManager>
{
  
     
    /// <summary>暗転用テクスチャ</summary>
    private static Texture2D fadeTexture;

    private static Color fadeColor = Color.black;

    /// <summary>フェード中の透明度</summary>
	private static float fadeAlpha = 0;

    /// <summary>フェード中かどうか</summary>
	private static bool isFading = false;

    private string beforeScene;
    private string nowScene;
    public string BeforeScene
    {
        get
        {
            return beforeScene;
        }
    }

    public string NowScene
    {
        get
        {
            return nowScene;
        }
    }
    private static bool isStarted;
    private Image image;
    override protected void Awake()
    {
        base.Awake();
        if(string.IsNullOrEmpty(nowScene))
        {
            nowScene = SceneManager.GetActiveScene().name;
        }
    }
    private void Start()
    {
        //ここで黒テクスチャ作る
        fadeTexture = new Texture2D(Screen.width*10, Screen.height*10, TextureFormat.RGB24, false);
        fadeTexture.SetPixel(0, 0, Color.white);
        fadeTexture.Apply();
        image = GetComponent<Image>();
        image.sprite = Sprite.Create(fadeTexture,new Rect(0,0,Screen.width*10,Screen.height*10),new Vector2(0.5f,0.5f));
        image.enabled = false;
    }
    private void Update()
    {
        if (!isFading)
            return;

        //透明度を更新して黒テクスチャを描画
        fadeColor.a = fadeAlpha;
        image.color = fadeColor;
    }

    /*private void OnGUI()
    {
        if (!isFading)
            return;

        //透明度を更新して黒テクスチャを描画
        fadeColor.a = fadeAlpha;
        GUI.color = fadeColor;
        GUI.DrawTexture(display, Texture2D.whiteTexture);
}*/

    /// <summary>
    /// 画面遷移
    /// </summary>
    /// <param name='scene'>シーン名</param>
    /// <param name='interval'>暗転にかかる時間(秒)</param>
	public void LoadScene(string scene, float interval)
    {
        //GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SaveScene();
        if (!isStarted)
        {
            isStarted = true;
            image.enabled = true;
            StartCoroutine(TransScene(scene, interval));
        }
    }

    public void LoadScene(Scene scene, float interval)
    {
        LoadScene(scene.name, interval);
    }

    public void LoadScene(string scene, float interval, Color color)
    {
        if (!isStarted)
        {
            var Precolor = fadeColor;
            ChangeFadeColor(color);
            LoadScene(scene, interval);
            ChangeFadeColor(Precolor);
        }
    }

    /// <summary>
    /// シーン遷移用コルーチン
    /// </summary>
    /// <param name='scene'>シーン名</param>
    /// <param name='interval'>暗転にかかる時間(秒)</param>
    private IEnumerator TransScene(string scene, float interval)
    {
        //だんだん暗く
        isFading = true;
        float time = 0;
        while (time <= interval)
        {
            fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }
        //シーン切替
        var beforeScenename = SceneManager.GetActiveScene().name;
        beforeScene = beforeScenename;
        nowScene = scene;

        SceneManager.LoadScene("NowLoading");
        yield return null;
        fadeAlpha = 0;
        var index = SceneManager.GetSceneByName(scene).buildIndex;
        if (index != -1)
        {
            yield return SceneManager.LoadSceneAsync(index);
        }
        else
        {
            yield return SceneManager.LoadSceneAsync(scene);
        }
        fadeAlpha = 1;
        isStarted = false;
        yield return null;
        //だんだん明るく
        time = 0;
        while (time <= interval)
        {
            fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.deltaTime;
            yield return null;
        }
        isFading = false;
        image.enabled = false;
    }

    private bool ChangeFadeColor(Color color)
    {
        if (isFading)
        {
            return false;
        }
        fadeColor = color;
        return true;
    }
}