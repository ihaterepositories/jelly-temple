using UnityEngine;

namespace Animations
{
    public class RandomizeRotationForChildObjects : MonoBehaviour
    {
        private readonly float _minRotationValue = 10f;
        private readonly float _maxRotationValue = 50f;

        private void Start()
        {
            RandomizeRotation();
        }

        private void RandomizeRotation()
        {
            foreach (Transform child in transform)
            {
                float xRotation = Random.Range(_minRotationValue, _maxRotationValue);
                float yRotation = Random.Range(_minRotationValue, _maxRotationValue);
                
                child.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            }
        }
    }
}
