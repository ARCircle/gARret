using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    public GetGearManeger gearManeger = new GetGearManeger();
    public GetItemManeger itemManeger = new GetItemManeger();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gearManeger.Process();
    }
}
