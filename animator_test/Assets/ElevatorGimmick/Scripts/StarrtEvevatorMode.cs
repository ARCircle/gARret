using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarrtEvevatorMode : MonoBehaviour
{
    [SerializeField] GameObject Up, Down, Right, Left;
    [SerializeField] float arrowBlank = 0.2f;
    bool isPush, isElatatorMode;
    List<int> pathnumberlist = new List<int>();
    enum Direction
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    };
    List<Transform> pointstrans = new List<Transform>();
    private void Start()
    {
        var points = GameObject.Find("points").transform;
        floor = GetComponent<MoveFloor>();
        for (int i = 0; i < points.transform.childCount; i++)
        {
            pointstrans.Add(points.GetChild(i));
        }
    }
    private List<GameObject> arrowpointslist = new List<GameObject>();
    private List<GameObject> initarrowlist = new List<GameObject>();
    public bool isonce;
    private MoveFloor floor;
    // Update is called once per frame
    void Update()
    {
        isPush = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Intractive");
        if (pathnumberlist.Count >= 3 && !floor.stopcritical)
        {
            foreach (var item in arrowpointslist)
            {
                Destroy(item, 0.1f);
            }
            arrowpointslist = new List<GameObject>();

            
            floor.pathpoint = PathGenerator(pathnumberlist.ToArray());
            floor.count = 0;
            floor.MoveStart();
            floor.Move();
            isElatatorMode = false;
            pathnumberlist = new List<int>();

        }
        if (isElatatorMode && !floor.stopcritical)
        {
            if (!isonce)
            {
                initarrowlist.Add(Instantiate(Up, new Vector3(7.1f + (0 * arrowBlank), -1.2f), Up.transform.rotation));
                initarrowlist.Add(Instantiate(Down, new Vector3(7.1f + (1 * arrowBlank), -1.2f), Down.transform.rotation));
                initarrowlist.Add(Instantiate(Right, new Vector3(7.1f + (2 * arrowBlank), -1.2f), Right.transform.rotation));
                initarrowlist.Add(Instantiate(Left, new Vector3(7.1f + (3 * arrowBlank), -1.2f), Left.transform.rotation));
                isonce = true;
            }
        }
        if (!isElatatorMode)
        {
            isonce = false;
        }
        if (isElatatorMode && (Mathf.Abs(UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Horizontal")) > 0   ||
                               Mathf.Abs(UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Vertical")) > 0   ))
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                foreach (var item in initarrowlist)
                {
                    Destroy(item);
                }
                if (Input.GetKeyDown(code))
                {
                    switch (code)
                    {
                        case KeyCode.W:
                            pathnumberlist.Add((int)Direction.UP);
                            arrowpointslist.Add(Instantiate(Up, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Up.transform.rotation));
                            break;
                        case KeyCode.A:
                            pathnumberlist.Add((int)Direction.LEFT);
                            arrowpointslist.Add(Instantiate(Left, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Left.transform.rotation));
                            break;
                        case KeyCode.S:
                            pathnumberlist.Add((int)Direction.DOWN);
                            arrowpointslist.Add(Instantiate(Down, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Down.transform.rotation));
                            break;
                        case KeyCode.D:
                            pathnumberlist.Add((int)Direction.RIGHT);
                            arrowpointslist.Add(Instantiate(Right, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Right.transform.rotation));
                            break;
                        case KeyCode.UpArrow:
                            pathnumberlist.Add((int)Direction.UP);
                            arrowpointslist.Add(Instantiate(Up, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Up.transform.rotation));
                            break;
                        case KeyCode.DownArrow:
                            pathnumberlist.Add((int)Direction.DOWN);
                            arrowpointslist.Add(Instantiate(Down, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Down.transform.rotation));
                            break;
                        case KeyCode.RightArrow:
                            pathnumberlist.Add((int)Direction.RIGHT);
                            arrowpointslist.Add(Instantiate(Right, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Right.transform.rotation));
                            break;
                        case KeyCode.LeftArrow:
                            pathnumberlist.Add((int)Direction.LEFT);
                            arrowpointslist.Add(Instantiate(Left, new Vector3(7.1f + (pathnumberlist.Count * arrowBlank), -1.2f), Left.transform.rotation));
                            break;

                        default:
                            break;
                    }
                    break;
                }
            }

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (isPush && collision.gameObject.tag == "Player" && !floor.stopcritical)
        {
            GameObject.FindWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().MoveEnable = false;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().simulated = false;
            GameObject.FindWithTag("Player").transform.parent = transform;
            isElatatorMode = true;
        }

    }
    List<Transform> PathGenerator(int[] directins)
    {
        int nowPathNumber = 5;
        List<Transform> Paths = new List<Transform>();
        Paths.Add(this.transform);
        for (int i = 0; i < directins.Length; i++)
        {
            switch (directins[i])
            {
                case (int)Direction.UP:
                    if (nowPathNumber - 3 >= 0)
                    {
                        nowPathNumber -= 3;
                        Paths.Add(pointstrans[nowPathNumber]);
                    }
                    else
                    {
                    }
                    break;
                case (int)Direction.DOWN:
                    if (nowPathNumber + 3 <= 5)
                    {
                        nowPathNumber += 3;
                        Paths.Add(pointstrans[nowPathNumber]);
                    }
                    else
                    {
                    }
                    break;
                case (int)Direction.RIGHT:
                    if (nowPathNumber + 1 <= 5 && nowPathNumber != 2)
                    {
                        nowPathNumber += 1;
                        Paths.Add(pointstrans[nowPathNumber]);
                    }
                    else
                    {
                    }
                    break;
                case (int)Direction.LEFT:
                    if (nowPathNumber - 1 >= 0 && nowPathNumber != 3)
                    {
                        nowPathNumber -= 1;
                        Paths.Add(pointstrans[nowPathNumber]);
                    }
                    else
                    {
                    }
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
        var temppath = Paths.ToArray();
        Array.Reverse(temppath);
        Paths.AddRange(temppath);
        return Paths;
    }

}
