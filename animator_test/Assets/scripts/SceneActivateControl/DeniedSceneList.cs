using UnityEngine.SceneManagement;

public class DeniedSceneList
{
    static public string[] RejectionScenes = new string[]
    {
        "Start",
        "Op_Movie",
        "Ed_Movie",
        "NowLoading",
        "Gaze,",
        "gearscene/GearScene/haguruma",
    };

    private static string nowScene;

    static DeniedSceneList()
    {
        SceneManager.activeSceneChanged += SceneChanged;
        nowScene = SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// メニューが起動してはいけないところで起動していないかを確認
    /// </summary>
    /// <returns><c>true</c>, if detection was rejectioned, <c>false</c> otherwise.</returns>
    public static bool RejectionDetection()
    {
        foreach (var local in RejectionScenes)
        {
            if (local == nowScene)
            {
                return true;
            }
        }
        return false;
    }

    private static void SceneChanged(Scene i_preChangedScene, Scene i_postChangedScene)
    {
        nowScene = i_postChangedScene.name;
    }
}