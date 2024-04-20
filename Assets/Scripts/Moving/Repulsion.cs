using UnityEngine;

namespace Moving
{
    public class Repulsion : MonoBehaviour
    {
        private readonly float _repulsionForce = 30f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                RepulseSlime(other.GetComponent<Rigidbody>());
            }
        }

        private void RepulseSlime(Rigidbody rb)
        {
            Debug.Log("Slime repulsed");
            var repulsionDirection = new Vector3(0, 1, -2);
            rb.AddForce(repulsionDirection * _repulsionForce, ForceMode.Impulse);
        }
    }
}