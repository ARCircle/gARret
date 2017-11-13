using System.IO;
using System.Linq;
using UnityEngine;

public class LoadFromJson<Type> : MonoBehaviour
{
    /// <summary>
    /// データをロードします引数未指定の場合セーブデータを読み込み、それ以外の場合はpathを指定してください
    /// </summary>
    public static Type Load()
    {
        return Load("/SaveData.json");
    }

    public static Type Load(string path)
    {
#if UNITY_STANDALONE
		return LoadAtStandAlone(path);
#else
        return LoadAtDefault(path);
#endif
    }

    private static Type LoadAtStandAlone(string path)
    {
        try
        {
            FileInfo fi;
            fi = new FileInfo(Application.dataPath + path);
            StreamReader reader = new StreamReader(fi.OpenRead(), System.Text.Encoding.UTF8);
            var strval = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
            var str = System.Text.Encoding.UTF8.GetString(strval);
            var data = JsonUtility.FromJson<Type>(str);
            //var data = JsonUtility.FromJson<Type>(reader.ReadToEnd());
            reader.Close();
            return data;
        }
        catch
        {
            Debug.Log("ロードエラー、セーブデータがない可能性が高いです");
            return default(Type);
        }
    }

    private static Type LoadAtDefault(string path)
    {
        try
        {
			var data = JsonUtility.FromJson<Type>(PlayerPrefs.GetString(path));
            return data;
        }
        catch
        {
            Debug.Log("ロードエラー、セーブデータがない可能性が高いです");
            return default(Type);
        }
    }
}