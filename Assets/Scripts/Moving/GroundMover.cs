using DG.Tweening;
using UnityEngine;

namespace Moving
{
    public class GroundMover : MonoBehaviour
    {
        public float speed = 10f;
        private Vector3 _moveVector;

        private void Start()
        {
            _moveVector = new Vector3(0f, 0f, -speed);
        }

        private void Update()
        {
            MoveObject();
            Respawn();
        }
        
        private void MoveObject()
        {
            transform.Translate(_moveVector * Time.deltaTime);
        }
        
        private void Respawn()
        {
            if (transform.position.z < -20)
            {
                transform.DOMoveY(-90f, 1.5f);
            }
            
            if (transform.position.z < -24f)
            {
                transform.position = new Vector3(0f, -90f, 48f);
                transform.DOMoveY(0f, 1.5f);
                ChangeScale();
            }
        }
        
        private void ChangeScale()
        {
            transform.DOScale(new Vector3(12f, 2f, Random.Range(17f, 20f)), 1f);
        }
    }
}