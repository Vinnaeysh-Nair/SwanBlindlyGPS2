using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraManager : MonoBehaviour , IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int CameraLimitorX = 4;
    [SerializeField] private int CameraLimitorY = 4;
    private Image CameraJoystick;
    private Vector2 posInput;

    // Start is called before the first frame update
    void Start()
    {
        CameraJoystick = GetComponent<Image>();   
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(CameraJoystick.rectTransform, eventData.position, eventData.pressEventCamera, out posInput))
        {
            posInput.x = posInput.x / (CameraJoystick.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (CameraJoystick.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());

            //normalising values
            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            //joystickMove
            CameraJoystick.rectTransform.anchoredPosition = new Vector2(posInput.x * (CameraJoystick.rectTransform.sizeDelta.x / CameraLimitorX), posInput.y * (CameraJoystick.rectTransform.sizeDelta.y / CameraLimitorY));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        CameraJoystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float CamerainputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float CamerainputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
