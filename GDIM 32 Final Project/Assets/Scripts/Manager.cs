using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _interactDistance;

    [SerializeField] public Transform _testingLocation;
    private Transform _playerLocation;
    // Start is called before the first frame update
    void Start()
    {
        _playerLocation = _testingLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _testingLocation.position) > _interactDistance)
        {
            transform.LookAt(_testingLocation.position);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray);
    }
}
