public class monoDontDestroy : SingletonMonoBehaviour<monoDontDestroy>
{
    //本スクリプトはこれのみで正常です
    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}