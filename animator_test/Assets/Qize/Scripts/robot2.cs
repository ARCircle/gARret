using System.Collections;
using UnityEngine;

public class robot2 : MonoBehaviour
{
    public GameObject nextMain;

    private void Start()
    {
        if (GameObject.Find("SaveManeger").GetComponent<SaveManeger>().GetFlag("isQuizCleared"))
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private bool isonce;

    /// ボタンをクリックした時の処理
    public void messageRecived()
    {
        if (!isonce)
        {
            StartCoroutine(mainFunc());
            isonce = true;
        }
    }

    private IEnumerator mainFunc()
    {
        yield return new WaitForSeconds(0.5f);
        nextMain.SetActive(true);
    }
}