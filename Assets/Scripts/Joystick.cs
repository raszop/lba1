using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    public event Action OnJoystickRelease;

    [SerializeField]
    private Image backgroundImage;
    [SerializeField]
    private Image joystickImage;
    [SerializeField]
    private float maxJoystickOffset;

    private Vector2 pos;

    private float bgImageSizeX;
    private float bgImageSizeY;
    [SerializeField]
    private Vector2 inputDirection;

    public Vector2 InputDirection { get => inputDirection; set => inputDirection = value; }

    private void Start()
    {
        bgImageSizeX = backgroundImage.rectTransform.sizeDelta.x;
        bgImageSizeY = backgroundImage.rectTransform.sizeDelta.y;

        pos = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= bgImageSizeX;
            pos.y /= bgImageSizeY;
            inputDirection = new Vector2(pos.x, pos.y);
            inputDirection = inputDirection.magnitude > 1 ? inputDirection.normalized : inputDirection;

            joystickImage.rectTransform.anchoredPosition = new Vector2(inputDirection.x * (bgImageSizeX/maxJoystickOffset), inputDirection.y * (bgImageSizeY/maxJoystickOffset));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("shit");
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector2.zero;

        OnJoystickRelease?.Invoke();
    }
}
