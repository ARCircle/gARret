using UnityEngine;

public class Buttonback : MonoBehaviour
{
    public void ButtonPush()
    {
        Debug.Log("push");
        FadeManager.Instance.LoadScene("tumiki city2", 1.0f);//nameにシーンの名前を代入
    }
}