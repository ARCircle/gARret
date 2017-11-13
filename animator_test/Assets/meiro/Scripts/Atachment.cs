using UnityEngine;

public class Atachment : MonoBehaviour
{
    private GameObject Chara;

    // Use this for initialization
    private void Start()
    {
        this.Chara = GameObject.Find("Chara");
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName("Maze"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SaveManeger.Instance.SetFlag("isMazeClear");
            var blur = Camera.main.GetComponent<GaussianBlur>();
            if (blur != null)
            {
                Destroy(blur);
            }
            SaveManeger.Instance.SaveScene();
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Maze");
        }
    }
}