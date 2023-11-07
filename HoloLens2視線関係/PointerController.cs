//HoloLens2でアイトラッキングするときに使うスクリプト
//通常，視線より優先されるハンドレイ（によるポインタの操作）を無効化し，視線ポインタを常にオンにする処理
//視線の動きを記録するときにはこれをシーンに置いておく

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class PointerController : MonoBehaviour
{
    void Start()
    {
        // すべての手のレイをオフにする
        PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff);

        // 視線ポインタを常にオン
        PointerUtils.SetGazePointerBehavior(PointerBehavior.AlwaysOn);
    }
}