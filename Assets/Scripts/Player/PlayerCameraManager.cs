using Mirror;
using UnityEngine;

public class PlayerCameraManager : NetworkBehaviour{
    TPPCamera tppCamera;
    public override void OnStartLocalPlayer()
    {
        tppCamera = Camera.main.GetComponent<TPPCamera>();
        tppCamera.DirectionTarget = transform;
    }

    void Update(){
        if (!isLocalPlayer) { return; }
        tppCamera.Horizontal = Input.GetAxis("Mouse X");
    }
}
