using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour{
    public Vector2 Movement { 
        set{
            _movement = new Vector3(value.x,0f,value.y);
        }  
    }
    [Header("Movement")]
    [SerializeField] float _speed;
    [SerializeField] float _dashDistance;
    [Header("Rotation")]
    [SerializeField] Transform _directionTarget;
    [SerializeField] Transform _playerModel;
    [SerializeField] float _rotationSpeed;
    Vector3 _movement;
    
    void Update(){
        if (!isLocalPlayer) { return; }

        Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
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
        Vector3 oldPosition = transform.position;
        if(_movement != Vector3.zero)
            Move(_movement, _dashDistance);
        else{
            Aim(Vector3.forward);
            Move(Vector3.forward, _dashDistance);
        }
        //hitDetector.hit(oldPosition,transform.position,_playerModel.rotation);
    }
}
