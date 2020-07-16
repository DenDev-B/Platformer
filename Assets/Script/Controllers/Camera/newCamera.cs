using MyPlatformer.map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.player
{
    public class newCamera : MonoBehaviour
    {
        public float dampTime = 0.15f;
        private Vector3 velocity = Vector3.zero;
        private Transform player;
        private MapGenerator _mapGenirator;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            GameObject _map = GameObject.Find("Map");
            if (_map)
            {
                _mapGenirator = _map.GetComponent<MapGenerator>();
                _map = null;
            }
        }
        private void Update()
        {
            if (player)
            {

                Vector3 point = Camera.main.WorldToViewportPoint(new Vector3(player.position.x, 2.5f, player.position.z));

                Vector3 delta = new Vector3(player.position.x, 2.5f, player.position.z) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
                if (_mapGenirator && player.position.x < _mapGenirator.cameraLeftPosition + 8)
                    delta = new Vector3(_mapGenirator.cameraLeftPosition + 8, 2.5f, player.position.z) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
                Vector3 destination = transform.position + delta;


                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

            }

        }
    }

}