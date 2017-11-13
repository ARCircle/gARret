using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionFade : MonoBehaviour
{
    [SerializeField]
    private string Flagname;

    private Coroutine FadeBack, FadeEnd;

    // Use this for initialization
    private void Start()
    {
        if (GameObject.Find("SaveManeger").GetComponent<SaveManeger>().GetFlag(Flagname))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (FadeEnd != null)
            {
                StopCoroutine(FadeEnd);
                FadeEnd = null;
            }
            FadeBack = StartCoroutine(FadeBackFunc());
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (FadeBack != null)
            {
                StopCoroutine(FadeBack);
                FadeBack = null;
            }
            FadeEnd = StartCoroutine(FadeEndFunc());
        }
    }

    private IEnumerator FadeEndFunc()
    {
        var sprite = this.gameObject.GetComponent<SpriteRenderer>();
        while (sprite.color.a > 0.03f)
        {
            yield return null;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.015f);
        }

        GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SetFlag(Flagname);
        //Destroy(this.gameObject);
    }

    private IEnumerator FadeBackFunc()
    {
        var sprite = this.gameObject.GetComponent<SpriteRenderer>();
        this.gameObject.GetComponent<Animator>().SetTrigger("ReStart");
        for (int i = 0; i < 60; i++)
        {
            while (sprite.color.a < 0.98f)
            {
                yield return null;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + 0.015f);
            }
        }
    }
}