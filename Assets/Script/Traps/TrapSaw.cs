using MyPlatformer.app;
using MyPlatformer.map;
using MyPlatformer.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.traps
{
    public class TrapSaw : ATraps
    {
        [SerializeField] private float _speed = 4.5f;
        [SerializeField] private Transform _saw1Transform=default;
        [SerializeField] private Transform _saw2Transform= default;

        public override void OnGo()
        {
            StartCoroutine(RotateSaw());
        }


        IEnumerator RotateSaw()
        {
            while (App.isGameActive)
            {
                _saw1Transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime * _speed);
                _saw2Transform.Rotate(new Vector3(-90, 0, 0) * Time.deltaTime * _speed);
                yield return new WaitForFixedUpdate();
            }
            yield return null;
        }

      
    }
}
