using Mirror;
using UnityEngine;
[RequireComponent(typeof(PlayerCollision))]
public class PlayerMovement : NetworkBehaviour{
    [Header("Movement")]
    [SerializeField] float _speed;
    [SerializeField] float _dashDistance;
    [Header("Rotation")]
    [SerializeField] Transform _playerModel;
    [SerializeField] Transform _directionTarget;
    [SerializeField] float _rotationSpeed;
    Vector3 _movement;
    PlayerCollision _playerCollision;    

    void Awake(){
        _playerCollision = GetComponent<PlayerCollision>();
    }
    void Update(){
        if (!isLocalPlayer) { return; }

        _movement = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        
        Move(_movement, _speed);


        Aim(_movement);

        if (Input.GetMouseButtonDown(0)){
            Dash();
        }
    }

    private void Move(Vector3 movementDirection, float speed){
        transform.Translate(movementDirection * Time.deltaTime * speed, _directionTarget);
    }
    private void Aim(Vector3 movementDirection){
        if(movementDirection != Vector3.zero){
            Vector3 aimDirection = _directionTarget.forward * movementDirection.x + _directionTarget.right * -movementDirection.z;

            _playerModel.forward = Vector3.Slerp(_playerModel.forward, aimDirection.normalized, Time.deltaTime * _rotationSpeed);
        }
    }
    

    public void Dash(){
        _playerCollision.CheckHitDirection(_playerModel.transform.right,_dashDistance);
        transform.position += _playerModel.transform.right * _dashDistance;
    }
}
