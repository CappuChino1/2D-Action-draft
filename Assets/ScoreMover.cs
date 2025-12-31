using UnityEngine;

//ステージ3をクリアしたらスコアを画面中央に配置したい
//現在はできていない
public class ScoreMover : MonoBehaviour
{
    public RectTransform scoreUI;        // スコアのUI
    public RectTransform normalParent;   // 通常時の親（右上の位置）
    public RectTransform clearParent;    // クリア画面の親（中央の位置）

    public void MoveToClearPosition()
    {
        scoreUI.SetParent(clearParent);
        scoreUI.anchoredPosition = Vector2.zero;  // 中央に配置
    }

    public void MoveToNormalPosition()
    {
        scoreUI.SetParent(normalParent);
        scoreUI.anchoredPosition = Vector2.zero;  // 右上の位置に戻す
    }
}