using MyPlatformer.app;
using MyPlatformer.map;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject view = default;
        [SerializeField] private float _move = 0f;
        public float JumpForce = 30;
        public float MaxSpeed = 5f;
        public bool isWater = false;
        public bool isStop = false;
        public int exstraJumps = 0;
        public int extraJumpsValue = 1;

        private Transform _transform = default;
        private Rigidbody _rigidbody = default;
        private MapGenerator _mapGenirator = default;
        private Animator _animatorController = default;
        private bool _isOnGround = false;
        private bool _isOnWall = false;
        private bool _isJump = true;
        private Vector3 _startPosition;
        private App app = default;
        private Transform _vTransform = default;

        private void Start()
        {
            _vTransform = view.GetComponent<Transform>();
            GameObject _map = GameObject.Find("Map");
            _animatorController = view.GetComponent<Animator>();
            if (_map)
            {
                _mapGenirator = _map.GetComponent<MapGenerator>();
                app = _map.GetComponent<App>();
               _map = null;
            }
            exstraJumps = extraJumpsValue;
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();

            _startPosition = _transform.position;
           
        }

        public void OnStartPosition(bool _dell)
        {
           
            if (_dell)
            {
                if (app.dellLife())
                {
                    _transform.position = new Vector3(_mapGenirator.chanks[0].startPositionX * 1f + 1f, _mapGenirator.chanks[0].startPositionY, 0f);
                }
            }
          
               StartCoroutine(onGo());
        }

        IEnumerator onGo()
        {
            yield return new WaitForSeconds(.4f);
            isStop = false;
            isWater = false;
        }
       
        private void Update()
        {
            if (_vTransform)
            {
                _vTransform.localPosition = Vector3.zero;
                _vTransform.localRotation = Quaternion.identity;
            }
            if (!App.isGameActive || isStop)
            {
                return;
            }
            if (isWater)
            {
               
                onStoped();
            }
            if (_isJump)
            {
                if (_rigidbody.velocity.y == 0)
                {

                    _isOnGround = true;
                    exstraJumps = extraJumpsValue;
                    _isJump = false;
                    _animatorController.SetBool("Jump", false);
                }
                else
                {
                    if(!_animatorController.GetBool("Jump"))
                      _animatorController.SetBool("Jump", true);
                    _isOnGround = false;
                }
            }
            else _isOnGround = true;
   
            if (_isOnGround)
            {
                _isOnWall = false;
            }
            else if (_isOnWall && _move != 0)
            {
                onStoped();
            }
            if (_mapGenirator && _transform.position.x + 3 >= _mapGenirator.positionX)
                {
                    _mapGenirator.createChank();
                }
            if (_mapGenirator && _move < 0 && _transform.position.x < _mapGenirator.cameraLeftPosition + 3)
            {
                _move = 0;
            }
            if (!_animatorController.GetBool("Jump")){
                if (_move == 0)
                {
                    if (_animatorController.GetBool("Walk"))
                        _animatorController.SetBool("Walk", false);
                }
                else
                {
                    if (!_animatorController.GetBool("Walk"))
                        _animatorController.SetBool("Walk", true);
                }
            }
            _rigidbody.velocity = new Vector3(_move * MaxSpeed, _rigidbody.velocity.y, 0f);
        }

        private void onStoped()
        {
            if (_move > 0) _move -= .2f;

            if (_move < 0) _move += .2f;
        }

        public void isWall()
        {
            if (!_isOnGround)
                _isOnWall = true;
        }

        public void NotDown()
        {
            if (_move != 0)
            {
                _move = 0;
            }

        }
        private bool isRight = true;
        public void Flip(float move)
        {
            if (move != 0)
                if( (move>0 && !isRight) || (move<0 && isRight))
            {

                _transform.localScale = new Vector3(_transform.localScale.x, _transform.localScale.y, _transform.localScale.z * (-1));
                    isRight = !isRight;

                }
            _move = move;
        }


        public void Jump()
        {
            if (exstraJumps > 0 && !isWater && _isOnGround)
            {
                _rigidbody.velocity = Vector3.up * JumpForce;
                _animatorController.SetBool("Jump",true);
                exstraJumps--;
                _isJump = true; 
                _animatorController.SetBool("Walk", false);
            }

        }

    }

}