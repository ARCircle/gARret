using System.Collections;
using UnityEngine;

public class Quize3 : MonoBehaviour
{
    public AudioSource soruce;
    public GameObject target;

    /// ボタンをクリックした時の処理
    public void messageRecived()
    {
        soruce.Play();
        StartCoroutine(mainFunc());
    }

    private IEnumerator mainFunc()
    {
        yield return new WaitForSeconds(0.5f);
        target.GetComponent<Animator>().SetTrigger("ivent");
        GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SetFlag("isQuizCleared");
        GameObject.FindWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().MoveEnable = true;
        //Destroy (target);
        Destroy(this.gameObject.transform.parent.parent.gameObject, 2.0f);
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}