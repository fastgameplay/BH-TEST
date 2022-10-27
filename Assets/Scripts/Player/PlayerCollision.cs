using System.Collections;
using Mirror;
using UnityEngine;
[RequireComponent(typeof(PlayerInfo))]
public class PlayerCollision : MonoBehaviour
{
    public void CheckHitDirection(Vector3 ForwardDirection,float range){
        RaycastHit rayHit;
        if( Physics.Raycast(transform.position, ForwardDirection, out rayHit,range)){
            if(rayHit.transform.tag == "Player"){
                PlayerDeathManager pdm = rayHit.transform.GetComponent<PlayerDeathManager>();
                if(pdm.IsImmune == false){
                    Debug.Log(pdm.IsImmune + "From PlayerCollision First;");
                    pdm.Hit();
                    Debug.Log(pdm.IsImmune + "From PlayerCollision Second;");

                    GetComponent<PlayerInfo>().PlayerScore ++;
                }
            }
        }
    }
}
