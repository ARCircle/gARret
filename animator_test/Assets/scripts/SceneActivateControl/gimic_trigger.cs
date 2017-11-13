using UnityEngine;

public class gimic_trigger : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject gimicwall;

    [SerializeField]
    private string TriggerFlagName;

    private GameObject CharacterRobotBoy;
    private UnityStandardAssets._2D.PlatformerCharacter2D Platformer;
    private Rigidbody2D rbBall;
    private bool isonce;

    private void Start()
    {
        if (SaveManeger.Instance != null && SaveManeger.Instance.GetFlag(TriggerFlagName))
        {
            Destroy(gimicwall);
        }
        rb2d = GetComponent<Rigidbody2D>();
        CharacterRobotBoy = GameObject.FindWithTag("Player");
        Platformer = CharacterRobotBoy.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
    }

    private void FixedUpdate()
    {
        if (!isonce)
        {
            if (transform.position.y < -3.1f)
            {
                isonce = true;
                rbBall = GetComponent<Rigidbody2D>();
                rbBall.angularVelocity = 0f;
                rbBall.velocity = new Vector2(0f, 0f);
                rbBall.isKinematic = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trigger") && Platformer.m_Grounded == true)
        {
            Destroy(gimicwall);
            GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SetFlag(TriggerFlagName);
        }
    }
}