using UnityEngine;

namespace Moving
{
    public class ObjectMover : MonoBehaviour
    {
        private Vector3 _moveVector;

        private void Start()
        {
            SetSpeed(19f);
        }

        private void SetSpeed(float speed)
        {
            _moveVector = new Vector3(0f, 0f, -speed);
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