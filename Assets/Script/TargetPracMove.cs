using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPracMove : MonoBehaviour
{
    public Transform target;
    public Transform refPoint;
   
    public void MoveTarget(float moveBy)
    {
        
            target.position = new Vector3(refPoint.position.x + moveBy, target.position.y, target.position.z);
        
    }

}
