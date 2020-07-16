using MyPlatformer.app;
using MyPlatformer.map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.traps
{

    public class TrapTurtle : ATraps
    {
        [SerializeField] private float _step = 4f;
        [SerializeField] private float _angle = 2f;
        [SerializeField] private bool _rigth = false;
        [SerializeField] private float _startX = default;
        private Transform _turtleTransform = default;
        private float _finishX = 2f;

        public override void OnGo()
        {
            _turtleTransform = GetComponentInParent<Transform>();
            if (_step == 0)
                return;
            if (_step > 0)
            {
                _rigth = true;
                _startX = _turtleTransform.position.x;
                _finishX = _startX + _step;
            }
            else
            {
                _startX = _startX - _step;
                _finishX = _turtleTransform.position.x;
            }

            StartCoroutine(Move());
        }
        IEnumerator Move()
        {
            while (App.isGameActive)
            {
                if (_rigth)
                {
                    while (_turtleTransform.position.x <= _finishX - .4f)
                    {
                        _turtleTransform.Translate(Vector3.forward * Time.fixedDeltaTime);
                        yield return new WaitForFixedUpdate();
                    }
                }
                else
                {
                    while (_turtleTransform.position.x >= _startX + .4f)
                    {
                        _turtleTransform.Translate(Vector3.forward * Time.fixedDeltaTime);
                        yield return new WaitForFixedUpdate();
                    }
                }

                int k = 0;
                int max = Mathf.RoundToInt(180 / Mathf.Abs(_angle));
                if (!_rigth)
                    _angle *= -1f;
                while (k < max)
                {
                    _turtleTransform.Rotate(0, _angle, 0);
                    k++;
                    yield return new WaitForFixedUpdate();
                }

                _rigth = !_rigth;
                yield return new WaitForSeconds(1f);
             
            }
            yield return null;
        }
    }

}