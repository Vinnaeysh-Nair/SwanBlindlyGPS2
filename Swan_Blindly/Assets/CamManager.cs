using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CamManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int CamJoystickLimitorX = 4;
    [SerializeField] private int CamJoystickLimitorY = 4;
    private Image CamImgJoystickBg;
    private Image CamImgJoystick;
    private Vector2 CamPosInput;

    // Start is called before the first frame update
    void Start()
    {
        CamImgJoystickBg = GetComponent<Image>();
        CamImgJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(CamImgJoystickBg.rectTransform, eventData.position, eventData.pressEventCamera, out CamPosInput))
        {
            CamPosInput.x = CamPosInput.x / (CamImgJoystickBg.rectTransform.sizeDelta.x);
            CamPosInput.y = CamPosInput.y / (CamImgJoystickBg.rectTransform.sizeDelta.y);
            Debug.Log(CamPosInput.x.ToString() + "/" + CamPosInput.y.ToString());

            //normalising values
            if (CamPosInput.magnitude > 1.0f)
            {
                CamPosInput = CamPosInput.normalized;
            }

            //joystickMove
            CamImgJoystick.rectTransform.anchoredPosition = new Vector2(CamPosInput.x * (CamImgJoystickBg.rectTransform.sizeDelta.x / CamJoystickLimitorX), CamPosInput.y * (CamImgJoystickBg.rectTransform.sizeDelta.y / CamJoystickLimitorY));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CamPosInput = Vector2.zero;
        CamImgJoystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (CamPosInput.x != 0)
            return CamPosInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (CamPosInput.y != 0)
            return CamPosInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
