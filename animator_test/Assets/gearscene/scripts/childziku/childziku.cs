using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class childziku : MonoBehaviour
{
    private bool isStayGear;

    [SerializeField]
    private int puzzleTriggerNumber;

    [SerializeField]
    private Material IllMat, DefaultMat;

    private bool isFade;

    private void Start()
    {
        isStayGear = false;
        if (puzzleTriggerNumber == 0)
        {
            throw new System.NullReferenceException();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isStayGear)
        {
            Debug.Log("enter");
            MoveManeger.isMoving = true;//movingを１にして動かないように
            other.transform.parent.position = this.transform.position;//centerの親の位置をこの座標に
            Invoke("Reset", 1);//Resetを1秒後に呼び出す
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("out!");
        CrearMane.Clear[puzzleTriggerNumber] = false;
        isStayGear = false;//歯車ない時に０に戻す
        other.transform.parent.gameObject.GetComponent<Image>().material = DefaultMat;
        isFade = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        isStayGear = true;//歯車がある間は１にする
        if (other.name == "Center" + puzzleTriggerNumber)
        {//パズルの根底の部分
            CrearMane.Clear[puzzleTriggerNumber] = true;
            other.transform.parent.gameObject.GetComponent<Image>().material = IllMat;
            isFade = true;
            StartCoroutine(Fade(other.transform.parent.gameObject));
        }
    }

    private void Reset()
    {
        MoveManeger.isMoving = false;//また動かせるようにする
    }

    private IEnumerator Fade(GameObject gobj)
    {
        var _renderer = gobj.GetComponent<Image>();
        while (isFade)
        {
            _renderer.material.EnableKeyword("_EMISSION");
            float sin = Mathf.Sin(Time.time * 1.5f);
            _renderer.color = new Color(0.5f + (sin / 6), 0.5f + (sin / 6), 0.5f + (sin / 6));
            yield return null;
        }
        //(174f / 255f)
        _renderer.color = new Color(1 ,1,1);
    }
}