using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



//�չٴ� ������ ���� ���� �ɴ� ��ũ��Ʈ 
public class FollowPalmObject : MonoBehaviour
{
    public Transform palmTransform;
    public Vector3 localOffset = new Vector3(0, -0.1f, 3f);
    public float followSpeed = 10f;

    private bool isPalmGestureActive = false;
    private BirdDistanceManager distanceManager;

    void Start()
    {
        distanceManager = FindObjectOfType<BirdDistanceManager>();
    }

    void Update()
    {
        if (!isPalmGestureActive || palmTransform == null) return;

        Vector3 targetPosition = palmTransform.TransformPoint(localOffset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }

    public void OnPalmGestureDetected()
    {
        if (distanceManager != null && distanceManager.IsAnyBirdClose())
        {
            isPalmGestureActive = true;
        }
    }

    public void OnPalmGestureEnded()
    {
        isPalmGestureActive = false;
    }


}
