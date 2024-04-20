using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class GroundReSpawner : MonoBehaviour
    {
        private ObstaclesSpawner _obstaclesSpawner;
        
        [Inject]
        private void Construct(ObstaclesSpawner obstaclesSpawner)
        {
            _obstaclesSpawner = obstaclesSpawner;
        }
        
        private void Update()
        {
            Respawn();
        }

        private void Respawn()
        {
            if (transform.position.z < -20)
            {
                Hide();
                StartCoroutine(ChangeScaleCoroutine(24f, 0f));
            }
            
            if (transform.position.z < -24f)
            {
                Show();
                StartCoroutine(ChangeScaleCoroutine(8f, 2f));
            }
        }

        private void Hide()
        {
            transform.DOMoveY(-90f, 1.5f);
        }

        private void Show()
        {
            transform.position = new Vector3(0f, -90f, 48f);
            _obstaclesSpawner.SpawnObstacle();
            RandomizeYPosition();
        }

        private void RandomizeYPosition()
        {
            transform.DOMoveY(Random.Range(-10, 5), 1.5f);
        }

        private IEnumerator ChangeScaleCoroutine(float zValue, float delay)
        {
            yield return new WaitForSeconds(delay);
            transform.DOScale(new Vector3(10.5f, 2f, zValue), 1f);
        }
    }
}