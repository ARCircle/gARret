using System.Linq;
using UnityEngine;

public class CrearMane : MonoBehaviour
{
    public static bool[] Clear = new bool[8];
    private AudioSource Sound1;
    public static  bool isCleared;

    private void Start()
    {
        Sound1 = GetComponent<AudioSource>();

        Clear = new bool[8];
        isCleared = false;
    }

    private void Update()
    {
        if (Clear.Where(n => n == false).Count() == 1 && !isCleared) //もし配列の中に一つもfalseが存在しないかつisClearedがfalseの場合
        {
            MoveManeger.isMoving = true;
            Debug.Log("crear!");
            Sound1.PlayOneShot(Sound1.clip);//歯車の音鳴らすよ
            isCleared = true;
            Invoke("Crear", 2);//シーンチェンジするよ

        }
    }

    private void Crear()
    {
        FadeManager.Instance.LoadScene("ED_Movie", 1.0f);//nameにシーンの名前を代入
    }
}