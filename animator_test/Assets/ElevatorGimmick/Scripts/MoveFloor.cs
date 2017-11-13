using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;      //!< デプロイ時にEditorスクリプトが入るとエラーになるので UNITY_EDITOR で括ってね！
#endif

public class MoveFloor : MonoBehaviour
{

    [SerializeField] GameObject Object;
    [SerializeField] public List<Transform> pathpoint = new List<Transform>();
    [SerializeField] float speed;
    [SerializeField] float delaytime;
    public bool isEnd;
    public enum EaseType
    {
        easeInQuad,
        easeOutQuad,
        easeInOutQuad,
        easeInCubic,
        easeOutCubic,
        easeInOutCubic,
        easeInQuart,
        easeOutQuart,
        tQuart,
        easeInQuint,
        easeOutQuint,
        easeInOutQuint,
        easeInSine,
        easeOutSine,
        easeInOutSine,
        easeInExpo,
        easeOutExpo,
        easeInOutExpo,
        easeInCirc,
        easeOutCirc,
        easeInOutCirc,
        linear,
        spring,
        easeInBounce,
        easeOutBounce,
        easeInOutBounce,
        easeInBack,
        easeOutBack,
        easeInOutBack,
        easeInElastic,
        easeOutElastic,
        easeInOutElastic
    };
    [SerializeField] EaseType easeType = EaseType.linear;
    public enum Pattern
    {
        片道, ループ, 往復
    };
    [SerializeField] Pattern pattern = Pattern.片道;

    private List<float> time = new List<float>();
    private List<float> distance = new List<float>();
    private List<Vector3> movepath = new List<Vector3>();
    private int number;
    public int count = 0;


    // Use this for initialization
    public void MoveStart()
    {
        //Debug.Log (pathpoint[1]);
        number = pathpoint.Count;
        if (pattern == Pattern.ループ)
        {
            Transform temp = pathpoint[0];
            pathpoint.RemoveAt(0);
            pathpoint.Add(temp);

            number = pathpoint.Count;

            for (int i = 0; i < number; i++)
            {
                movepath.Add(pathpoint[i].position);
            }

            distance.Add(Vector3.Distance(movepath[number - 1], movepath[0]));
            for (int j = 0; j < number - 1; j++)
            {
                distance.Add(Vector3.Distance(movepath[j], movepath[j + 1]));
            }


            for (int k = 0; k < number; k++)
            {
                time.Add(distance[k] / speed);
            }

        }
        else if (pattern == Pattern.往復)
        {
            Debug.Log("round");
            Transform temp = pathpoint[0];
            pathpoint.RemoveAt(0);
            for (int i = number - 3; i >= 0; i--)
            {
                pathpoint.Add(pathpoint[i]);
            }
            pathpoint.Add(temp);
            number = pathpoint.Count;
            Debug.Log(number);

            for (int j = 0; j < number; j++)
            {
                movepath.Add(pathpoint[j].position);
            }

            distance.Add(Vector3.Distance(movepath[number - 1], movepath[0]));
            for (int k = 0; k < number - 1; k++)
            {
                distance.Add(Vector3.Distance(movepath[k], movepath[k + 1]));
            }

            for (int l = 0; l < number; l++)
            {
                time.Add(distance[l] / speed);
            }
        }
        else if (pattern == Pattern.片道)
        {
            Transform temp = pathpoint[0];
            //pathpoint.RemoveAt(0);

            number = pathpoint.Count;

            for (int i = 0; i < number; i++)
            {
                movepath.Add(pathpoint[i].position);
            }

            distance.Add(Vector3.Distance(movepath[number - 1], movepath[0]));
            for (int j = 0; j < number - 1; j++)
            {
                distance.Add(Vector3.Distance(movepath[j], movepath[j + 1]));
            }


            for (int k = 0; k < number; k++)
            {
                time.Add(distance[k] / speed);
            }
        }
    }

public bool stopcritical;
    public void Move()
    {
        if(!stopcritical)
        {
            StartCoroutine(corutine());
        }

       /* else
        {
            //iTween.MoveTo(Object,
              //  iTween.Hash("position", movepath[count], "time", time[count], "easeType", easeType.ToString(), "delay", delaytime, "oncompletetarget", this.gameObject, "oncomplete", "Move"));

            isEnd = true;
            if (count == number && pattern != Pattern.片道)
            {
                count = 0;
            }
        }*/
    }
IEnumerator corutine()
{
    stopcritical = true;
while(count != number-1)
{
    int counter = 120;
     count++;
        if (count == number/2)
        {
            GameObject.FindWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().MoveEnable = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().simulated = true;
            GameObject.FindWithTag("Player").transform.parent = null;
        }
        for(int i=0; i<counter;i++)
        {
            this.transform.localPosition += ((movepath[count]-movepath[count-1])/counter)/10;
            yield return null;
        }
}
            Debug.Log("AnimationStop");
            movepath = new List<Vector3>();
            stopcritical = false;
}

#if UNITY_EDITOR
    [CustomEditor(typeof(MoveFloor))]
    //[CanEditMultipleObjects]
    public class MoveEditor : Editor
    {
        bool folding = false;
        public override void OnInspectorGUI()
        {
            MoveFloor mo = target as MoveFloor;
            mo.Object = EditorGUILayout.ObjectField("動かしたいObject", mo.Object, typeof(GameObject), true) as GameObject;

            //通過点
            List<Transform> list = mo.pathpoint;
            int size = list.Count;
            if (size < 2)
            {
                list.Add(null);
                list.Add(null);
            }
            if (folding = EditorGUILayout.Foldout(folding, "通過点（始点〜終点）"))
            {
                //EditorGUILayout.BeginHorizontal ();
                list[0] = EditorGUILayout.ObjectField("    始点", list[0], typeof(Transform), true) as Transform;

                //EditorGUILayout.EndHorizontal ();
                if (size > 2)
                {
                    for (int i = 1; i < size - 1; i++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        list[i] = EditorGUILayout.ObjectField("    目的地" + i.ToString(), list[i], typeof(Transform), true) as Transform;
                        if (GUILayout.Button("削除"))
                        {
                            list.RemoveAt(i);
                            size--;
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
                EditorGUILayout.BeginHorizontal();
                list[size - 1] = EditorGUILayout.ObjectField("    終点", list[size - 1], typeof(Transform), true) as Transform;

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.LabelField("追加");
                EditorGUILayout.BeginHorizontal();
                Transform tr = EditorGUILayout.ObjectField(null, typeof(Transform), true) as Transform;
                EditorGUILayout.EndHorizontal();
                if (tr != null)
                    list.Add(tr);
            }

            //速度
            mo.speed = EditorGUILayout.FloatField("速度", mo.speed);

            //待機時間
            mo.delaytime = EditorGUILayout.FloatField("待機時間", mo.delaytime);

            //動き方
            mo.easeType = (EaseType)EditorGUILayout.EnumPopup("動き方", mo.easeType);

            //往復
            mo.pattern = (Pattern)EditorGUILayout.EnumPopup("繰り返し方", mo.pattern);
        }
    }
#endif

}
