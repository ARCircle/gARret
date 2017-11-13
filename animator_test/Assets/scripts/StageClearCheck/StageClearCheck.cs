using UnityEngine;

public class StageClearCheck : MonoBehaviour
{
    private GetItemManeger itemmaneger;

    [SerializeField]
    private GameObject[] grant_object;

    [SerializeField]
    private Vector2[] grant_object_potition;

    [SerializeField]
    private string[] clearFlags;

    private bool iscleared;
    private SaveManeger savemaneger;

    public bool Iscleared
    {
        get
        {
            return iscleared;
        }

        set
        {
            iscleared = value;
        }
    }

    private void Start()
    {
        itemmaneger = Player.Instance.itemManeger;
        savemaneger = SaveManeger.Instance;
        if (grant_object.Length != grant_object_potition.Length)
        {
            throw new System.FormatException("配列の数が違います！");
        }
        if (iscleared)
        {
            foreach (var local in itemmaneger.UsedItems)
            {
                InstanceGrantobj(local);
            }
        }
    }

    private void Update()
    {
        int i = 0;
        foreach (var local in clearFlags)
        {
            if (savemaneger.GetFlag(local))
            {
                i++;
            }
        }
        if (i == clearFlags.Length && clearFlags.Length != 0)
        {
            Iscleared = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var local in clearFlags)
            {
                var localstr = local.Replace("ItemGeted", "");
                bool isItemgeted = false;
                localstr = localstr.Replace("is", "");
                foreach (var itemlodal in itemmaneger.CarryingItems)
                {
                    if (itemlodal.IndexOf(localstr) != -1)
                    {
                        //new Vector2(8.178409f, -1.16964f)
                        InstanceGrantobj(localstr);
                        itemmaneger.UsedItems.Add(localstr);
                        isItemgeted = true;
                    }
                }
                if (!isItemgeted)
                {
                    return;
                }
            }
        }
        else
        {
            return;
        }
        Iscleared = true;
    }

    private void InstanceGrantobj(string str)
    {
        //new Vector2(8.178409f, -1.16964f)
        for (int i = 0; i < grant_object.Length; i++)
        {
            if (grant_object[i].name == str)
            {
                Instantiate(grant_object[i], grant_object_potition[i], Quaternion.identity);
            }
        }
    }
}