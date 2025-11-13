using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 _movementDirection = Vector2.zero;
    private Collider2D _playerCollider;
    private Rigidbody2D _rigidbody;
    private Vector2 _playerPosition;
    [SerializeField]
    private float _movementSpeed = 5f;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerCollider = GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<Collider2D>();
    }

    void Update()
    {
        _playerPosition = new Vector2(transform.position.x, transform.position.y);
        _movementDirection = Physics2D.ClosestPoint(transform.position, _playerCollider) - _playerPosition;
        _movementDirection.Normalize();
        if (_movementDirection.x < 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(1).transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_movementDirection.x > 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(1).transform.localScale = new Vector3(1, 1, 1);
        }
        _rigidbody.velocity = _movementDirection * _movementSpeed;
    }
}
