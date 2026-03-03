using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _interactDistance;
    [SerializeField] private Animator _animator;
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
            _animator.SetBool("Swimming", true);
            _animator.speed = .8f;
        }
        else
        {
            
            //_animator.SetBool("Swimming", false);
            _animator.speed = 0.5f;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * _interactDistance);
    }
}
