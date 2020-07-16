using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyPlatformer.player
{
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image bgImg = default;
        [SerializeField] private Image joystickImg = default;
        private Vector3 inputVector = default;

        public bool isJump = false;
        public Player Player = default;

        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (Player == null)
            {           
                   Debug.LogError("Player not set to controller");
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
            {
                pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
         
                inputVector = new Vector3(pos.x * 2 + 1, 0,0);
                inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

                //Move joystick IMG
                joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputVector = Vector3.zero;
            joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        }
        public float Horizontal()
        {
            if (inputVector.x != 0)
                return inputVector.x;
            else
                return Input.GetAxis("Horizontal");
        }

      /*  public float Vertical()
        {
            if (inputVector.z != 0)
                return inputVector.z;
            else
              return Input.GetAxis("Vertical");
        }*/

     
        public void Jump(){
            if (!isJump)
                isJump = true;
        }
    }
}