using MyPlatformer.app;
using MyPlatformer.player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.traps
{
    public class TrapWater : MonoBehaviour
    {
        private Collider player;

        private void OnTriggerEnter(Collider other)
        {
            if (App.isGameActive && !player)
            {
                if (other.tag == "Player" && !other.GetComponent<Player>().isWater)
                {
                    player = other;
                    other.GetComponent<Player>().isWater = true;
                    StartCoroutine(OnRestartPlayerPosition());
                }
            }
        }

        IEnumerator OnRestartPlayerPosition()
        {
            yield return new WaitForSeconds(2f);
            player.GetComponent<Player>().OnStartPosition(true);
            player.GetComponent<Player>().isWater = false;
            player = null;
        }
    }

}