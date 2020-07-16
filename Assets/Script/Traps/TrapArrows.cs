using MyPlatformer.app;
using MyPlatformer.map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.traps
{
    public class TrapArrows : ATraps
    {
        [SerializeField] private GameObject _arrows =null;
        [SerializeField] private float _speed = 3f;
        private float _startY;
        private void Awake()
        {
            _startY = _arrows.transform.position.y;
            
        }
        public override void OnGo()
        {
            StartCoroutine(Move());
        }

        IEnumerator Move()
        {
            while (App.isGameActive){

                while (_arrows.transform.position.y <= 1.1f)
                {

                    _arrows.transform.position = Vector3.Lerp(_arrows.transform.position, new Vector3(_arrows.transform.position.x, 1.2f, _arrows.transform.position.z), Time.fixedDeltaTime * _speed);
                 
                    yield return new WaitForFixedUpdate();
                }

                while (_arrows.transform.position.y >= _startY)
                {

                    _arrows.transform.position = Vector3.Lerp(_arrows.transform.position, new Vector3(_arrows.transform.position.x, _startY - .1f, _arrows.transform.position.z), Time.fixedDeltaTime * _speed);

                    yield return new WaitForFixedUpdate();
                }

                yield return new WaitForSeconds(1f);
                StartCoroutine(Move());
            }
        }

    }

}