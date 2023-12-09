using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIK : MonoBehaviour
{
    //public Transform targetTransform;
    public Transform aimTransform;
    public Transform bone;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        
    }

    public void AimAtTarget(Transform bone, Vector3 targetPosition)
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        bone.rotation = aimTowards * bone.rotation;
        
    }

    
}
