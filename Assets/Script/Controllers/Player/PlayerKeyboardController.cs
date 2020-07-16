using MyPlatformer.app;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.player
{
    public class PlayerKeyboardController : MonoBehaviour
    {
        public Player Player;
        private VirtualJoystick joystick;
        private void Start()
        {
            joystick = GameObject.Find("VirtualJoystick").GetComponent<VirtualJoystick>();
            Player = Player ?? GetComponent<Player>();
            if (Player == null)
            {
                Debug.LogError("Player not set to controller");
            }
        }

        private void Update()
        {
            if (Player != null || App.isGameActive)
            {
                Player.Flip(Input.GetAxis("Horizontal"));
                if (joystick)
                {
                    Player.Flip(joystick.Horizontal());
                    if (joystick.isJump)
                    {
                        Player.Jump();
                        joystick.isJump = false;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player.Jump();
                }
            }
        }
    }
}