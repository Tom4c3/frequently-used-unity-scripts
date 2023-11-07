//インスペクターで指定したオブジェクトをアクティブ/非アクティブ化するスクリプト
//ボタンなどでメソッドを呼び出して使用することを想定している

using UnityEngine;

public class ObjectActiveToggle : MonoBehaviour
{
    public GameObject targetObject; // アクティブ状態を切り替えたいオブジェクトをアタッチする

    // オブジェクトのアクティブ状態を切り替えるメソッド
    public void ToggleObjectActive()
    {
        if (targetObject != null)
        {
            // オブジェクトのアクティブ状態を切り替える
            targetObject.SetActive(!targetObject.activeSelf);
        }
        else
        {
            // targetObjectが設定されていない場合、警告を表示する
            Debug.LogWarning("targetObjectが設定されていません。");
        }
    }
}
