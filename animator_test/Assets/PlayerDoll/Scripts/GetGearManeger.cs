using System.Collections.Generic;
[System.SerializableAttribute]
public class GetGearManeger
{
    [UnityEngine.SerializeField]
    private List<string> gears = new List<string>();

    public List<string> Gears
    {
        get
        {
            return gears;
        }

        set
        {

            gears = value;
        }
    }
 
    public void Process()
    {
        for (int i = 0; i < gears.Count; i++)
        {
            if (i != gears.IndexOf(gears[i]))
            {
                gears.Remove(gears[i]);
            }
        }
    }
}