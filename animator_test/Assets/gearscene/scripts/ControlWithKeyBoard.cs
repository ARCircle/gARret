using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ControlWithKeyBoard : MonoBehaviour
{
    [SerializeField]
    Material Fademat, noamalmat;
    [SerializeField]
    float Speed = 60f;
    List<GameObject> childs = new List<GameObject>();
    int nowSelecting;
    private bool isFade;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i).gameObject);
        }
        nowSelecting = 0;
        childs[nowSelecting].GetComponent<Image>().material = Fademat;
        //coroutine = StartCoroutine(Fade(childs[nowSelecting]));
    }
    Coroutine coroutine = null;
    // Update is called once per frame
    void Update()
    {
        if (UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Intractive"))
        {
            if (coroutine != null)
            {
                isFade = false;
            }
            if(!CrearMane.Clear[nowSelecting+1])
            {
                childs[nowSelecting].GetComponent<Image>().material = noamalmat;
            }
            nowSelecting = MinDistanceIndexSeracher(nowSelecting);
            if(nowSelecting !=-1)
            {
                childs[nowSelecting].GetComponent<Image>().material = Fademat;
            }
            //coroutine = StartCoroutine(Fade(childs[nowSelecting]));
        }
        if (!MoveManeger.isMoving && !CrearMane.isCleared)
        {
            Vector3 vector = childs[nowSelecting].transform.position;
            vector.x += UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Horizontal") * Speed * Time.deltaTime * (Screen.width / 480);
            vector.y += UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Vertical") * Speed * Time.deltaTime * (Screen.height / 270);
            childs[nowSelecting].transform.position = vector;
        }
    }
    public
    int MinDistanceIndexSeracher(int index)
    {
        try
        {
            return childs
               .Select((val, idx) => new { V = val, I = idx })
               .Where(n => (n.V != childs[index]))
               .Where(n => !CrearMane.Clear[n.I + 1])
               .Aggregate((min, working) => ((working.V.transform.position - childs[index].transform.position).magnitude > (min.V.transform.position - childs[index].transform.position).magnitude) ? min : working).I;
        }
        catch 
        {
            return -1;
        }
        
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
        
        _renderer.color = new Color(1, 1, 1);
    }
}