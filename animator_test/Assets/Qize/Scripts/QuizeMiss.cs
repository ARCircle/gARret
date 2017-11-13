using UnityEngine;

public class QuizeMiss : MonoBehaviour
{
    public AudioSource soruce;

    /// ボタンをクリックした時の処理
    public void messageRecived()
    {
        soruce.Play();
    }
}