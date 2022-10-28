using UnityEngine;
public class TPPCamera : MonoBehaviour{

    public float Horizontal { set { horizontal += value * _horizontalSpeed; } }
    
    public float Vertical {
        set { 
            vertical += -value * _verticalSpeed;
            vertical = Mathf.Clamp(vertical,_veticalMin,_verticalMax);
        } 
    }

    public Transform DirectionTarget{private get; set;}
    
    [SerializeField] Vector3 _offset;

    [Header("RotationSpeed")]
    [SerializeField] float _horizontalSpeed;
    [SerializeField] float _verticalSpeed;
    
    [Header("Clamp Vertical Rotation")]
    [SerializeField] float _veticalMin;
    [SerializeField] float _verticalMax;

    float horizontal;
    float vertical;

    void Awake(){
        Cursor.lockState = CursorLockMode.Confined;
    }


    void LateUpdate(){
        if(DirectionTarget == null) return;

        //Set orientation for movement;
        DirectionTarget.transform.rotation = Quaternion.Euler(0,horizontal,0);


        CameraMovement();
        
        transform.LookAt(DirectionTarget);
    }

    private void CameraMovement(){

        Quaternion rotation = Quaternion.Euler(vertical,horizontal,0);
        
        transform.position = DirectionTarget.position + (rotation * _offset);
    }

}
