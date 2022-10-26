using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public void CheckHitDirection(Vector3 ForwardDirection,float range){
        RaycastHit rayHit;
        if( Physics.Raycast(transform.position, ForwardDirection, out rayHit,range)){
            if(rayHit.transform.tag == "Player"){
                rayHit.transform.GetComponent<PlayerDeathManager>().Hit();

            }
        }
    }
}
