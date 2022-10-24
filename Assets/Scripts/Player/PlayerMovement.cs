using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Vector2 Movement { 
        set{
            _movement = new Vector3(value.x,0f,value.y);
        }  
    }

    [SerializeField] Transform _playerModel;
    [SerializeField] Transform _directionTarget;
    [SerializeField] float _speed;
    [SerializeField] float _rotationSpeed;
    Vector3 _movement;
    void Update(){
        Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move();

        Aim();
    }

    private void Move(){
        transform.Translate(_movement * Time.deltaTime * _speed, _directionTarget);
    }
    private void Aim(){
        if(_movement != Vector3.zero){
            Vector3 direction = _directionTarget.forward * _movement.x + _directionTarget.right * -_movement.z;

            _playerModel.forward = Vector3.Slerp(_playerModel.forward, direction.normalized, Time.deltaTime * _rotationSpeed);
        }
    }
}
