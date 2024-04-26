using UnityEngine;

namespace Moving
{
    public class ObjectMover : MonoBehaviour
    {
        private readonly float _speed = 12f;
        private Vector3 _moveVector;

        private void Start()
        {
            _moveVector = new Vector3(0f, 0f, -_speed);
        }

        private void Update()
        {
            MoveObject();
        }
        
        private void MoveObject()
        {
            transform.Translate(_moveVector * Time.deltaTime);
        }
    }
}