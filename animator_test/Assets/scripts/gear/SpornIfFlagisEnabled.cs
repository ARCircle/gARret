using System.Collections;
using UnityEngine;

public class SpornIfFlagisEnabled : MonoBehaviour
{
    [SerializeField]
    private string Flag;

    [SerializeField]
    private GameObject target;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(spowrn());
    }

    private IEnumerator spowrn()
    {
        while (true)
        {
            if (Player.Instance.gearManeger.Gears.IndexOf(target.name) >= 0)
            {
                Destroy(this);
            }
            if (SaveManeger.Instance.GetFlag(Flag))
            {
                Instantiate(target, this.transform);
                Destroy(this);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}