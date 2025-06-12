using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



//�չٴ� ������ ���� ���� �ɴ� ��ũ��Ʈ 
public class FollowPalmObject : MonoBehaviour
{
    //private BirdDistanceChecker birdDistance;
    //public Transform palmTransform;  // �� Transform (��: RightHand)
    //public Vector3 localOffset = new Vector3(0, -0.1f, 3f); // �� ���� offset (���� ��ǥ��)
    //public float followSpeed = 10f;

    ////hmd�� �� ������ �Ÿ� ��� 
    //public float maxAllowedDistance = 0.5f;

    //private Transform hmdTransform;
    //private bool isPalmGestureActive = false;
    ////private bool shouldFollow = false;

    //void Start()
    //{
    //    // HMD ��ġ ����(���� ī�޶� ��ġ)
    //    hmdTransform = Camera.main.transform;
    //    birdDistance = GetComponent<BirdDistanceChecker>();
    //}

    //void Update()
    //{
    //    //if (!shouldFollow || palmTransform == null) return;

    //    if (palmTransform == null || hmdTransform == null) return;

    //    //hmd�� �� ������ �Ÿ� ���. 
    //    float distance = Vector3.Distance(hmdTransform.position, palmTransform.position);
    //    if (!isPalmGestureActive || distance > maxAllowedDistance)
    //        return;


    //    //if (!shouldFollow) return;

    //    // palmTransform ������ ���� offset�� ���� ��ǥ�� ��ȯ
    //    Vector3 targetPosition = palmTransform.TransformPoint(localOffset);

    //    // ��ġ ���󰡱�
    //    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);

    //    Debug.Log($"Gesture: {isPalmGestureActive}, Distance: {distance}");
    //    // ȸ���� ���󰡱� (����)
    //    //transform.rotation = Quaternion.Slerp(transform.rotation, palmTransform.rotation, Time.deltaTime * followSpeed);
    //}

    ////public void StartFollowing() => shouldFollow = true;
    ////public void StopFollowing() => shouldFollow = false;

    //public void OnPalmGestureDetected()
    //{
    //    if (birdDistance != null && birdDistance.IsCloseEnough())
    //    {
    //        isPalmGestureActive = true;
    //    }
    //}

    //public void OnPalmGestureEnded()
    //{
    //    isPalmGestureActive = false;
    //}
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
