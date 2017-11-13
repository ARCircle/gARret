using UnityEngine;

public class MakeInstance : MonoBehaviour
{
    [SerializeField]
    private GameObject fukidasiNotSatisfied;

    [SerializeField]
    private GameObject fukidasiSatisfied;

    private GameObject InstancedObject;
    private bool makecheck = true;

    [SerializeField]
    private Vector2 NotSatisfiedFukidashipotition;

    [SerializeField]
    private Vector2 SatisfiedFukidashipotition;

    private StageClearCheck clearcheck;
    private bool isInited;
    private BoxCollider2D item;
    // Use this for initialization
    private void Start()
    {
        clearcheck = GameObject.FindWithTag("StageClearDecision").GetComponent<StageClearCheck>();
        item = GameObject.FindWithTag("Item").GetComponent<BoxCollider2D>();
        item.enabled = false;
        if (clearcheck.Iscleared)
        {
            Destroy(this);
            return;
        }
        isInited = true;
    }
    private bool ispushed;
    private void Update()
    {
        ispushed = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Intractive");
    }
    private void OnTriggerStay2D(Collider2D c)
    {
        if (makecheck && isInited)
        {
            if (c.tag == "Player" && clearcheck.Iscleared)
            {
                InstancedObject = Instantiate(fukidasiSatisfied, SatisfiedFukidashipotition, Quaternion.identity);
                Debug.Log("OK");
                makecheck = false;
            }
        }
        if(makecheck && isInited && ispushed)
        {
            if (c.tag == "Player" && !clearcheck.Iscleared)
            {
                InstancedObject = Instantiate(fukidasiNotSatisfied, NotSatisfiedFukidashipotition, Quaternion.identity);
                item.enabled = true;
                makecheck = false;
            }
        }
    } 

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            Destroy(InstancedObject);
            Debug.Log("Destroy");
            makecheck = true;
        }
    }
}