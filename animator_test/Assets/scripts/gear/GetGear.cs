using UnityEngine;

public class GetGear : MonoBehaviour
{
    private GetGearManeger maneger;
    private SpriteRenderer renderer;
    public AudioClip clip;

    [SerializeField]
    private UnityEngine.Audio.AudioMixerGroup SE;

    private void Start()
    {
        maneger = Player.Instance.gearManeger;
        foreach (var local in maneger.Gears)
        {
            if (local == this.gameObject.name)
            {
                Destroy(this.gameObject);
            }
        }
        renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            renderer.enabled = false;
            maneger.Gears.Add(this.gameObject.name);
            GameObject.Find("SaveManeger").GetComponent<SaveManeger>().SetFlag("is" + this.gameObject.name + "GearGeted");
            var audiosouce = this.gameObject.AddComponent<AudioSource>();
            audiosouce.outputAudioMixerGroup = SE;
            audiosouce.clip = clip;
            audiosouce.Play();
            Destroy(this.gameObject, clip.length);
        }
    }
}