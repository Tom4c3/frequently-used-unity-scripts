//VRM�A�o�^�[�̃A�N�e�B�u/��A�N�e�B�u�؂�ւ�
//UniVRM�̃C���X�g�[�����K�v
//�{�^���ȂǂŃ��\�b�h���Ăяo���Ďg�p���邱�Ƃ�z�肵�Ă���

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
