using UnityEngine;

public class GearEmmision : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var _renderer = this.GetComponent<SpriteRenderer>();
        _renderer.material.EnableKeyword("_EMISSION");
        float sin = Mathf.Sin(Time.time * 1.5f);
        _renderer.color = new Color(0.5f + (sin / 6), 0.5f + (sin / 6), 0.5f + (sin / 6));
    }
}