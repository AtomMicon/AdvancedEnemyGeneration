using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour
{
    [SerializeField] private Vector3[] _roadPoints;
    [SerializeField] private float _moveSpeed = 2f;

    private int _pointInt;

    void Start()
    {
        _pointInt = 0;
    }

    private void OnDrawGizmos()
    {
        foreach (var roadPoint in _roadPoints)
        {
            DrawSpawnPointGizmos(roadPoint, Color.green);
        }
    }

    private void DrawSpawnPointGizmos(Vector3 position, Color color)
    {
        float sphereRadius = 0.3f;

        Gizmos.color = color;
        Gizmos.DrawSphere(position, sphereRadius);
    }

    private void Update()
    {
        if (_roadPoints == null || _roadPoints.Length == 0)
        {
            return;
        }

        if (Vector3.Distance(transform.position, _roadPoints[_pointInt]) <= 0.2f ) 
        {
            _pointInt++;

            if (_pointInt >= _roadPoints.Length)
            {
                _pointInt = 0;
            }
        }

        else
        {
            Vector3 direction = (_roadPoints[_pointInt] - transform.position).normalized;
            transform.position += direction * _moveSpeed * Time.deltaTime;
        }
    }
}
