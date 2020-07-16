using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer.map;
using MyPlatformer.app;

namespace MyPlatformer.traps
{
    public class TrapSawLong : ATraps
    {
        [SerializeField] private GameObject _saw= default;
        [SerializeField] private float _speed = 10f;
        private Transform _sawTransform= default;
        private bool _left = false;
        private float _startX= default;
        private float _finishX = 5f;
        private int _angl = 60;

        private void Awake()
        {
            if(!_sawTransform)
                _sawTransform = _saw.transform;
        }

        public override void OnGo()
        {
            _startX = this.transform.position.x - 1f;
            _sawTransform.position = new Vector3(_startX, _sawTransform.position.y, _sawTransform.position.z);
            _finishX = _startX+5f;
            StartCoroutine(RotateSaw());
            StartCoroutine(Move());
        }

        IEnumerator RotateSaw()
        {
            while (App.isGameActive)
            {
                if (_left)
                {
                    if (_angl > -120) _angl -= 2;
                    _sawTransform.Rotate(new Vector3(_angl, 0, 0) * Time.fixedDeltaTime * _speed);
                }
                else
                {
                    if (_angl < 120) _angl += 2;
                    _sawTransform.Rotate(new Vector3(_angl, 0, 0) * Time.fixedDeltaTime * _speed);
                }

                yield return new WaitForFixedUpdate();
            }
        }

        IEnumerator Move()
        {
            if (App.isGameActive)
            {
                _angl = -40;
                _left = true;
                yield return new WaitForSeconds(2f);
                while (_sawTransform.position.x <= _finishX - .1f)
                {
                    _sawTransform.position = Vector3.Lerp(_sawTransform.position, new Vector3(_finishX, _sawTransform.position.y, _sawTransform.position.z), Time.fixedDeltaTime * _speed);
                    yield return new WaitForFixedUpdate();
                }
                _angl = -40;
                _left = true;

                yield return new WaitForSeconds(2f);

                while (_sawTransform.position.x >= _startX + .1f)
                {
                    _sawTransform.position = Vector3.Lerp(_sawTransform.position, new Vector3(_startX, _sawTransform.position.y, _sawTransform.position.z), Time.fixedDeltaTime * _speed);
                    yield return new WaitForFixedUpdate();
                }
                _angl = 40;
                _left = false;
                yield return new WaitForSeconds(2f);
            //    StartCoroutine(Move());
            }
        }
    }
}