using UnityEngine;
using Cinemachine;

public class CineTOuch : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] CinemachineFreeLook cineCam;
    [SerializeField] CamTouchField touchField;

    [Header("SensitivyController")]
    [SerializeField] float SensitivityX = 0.1f;
    [SerializeField] float SensitivityY = 0.1f;

    [Header("SmoothenerController")]
    [SerializeField] float XSmoothener = 10f;
    [SerializeField] float YSmoothener = 0.1f;
    
    // Update is called once per frame
    void Update()
    {
        cineCam.m_XAxis.Value += touchField.TouchDist.x *  SensitivityX * XSmoothener * Time.deltaTime;
        cineCam.m_YAxis.Value += touchField.TouchDist.y *  SensitivityY * YSmoothener * Time.deltaTime;
    }
}
