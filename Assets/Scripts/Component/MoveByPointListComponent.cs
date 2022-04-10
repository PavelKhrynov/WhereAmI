﻿using System;
using System.Collections;
using UnityEngine;

namespace WhereIAm.Scripts.Component
{
    public class MoveByPointListComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _targetList;
        [SerializeField] private bool _isLoop = false;
        [SerializeField] private float _moveSpeed = 1f;
        //[SerializeField] private bool _isTurnBack = false; // TODO: implement it later

        private Vector2 _nextPosition;
        private int _currentPositionIndex = 0;

        private bool _isMoving = false;

        private void FixedUpdate()
        {
            if (_isMoving && _nextPosition != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, _nextPosition, _moveSpeed * Time.deltaTime);
                 
                if (Mathf.Abs(transform.position.magnitude - _nextPosition.magnitude) <= 0.001f)
                {
                    MoveToNextPosition();
                }
            }
        }

        public void StartMove()
        {
            if (_nextPosition == Vector2.zero)
            {
                _nextPosition = _targetList[_currentPositionIndex].transform.position;
            }

            _isMoving = true;
        }

        public void StopMove()
        {
            _isMoving = false;
        }


        private void MoveToNextPosition()
        {
            if (_currentPositionIndex >= _targetList.Length - 1)
            {
                if (_isLoop)
                {
                    _currentPositionIndex = -1;
                }
                else
                {
                    _isMoving = false;
                }
            }

            if (_isMoving)
            {
                _currentPositionIndex++;
                _nextPosition = _targetList[_currentPositionIndex].transform.position;
            }
        }
    }
}