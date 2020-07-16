using MyPlatformer.app;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.map {
    public class CoinsCollider : MonoBehaviour
    {
        public Chunk chunk;

        public void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Player" && App.isGameActive)
            {
               GameObject.Find("Map").GetComponent<App>().addCoins();
                chunk.DellCoins(gameObject);
            }

        }
    }
}