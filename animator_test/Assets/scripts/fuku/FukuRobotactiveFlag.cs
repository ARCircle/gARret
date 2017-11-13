using UnityEngine;

public class FukuRobotactiveFlag : MonoBehaviour
{
    [SerializeField]
    private GameObject Quiz;

    // Use this for initialization
    private void Start()
    {
        if (!GameObject.Find("SaveManeger").GetComponent<SaveManeger>().GetFlag("isQuizCleared"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Clicked()
    {
        Quiz.SetActive(true);
    }
}