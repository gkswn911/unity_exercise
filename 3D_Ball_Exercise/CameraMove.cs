using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;

    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    // 연산 후에 실행되는 메서드
    // Camera에 자주 사용된다.
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
