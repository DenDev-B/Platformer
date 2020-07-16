using MyPlatformer.app;
using MyPlatformer.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.traps
{
    public class TrapCollider : MonoBehaviour
    {
        private Collider player;
        public void OnTriggerEnter(Collider other)
        {
            if (!player && App.isGameActive)
            {
                if (other.tag == "Player" && !other.GetComponent<Player>().isStop)
                {
                    player = other;
                    other.GetComponent<Player>().isStop = true;
                    StartCoroutine(OnRestartPlayerPosition());
                }
            }
        }

        IEnumerator OnRestartPlayerPosition()
        {
            yield return new WaitForSeconds(.3f);
            player.GetComponent<Player>().OnStartPosition(true);
            player.GetComponent<Player>().isStop = true;
            player = null;
        }
    }
}
