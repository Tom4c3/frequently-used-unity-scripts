//インスペクターで指定したオブジェクトのメッシュを表示/非表示するスクリプト
//ボタンなどでメソッドを呼び出して使用することを想定している

using UnityEngine;

public class MeshVisibilityToggle : MonoBehaviour
{
    public GameObject targetMesh; // 切り替えたいメッシュをアタッチする
    private MeshRenderer meshRenderer; // メッシュレンダラーの参照

    // Startメソッドで初期設定
    void Start()
    {
        // アタッチされたGameObjectからMeshRendererを取得
        if (targetMesh != null)
        {
            meshRenderer = targetMesh.GetComponent<MeshRenderer>();
        }
    }

    // メッシュの表示非表示を切り替えるメソッド
    public void ToggleMeshVisibility()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = !meshRenderer.enabled;
        }
        else
        {
            Debug.LogWarning("MeshRendererが設定されていません。");
        }
    }
}