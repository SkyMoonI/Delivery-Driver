using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject _followedObject;
    // follows the car

    void LateUpdate()
    {
        transform.position = _followedObject.transform.position + new Vector3(0,0,-10);
    }
}
