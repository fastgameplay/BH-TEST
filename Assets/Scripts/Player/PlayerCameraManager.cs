using Mirror;
using UnityEngine;

public class PlayerCameraManager : NetworkBehaviour{
    [SerializeField] Transform _directionTarget;
    TPPCamera tppCamera;
    public override void OnStartLocalPlayer()
    {
        tppCamera = Camera.main.GetComponent<TPPCamera>();
        tppCamera.DirectionTarget = _directionTarget;
    }

    void Update(){
        if (!isLocalPlayer) { return; }
        tppCamera.Horizontal = Input.GetAxis("Mouse X");
    }
}
