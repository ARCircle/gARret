using UnityEngine;

public class getItem : MonoBehaviour
{
    private GetItemManeger maneger;
    private SpriteRenderer renderer;
    public AudioClip clip;

    [SerializeField]
    private UnityEngine.Audio.AudioMixerGroup SE;

    private void Start()
    {
        maneger = Player.Instance.itemManeger;
        renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            renderer.enabled = false;
            maneger.CarryingItems.Add(this.gameObject.name);
            GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SetFlag("is" + this.gameObject.name + "ItemGeted");
            var audiosouce = this.gameObject.AddComponent<AudioSource>();
            audiosouce.outputAudioMixerGroup = SE;
            audiosouce.clip = clip;
            audiosouce.Play();
            Destroy(this.gameObject, clip.length);
        }
    }
}