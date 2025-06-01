using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�չٴ� ������ ���� ���� �ɴ� ��ũ��Ʈ 
public class FollowPalmObject : MonoBehaviour
{
    public Transform palmTransform;  // �� Transform (��: RightHand)
    public Vector3 localOffset = new Vector3(0, -0.1f, 3f); // �� ���� offset (���� ��ǥ��)
    public float followSpeed = 10f;

    private bool shouldFollow = false;

    void Update()
    {
        if (!shouldFollow || palmTransform == null) return;

        // palmTransform ������ ���� offset�� ���� ��ǥ�� ��ȯ
        Vector3 targetPosition = palmTransform.TransformPoint(localOffset);

        // ��ġ ���󰡱�
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);

        // ȸ���� ���󰡱� (����)
        //transform.rotation = Quaternion.Slerp(transform.rotation, palmTransform.rotation, Time.deltaTime * followSpeed);
    }

    public void StartFollowing() => shouldFollow = true;
    public void StopFollowing() => shouldFollow = false;
}
