using UnityEngine;

public class Scenechange : MonoBehaviour
{
    private UnityEngine.SceneManagement.Scene hagurumascene;
    private GameObject yazirusi;
    private bool mouseclick, keyboardclick;

    private void FixedUpdate()
    {//Fixedで実行することでTimeScale=oの時停止するTipsを利用
        mouseclick = Input.GetMouseButtonDown(0);
        keyboardclick = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Intractive");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			if ((mouseclick || keyboardclick) && Player.Instance.gearManeger.Gears.Count >= 7)
            {   //範囲内で左クリックしたらシーン遷移
                SaveManeger.Instance.SaveScene();
                FadeManager.Instance.LoadScene("gearscene/Scenes/haguruma", 2.0f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        {
            Invoke("OFFAnimator", 1.25f);
            yazirusi.GetComponent<Animator>().SetBool("exit", true);
            yazirusi.GetComponent<Renderer>().enabled = false;
        }
    }

    private void OFFAnimator()
    {
        yazirusi.GetComponent<Animator>().enabled = false;
    }
}