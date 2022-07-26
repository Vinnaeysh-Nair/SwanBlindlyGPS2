using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick_Controls : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [Header("Editable components")]
    [SerializeField] private float StickLimitorX;
    [SerializeField] private float StickLimitorY;

    private Image JoystickBg;
    private Image Joystick;
    private Vector2 posInput;
    // Start is called before the first frame update
    void Start()
    {
        JoystickBg = GetComponent<Image>();
        Joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBg.rectTransform, eventData.position, eventData.pressEventCamera, out posInput))
        {
            posInput.x = posInput.x / (JoystickBg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (JoystickBg.rectTransform.sizeDelta.y);
            //@Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());

            // normalizing
            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }


            //JoystickMove
            Joystick.rectTransform.anchoredPosition = new Vector2(posInput.x * (JoystickBg.rectTransform.sizeDelta.x / StickLimitorX) , posInput.y * (JoystickBg.rectTransform.sizeDelta.y / StickLimitorY));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        Joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
