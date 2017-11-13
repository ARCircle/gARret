using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscManager : SingletonMonoBehaviour<EscManager>
{
    [SerializeField]
    private Material m_mat;

    private GaussianBlur cameraBlur;
    public List<IEnumerator> FadeEvent = new List<IEnumerator>();

    // Update is called once per frame
    private void Update()
    {
        bool isEscKeyPushed = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Cancel");
        if (isEscKeyPushed && SceneManager.GetActiveScene().name != "EscMenu" && !DeniedSceneList.RejectionDetection())
        {
            SceneManager.LoadSceneAsync("EscMenu", LoadSceneMode.Additive);
            cameraBlur = Camera.main.gameObject.AddComponent<GaussianBlur>();
            cameraBlur.m_material = m_mat;
            Time.timeScale = 0.0f;
            System.GC.Collect();
        }
        else if (isEscKeyPushed && !DeniedSceneList.RejectionDetection())
        {
            System.GC.Collect();
            GotoGame();
        }
    }

    public void GotoGame()
    {
        StartCoroutine(GoToGameFunc());
    }

    private IEnumerator GoToGameFunc()
    {
        if (FadeEvent.Count != 0)
        {
            foreach (var local in FadeEvent)
            {
                StartCoroutine(local);
            }
            yield return FadeEvent[0];
            FadeEvent = new List<IEnumerator>();
            Destroy(cameraBlur.GetComponent<GaussianBlur>());
            Time.timeScale = 1.0f;
            SceneManager.UnloadSceneAsync("EscMenu");
        }
    }

    private void GoToStartMenu()
    {
    }
}