//VRMアバターのアクティブ/非アクティブ切り替え
//UniVRMのインストールが必要
//ボタンなどでメソッドを呼び出して使用することを想定している

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class HideAvatar : MonoBehaviour
{
    public GameObject Avatar;

    public void AvatarButtonPressed()
    {
        if (Avatar.activeSelf)
            Avatar.SetActive(false);
        else
            Avatar.SetActive(true);

      //  Debug.Log(Avatar.activeSelf);
    }
}
