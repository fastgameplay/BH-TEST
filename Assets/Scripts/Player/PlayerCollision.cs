using System.Collections;
using Mirror;
using UnityEngine;
[RequireComponent(typeof(PlayerInfo))]
public class PlayerCollision : MonoBehaviour
{
    public void CheckDirection(Vector3 direction,float range){
        RaycastHit rayHit;
        if( Physics.Raycast(transform.position, direction, out rayHit,range)){
            if(rayHit.transform.tag == "Player"){
                PlayerDeathManager pdm = rayHit.transform.GetComponent<PlayerDeathManager>();
                if(pdm.IsImmune == false){
                    pdm.Hit();

                    GetComponent<PlayerInfo>().CmdAddScore();
                    Debug.Log("PlayerScore is " + GetComponent<PlayerInfo>().PlayerScore);
                }
            }
        }
    }
}
