using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveToJson : MonoBehaviour
{
    public static void Save(object savedata)
    {
#if UNITY_STANDALONE
        SaveTojsonAtSTANDALONE(savedata);
#else
        SaveTojsonAtDefault(savedata);
#endif
    }

    public static void Save(object savedata, string path)
    {
#if UNITY_STANDALONE
        SaveTojsonAtSTANDALONE(savedata, path);
#else
        SaveTojsonAtDefault(savedata,path);
#endif
    }

    private static void SaveTojsonAtSTANDALONE(object data)
    {
        SaveTojsonAtSTANDALONE(data, "/SaveData.json");
    }

    private static void SaveTojsonAtSTANDALONE(object data, string path)
    {
        try
        {
            string jsondata = JsonUtility.ToJson(data);
            var strval = System.Text.Encoding.UTF8.GetBytes(jsondata);
            jsondata = System.Text.Encoding.UTF8.GetString(strval);
            StreamWriter writer = new StreamWriter(Application.dataPath + path, false, System.Text.Encoding.UTF8);
            writer.WriteLine(jsondata);
            writer.Flush();
            writer.Close();
        }
        catch
        {
            throw new UnauthorizedAccessException("書き込みができませんでした。パースと書き込み当たりが怪しいです");
        }
    }

    private static void SaveTojsonAtDefault(object data)
    {
        SaveTojsonAtDefault(data, "/SaveData.json");
    }

    private static void SaveTojsonAtDefault(object data, string path)
    {
        try
        {
            string jsondata = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(path, jsondata);
        }
        catch
        {
            throw new UnauthorizedAccessException("書き込みができませんでした。パースと書き込み当たりが怪しいです");
        }
    }
}