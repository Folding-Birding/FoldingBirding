using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�޼��� ���� ����� ��, �����ϴ� ��ũ��Ʈ 
public class BirdTriggerDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("MyBird"))
        {
            Debug.Log("[BirdTriggerDetect] ���� �޼տ� ��ҽ��ϴ�!");
        }
    }
}
