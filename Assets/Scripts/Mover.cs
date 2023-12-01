using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private Transform _transform;

    private void Start()
    {
        _transform= transform;
    }

    private void Update()
    {
       _transform.position = Vector3.MoveTowards(
           _transform.position, 
           _transform.position + Vector3.forward, 
           _speed * Time.deltaTime);
    }
}