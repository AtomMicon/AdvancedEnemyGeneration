using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _destroyDistance = 0.4f;

    private Target _target;

    public void TargetInitialize(Target target)
    {
        _target = target;
    }

    private void Update()
    {

        if (_target != null)
        {
            float distance = Vector3.Distance(transform.position, _target.transform.position);

            if (distance <= _destroyDistance)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 direction = (_target.transform.position  - transform.position).normalized;
            transform.position += direction * _moveSpeed * Time.deltaTime;
        }
    }
}
