using UnityEngine;

namespace Player
{
    public class MovementBehavior : MonoBehaviour
    {
        [SerializeField]
        private bool invertXAxis = false; 
    
        [SerializeField]
        private bool canMove = true,
            canRotate = true;
    
        [SerializeField, Range(0.0f, 500.0f)]
        private float moveSpeed = 20.0f,
            rotateSpeed = 20.0f;

        private void Update()
        {
            if (canMove)
            {
                MoveVertical(Input.GetAxis("Vertical"));
                MoveHorizontal(Input.GetAxis("Horizontal"));
            }

            if (canRotate)
            {
                MoveYaw(Input.GetAxis("Yaw"));
            }
        }

        private void MoveVertical(float _verticalValue)
        {
            transform.position += transform.forward * (_verticalValue * Time.deltaTime * moveSpeed);
        }

        private void MoveHorizontal(float _horizontalValue)
        {
            transform.position += transform.right * (_horizontalValue * Time.deltaTime * moveSpeed);
        }

        private void MoveYaw(float _yawValue)
        {
            float _directionValue = invertXAxis ? -_yawValue : _yawValue;
            transform.Rotate(transform.up * (_directionValue * 5.0f * Time.deltaTime * rotateSpeed));
        }
    }
}