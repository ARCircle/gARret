using UnityEngine;

public class PictureSwitch : MonoBehaviour
{
    public GameObject[] pictures;

    [SerializeField]
    private GameObject TitleLOGO;

    public Color[] color;

    private string[] stagelist = new string[]
    {
        "animator_test",
        "tumiki city2",
        "4stage",
        "fuku"
    };

    /// <summary>
    /// 現在セーブされているセーブデータをロードしてそれに応じた写真を適用
    /// </summary>
    // Use this for initialization
    private void Start()
    {
        var i = PictureSelect();
        pictures[i].SetActive(true);
        var logo = TitleLOGO.GetComponent<SpriteRenderer>();
        logo.color = color[i];
    }

    private int PictureSelect()
    {
        /*try
        {
            SaveData data = LoadFromJson<SaveData>.Load();
            for (int i = 0; i < stagelist.Length; i++)
            {
                if (data.SceneName == stagelist[i])
                {
                    return i;
                }
            }
            return Random.Range(0, stagelist.Length - 1);
        }
        catch
        {
            return 0;
        }*/
        return Random.Range(0, stagelist.Length );
    }

    // Update is called once per frame
    private void Update()
    {
    }
}