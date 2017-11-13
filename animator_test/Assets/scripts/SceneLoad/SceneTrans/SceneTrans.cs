using UnityEngine;

public class SceneTrans : MonoBehaviour
{
    public string SceneName;
    public bool isfree;
    private StageClearCheck stageclearcheck;
    private FadeManager FadeManeger;

    private void Start()
    {
        var stageClearCheckgameobject = GameObject.FindWithTag("StageClearDecision");
        if (stageClearCheckgameobject != null)
        {
            stageclearcheck = GameObject.FindWithTag("StageClearDecision").GetComponent<StageClearCheck>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isfree && collision.gameObject.tag == "Player")
            {
                if (GameObject.FindWithTag("Player") != null)
                {
                    var player = GameObject.FindWithTag("Player");
                }
                GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SaveScene();
                FadeManager.Instance.LoadScene(SceneName, 1.0f);
            }
            else if (stageclearcheck != null && stageclearcheck.Iscleared)
            {
                if (GameObject.FindWithTag("Player") != null)
                {
                    var player = GameObject.FindWithTag("Player");
                }
                else
                {

                }
                GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SaveScene();
                FadeManager.Instance.LoadScene(SceneName, 1.0f);
            }
        }
    }
}