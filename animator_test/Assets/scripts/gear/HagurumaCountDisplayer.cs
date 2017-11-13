using UnityEngine.UI;

public class HagurumaCountDisplayer : SingletonMonoBehaviour<HagurumaCountDisplayer>
{
    private Text text;
    static UnityEngine.Color color;
    // Use this for initialization
    protected override void Awake()
    {
        text = GetComponent<Text>();
        color = text.color;
        base.Awake();
    }
    private void Start()
    {
        text.color = color;
    }
    private int GearAmount;

    // Update is called once per frame
    private void Update()
    {
        if (Player.Instance != null && Player.Instance.gearManeger.Gears.Count != GearAmount)
        {
            GearAmount = Player.Instance.gearManeger.Gears.Count;
            text.text = GearAmount.ToString() + "/7";
        }
    }
}