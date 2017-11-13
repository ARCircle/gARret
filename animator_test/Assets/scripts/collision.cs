using UnityEngine;
using UnityStandardAssets._2D;
public class collision : MonoBehaviour
{
    private PlatformerCharacter2D Platformer;
    private PolygonCollider2D collider;
    // Use this for initialization
    private void Awake()
    {
        if(Player.Instance != null)
        {
            Platformer = Player.Instance.gameObject.GetComponent<PlatformerCharacter2D>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Platformer.m_Grounded == false)
        {
            collider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collider.enabled = false;
        }
    }
}