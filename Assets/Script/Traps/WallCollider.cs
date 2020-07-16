using MyPlatformer.app;
using MyPlatformer.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.map
{
    public class WallCollider : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Player" && App.isGameActive)
            {
                other.gameObject.GetComponent<Player>().isWall();
            }

        }
    }

}