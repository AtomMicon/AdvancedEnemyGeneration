using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;

    private Target _target;

    public void TargetInitialize(Target target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position += _target.transform.position * _moveSpeed * Time.deltaTime;
        }
    }
}
