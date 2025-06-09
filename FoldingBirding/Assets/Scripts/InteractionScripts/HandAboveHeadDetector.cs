using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAboveHeadDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform headTransform;  // HMD, �� �Ӹ� ��ġ
    public Transform handTransform;  // �� ��ġ (�޼� or ������)
    public float yOffset = 0.15f;    // �Ӹ����� �󸶳� ���� �ö󰡾� �ϴ��� ����

    private bool hasTriggered = false;

    void Update()
    {
        float headY = headTransform.position.y;
        float handY = handTransform.position.y;

        // �� ������ �հ� �Ӹ��� Y ��ǥ �α� ���
        Debug.Log($"[HandAboveHeadDetector] Head Y: {headY:F2}, Hand Y: {handY:F2}");

        if (handY > headY + yOffset)
        {
            if (!hasTriggered)
            {
                Debug.Log("[HandAboveHeadDetector] ���� �Ӹ� ���� �ö󰬽��ϴ�!");
                hasTriggered = true;
            }
        }
        else
        {
            hasTriggered = false;
        }
    }
}
