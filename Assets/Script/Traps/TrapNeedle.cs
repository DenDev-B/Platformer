using MyPlatformer.app;
using MyPlatformer.map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.traps
{
    public class TrapNeedle : ATraps
    {
        [SerializeField] private GameObject _needle= default;
        [SerializeField] private float _speed = 3f;
        private float _startY= default;
        private float _finishY = -.4f;
        private void Awake()
        {
            _startY = _needle.transform.position.y + .1f;
        }

        public override void OnGo()
        {
            StartCoroutine(Move());
        }

        IEnumerator Move()
        {
            while (App.isGameActive)
            {

                while (_needle.transform.position.y >= _finishY + .1f)
                {
                    _needle.transform.position = Vector3.Lerp(_needle.transform.position, new Vector3(_needle.transform.position.x, _finishY, _needle.transform.position.z), Time.fixedDeltaTime * _speed);
                    yield return new WaitForFixedUpdate();
                }

                while (_needle.transform.position.y <= _startY - .1f)
                {
                    _needle.transform.position = Vector3.Lerp(_needle.transform.position, new Vector3(_needle.transform.position.x, _startY, _needle.transform.position.z), Time.fixedDeltaTime * _speed);
                    yield return new WaitForFixedUpdate();
                }

                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

}