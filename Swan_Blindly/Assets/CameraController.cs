using UnityEngine;
//using Cinemachine;
public class CameraController : MonoBehaviour
{
    //Cam components
    //private CinemachineFreeLook Cinemachinefreelook;
    private CameraManager camManager;
    private GameObject ThirdPersonCam;

    //Cam move
    private float CaminputX;
    private float CaminputZ;
    private Vector3 v_CamMovement;
    [SerializeField] private float CamMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
