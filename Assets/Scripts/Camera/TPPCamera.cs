using UnityEngine;

public class TPPCamera : MonoBehaviour{

    public float Horizontal {set {horizontal = value * _rotationSpeed;} }
    float horizontal;
    [SerializeField] GameObject _directionTarget;
    [SerializeField] float _rotationSpeed;
    [SerializeField] Vector3 _offset;

    void LateUpdate(){
        Horizontal= Input.GetAxis("Mouse X");

        CameraMovement();
        
        transform.LookAt(_directionTarget.transform);
    }

    private void CameraMovement(){
        _directionTarget.transform.Rotate(0,horizontal,0);

        float desiredAngle = _directionTarget.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0,desiredAngle,0);
        
        transform.position = _directionTarget.transform.position + (rotation * _offset);
    }
}
