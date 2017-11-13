using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームデータの形式だけを保持したスクリプトです
/// 内部データの形式は今のところScenename,取得ギアのリスト,取得アイテムのリスト,重要オブジェクトの座標、名前、
/// 使用済みのアイテム、フラグです
/// </summary>

public class SaveData
{
    public string SceneName;
    public List<string> isItemGeted = new List<string>();
    public List<string> isGearGeted = new List<string>();
    public List<string> ImpotantPotitionlist_name;
    public List<Vector2> ImpotantPotitionlist_pos;
    public List<Quaternion> ImpotantPotitionlist_rot;
    public List<string> StageClearFlag;
    public List<string> UsedItem;
    public List<string> Flags;
}