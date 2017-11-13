using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveManeger : SingletonMonoBehaviour<SaveManeger>
{
    public GameObject[] ImportantPotitionObject;
    public GameObject HoldingStageClearState;
    public List<string> Flags;

    private GameObject Charactor;
    private GetItemManeger itemManager;
    private GetGearManeger gearmanager;
    private StageClearCheck stageclear;
    private List<string> potitisionlist_name = new List<string>();
    private List<Vector2> potitisionlist_pos = new List<Vector2>();
    private List<Quaternion> potitisionlist_rot = new List<Quaternion>();
    private List<string> HoldingStageClear = new List<string>();
    private string nowScene, beforeSceme;

    // Use this for initialization
    override protected void Awake()
    {
        base.Awake();
        nowScene = FadeManager.Instance.NowScene;
        beforeSceme = FadeManager.Instance.BeforeScene;

        if (Player.Instance != null)
        {
            Charactor = Player.Instance.gameObject;
            itemManager = Player.Instance.itemManeger;
            gearmanager = Player.Instance.gearManeger;
        }
        else
        {
            throw new System.NullReferenceException("Charactor is null");
        }
        var InitPoses = GameObject.FindGameObjectsWithTag("ScenePos");
        if (HoldingStageClearState != null)
        {
            stageclear = HoldingStageClearState.GetComponent<StageClearCheck>();
        }
        Dataload();

        SearchListAndDestroy(itemManager.CarryingItems, "Item");
        SearchListAndDestroy(gearmanager.Gears, "Gear");

        foreach (var local in InitPoses)
        {
            if (beforeSceme != "" && local.name == beforeSceme)
            {
                Charactor.transform.position = local.transform.position;
            }
        }
        for (int i = 0; i < ImportantPotitionObject.Count(); i++)
        {
            var index = potitisionlist_name.IndexOf(ImportantPotitionObject[i].name + nowScene);
            var indexInstatete = potitisionlist_name.IndexOf(ImportantPotitionObject[i].name + "(Clone)" + nowScene);
            if (index != -1 && GameObject.Find(ImportantPotitionObject[i].name) != null)
            {
                ImportantPotitionObject[i].transform.position = potitisionlist_pos[index];
                ImportantPotitionObject[i].transform.rotation = potitisionlist_rot[index];
            }
            else if (indexInstatete != -1)
            {
                Instantiate(ImportantPotitionObject[i], potitisionlist_pos[indexInstatete], potitisionlist_rot[indexInstatete]);
            }
            else
            {

            }
        }
        if (HoldingStageClear.IndexOf(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name) != -1)
        {
            stageclear.Iscleared = true;
        }
    }

    private void OnApplicationQuit()
    {
        SaveScene();
    }

    private void Dataload()
    {
        var loaddata = LoadFromJson<SaveData>.Load();
        if (loaddata != null)
        {
            itemManager.CarryingItems = loaddata.isItemGeted ?? new List<string>();
            itemManager.UsedItems = loaddata.UsedItem ?? new List<string>();
            gearmanager.Gears = loaddata.isGearGeted ?? new List<string>();
            Flags = loaddata.Flags ?? new List<string>();
            potitisionlist_name = loaddata.ImpotantPotitionlist_name ?? new List<string>();
            potitisionlist_pos = loaddata.ImpotantPotitionlist_pos ?? new List<Vector2>();
            potitisionlist_rot = loaddata.ImpotantPotitionlist_rot ?? new List<Quaternion>();
            HoldingStageClear = loaddata.StageClearFlag ?? new List<string>();
        }
    }

    /// <summary>
    /// すでに取得済みのアイテムなのかを検索しすでに取得済みならtrueまだならfalseを返します
    /// </summary>
    /// <returns>The is geted.</returns>
    /// <param name="GameObjectName">自分のオブジェクト名.</param>
    /// <param name="TagName">Tag name.</param>
    private bool IsGetedItem(string GameObjectName, string TagName)
    {
        if (GameObject.Find(GameObjectName) != null && GameObject.Find(GameObjectName).gameObject.tag == TagName)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DestroyByString(string objectname)
    {
        Destroy(GameObject.Find(objectname));
    }

    private void SearchListAndDestroy(List<string> objectlist, string tagname)
    {
        foreach (var local in objectlist)
        {
            if (IsGetedItem(local, tagname))
            {
                DestroyByString(local);
            }
        }
    }

    public void SaveScene()
    {
        try
        {
            foreach (var local in ImportantPotitionObject)
            {
                if (potitisionlist_name.IndexOf(local.name + nowScene) != -1)
                {
                    potitisionlist_pos[potitisionlist_name.IndexOf(local.name + nowScene)] = local.transform.position;
                    potitisionlist_rot[potitisionlist_name.IndexOf(local.name + nowScene)] = local.transform.localRotation;
                }
                else
                {
                    potitisionlist_name.Add(local.name + nowScene);
                    potitisionlist_pos.Add(local.transform.position);
                    potitisionlist_rot.Add(local.transform.localRotation);
                }
            }
        }
        catch
        {
        }

        if (stageclear != null && stageclear.Iscleared)
        {
            if (HoldingStageClear.IndexOf(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name) == -1)
            {
                HoldingStageClear.Add(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
        SaveData save = new SaveData()
        {
            ImpotantPotitionlist_name = potitisionlist_name,
            ImpotantPotitionlist_pos = potitisionlist_pos,
            ImpotantPotitionlist_rot = potitisionlist_rot,
            UsedItem = itemManager.UsedItems,
            StageClearFlag = HoldingStageClear,
            Flags = Flags,
            isItemGeted = itemManager.CarryingItems,
            isGearGeted = gearmanager.Gears,
            SceneName = nowScene
        };
        SaveToJson.Save(save);
    }

    public bool GetFlag(string name)
    {
        if (Flags.IndexOf(name) != -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetFlag(string name)
    {
        Flags.Add(name);
    }

    public bool RemoveFlag(string name)
    {
        foreach (var local in Flags)
        {
            if (local == name)
            {
                Flags.Remove(name);
                return true;
            }
        }
        return false;
    }
}