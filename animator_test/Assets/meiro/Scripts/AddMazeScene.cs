using UnityEngine;
using UnityEngine.SceneManagement;

public class AddMazeScene : MonoBehaviour
{
    private bool isEkeyPushed;

    [SerializeField]
    private Material mat;

    private void Start()
    {
        if (SaveManeger.Instance.GetFlag("isMazeClear"))
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        isEkeyPushed = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Intractive");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isEkeyPushed && collision.tag == "Player" && !DeniedSceneList.RejectionDetection())
        {
            SceneManager.LoadSceneAsync("Maze", LoadSceneMode.Additive);

            var blur = Camera.main.gameObject.AddComponent<GaussianBlur>();
            blur.m_material = mat;
            Destroy(this);
        }
    }
}