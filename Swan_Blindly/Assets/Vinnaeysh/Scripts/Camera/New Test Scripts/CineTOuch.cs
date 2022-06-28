using UnityEngine;
using Cinemachine;

public class CineTOuch : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cineCam;

    [SerializeField] CamTouchField touchField;

    [SerializeField] float SensitivityX = 2f;
    [SerializeField] float SensitivityY = 2f;
    
    // Update is called once per frame
    void Update()
    {
        cineCam.m_XAxis.Value += touchField.TouchDist.x *  SensitivityX * Time.deltaTime;
        cineCam.m_YAxis.Value += touchField.TouchDist.y *  SensitivityY * Time.deltaTime;
    }
}
