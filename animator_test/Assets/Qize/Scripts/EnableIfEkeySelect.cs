using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIfEkeySelect : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    // Use this for initialization
    void Start()
    {

    }
    bool isPushed;
    // Update is called once per frame
    void Update()
    {
        isPushed = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Intractive");
    }
    bool isoncetrigger;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPushed && collision.tag == "Player" && !isoncetrigger)
        {
            GameObject.FindWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().MoveEnable = false;
            isoncetrigger = true;
            messageRecived();
        }
    }
    bool isonce;
    public void messageRecived()
    {
        if (!isonce)
        {
            StartCoroutine(mainFunc());
            isonce = true;
        }
    }
    IEnumerator mainFunc()
    {
        yield return new WaitForSeconds(0.5f);
        target.SetActive(true);
    }
}
