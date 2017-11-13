using System.Collections;
using UnityEngine;

public class Quize2 : MonoBehaviour
{
    public AudioSource soruce;
    public GameObject nextMain;

    /// ボタンをクリックした時の処理
    public void messageRecived()
    {
        soruce.Play();
        StartCoroutine(mainFunc());
    }

    private IEnumerator mainFunc()
    {
        yield return new WaitForSeconds(0.5f);
        nextMain.SetActive(true);
        Destroy(gameObject.transform.parent.gameObject);
    }
}