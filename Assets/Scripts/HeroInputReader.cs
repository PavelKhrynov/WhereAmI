using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WhereIAm.Scripts
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        private HeroInput _inputAction;

        private void Awake()
        {
            _inputAction = new HeroInput();
            _inputAction.Hero.Movement.performed += OnHorizontalMovement;
            _inputAction.Hero.Movement.canceled += OnHorizontalMovement;
            _inputAction.Hero.Interact.performed += OnInteract;
            _inputAction.Hero.Interact.canceled += OnInteract;
        }

        private void OnEnable()
        {
            _inputAction.Enable();
        }

        private void OnDestroy()
        {
            if (_inputAction != null)
            {
                _inputAction.Hero.Movement.performed -= OnHorizontalMovement;
                _inputAction.Hero.Movement.canceled -= OnHorizontalMovement;
                _inputAction.Hero.Interact.performed -= OnInteract;
                _inputAction.Hero.Interact.canceled -= OnInteract;
            }
        }


        public void OnHorizontalMovement(InputAction.CallbackContext context)
        {
            var _direction = context.ReadValue<Vector2>();
            _hero?.SetDirection(_direction);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero?.Interact();
            }
        }
    }
}