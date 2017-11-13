using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class quiz_last : MonoBehaviour
{
    private Image ImageRenderer;

    [SerializeField]
    private SpriteRenderer SpriteRenderer;

    [SerializeField]
    private GameObject FlagWall;

    [SerializeField]
    private GameObject Gear;

    [SerializeField]
    private AudioSource source;

    private void Start()
    {
        ImageRenderer = this.transform.parent.parent.gameObject.GetComponent<Image>();
        SpriteRenderer = this.transform.parent.gameObject.GetComponent<SpriteRenderer>();
    }
    Color alpha = new Color(0,0,0,-0.03f);
    private IEnumerator IflastQuestionCleaared()
    {
        source.Play();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 33; i++)
        {
            ImageRenderer.color = ImageRenderer.color + alpha;
            SpriteRenderer.color = SpriteRenderer.color + alpha;
            yield return new WaitForEndOfFrame();
        }
        GameObject.Instantiate(Gear, this.gameObject.transform.parent.parent.position+new Vector3(-0.5f,0,0), this.gameObject.transform.rotation);
        FlagWall.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().MoveEnable = true;
        Destroy(this.transform.parent.parent.gameObject);
    }
}