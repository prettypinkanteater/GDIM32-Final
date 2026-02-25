using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _interactDistance;
    private Transform _playerLocation;

    // Start is called before the first frame update
    void Start()
    {
        _playerLocation = Locator.Instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_playerLocation.position);
        if (Vector3.Distance(transform.position, _playerLocation.position) > _interactDistance)
        { 
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * _interactDistance);
    }
}
