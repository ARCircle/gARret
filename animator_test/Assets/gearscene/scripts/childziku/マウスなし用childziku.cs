using UnityEngine;

public class マウスなし用childziku1 : MonoBehaviour
{
    private int Z1;

    private void Start()
    {
        Z1 = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {       //ItemTagのカーソルに反応させる
            if (Z1 == 0)
            {
                Debug.Log("enter");
                MoveManeger.isMoving = true;//movingを１にして動かないように
                other.transform.parent.position = this.transform.position;//centerの親の位置をこの座標に
                Invoke("Reset", 1);//Resetを1秒後に呼び出す
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {   //ItemTagのカーソルに反応させる
            Debug.Log("out!");
            //CrearMane.Crear1 = 0;
            Z1 = 0;//歯車ない時に０に戻す
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {   //ItemTagのカーソルに反応させる
            Z1 = 1;//歯車がある間は１にする
            if (other.name == "Center1")
            {
            }//パズルの根底の部分
             //CrearMane.Crear1 = 1;
        }
    }

    private void Reset()
    {
        MoveManeger.isMoving = false;//また動かせるようにする
    }
}