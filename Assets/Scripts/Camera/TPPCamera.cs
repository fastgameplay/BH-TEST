using UnityEngine;
public class TPPCamera : MonoBehaviour{

    public float Horizontal {set {horizontal = value * _rotationSpeed;} }
    float horizontal;
    public Transform DirectionTarget{private get; set;}
    [SerializeField] float _rotationSpeed;
    [SerializeField] Vector3 _offset;

    void LateUpdate(){
        if(DirectionTarget == null) return;
        CameraMovement();
        
        transform.LookAt(DirectionTarget);
    }

    private void CameraMovement(){
        DirectionTarget.transform.Rotate(0,horizontal,0);

        float desiredAngle = DirectionTarget.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0,desiredAngle,0);
        
        transform.position = DirectionTarget.position + (rotation * _offset);
    }
}
