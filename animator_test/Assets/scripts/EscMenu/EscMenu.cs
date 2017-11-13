using UnityEngine;

public class EscMenu : MonoBehaviour
{
    private void Start()
    {
        if (SaveManeger.Instance != null)
        {
            SaveManeger.Instance.SaveScene();
        }
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName("EscMenu"));
    }

    public void ContinueButtonClicked()
    {
        EscManager.Instance.GotoGame();
    }

    public void GoToStartMenuButtonClicked()
    {
        FadeManager.Instance.LoadScene("Start", 1.0f);
        Time.timeScale = 1.0f;
    }
}