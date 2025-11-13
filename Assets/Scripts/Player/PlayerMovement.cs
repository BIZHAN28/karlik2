using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movementDirection = Vector2.zero;
    private Animator _animator;
    private GameObject _view;
    private Rigidbody2D _rigidbody;

    [SerializeField] 
    private float _movementSpeed = 5f;

    private bool _w;
    private bool _a;
    private bool _d;
    private bool _s;

    void Start()
    {
        _view = transform.GetChild(0).gameObject;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        EventBus.Instance.Subscribe<WKeyPressedSignal>(OnWKeyPressed);
        EventBus.Instance.Subscribe<AKeyPressedSignal>(OnAKeyPressed);
        EventBus.Instance.Subscribe<DKeyPressedSignal>(OnDKeyPressed);
        EventBus.Instance.Subscribe<SKeyPressedSignal>(OnSKeyPressed);
        EventBus.Instance.Subscribe<WKeyReleasedSignal>(OnWKeyReleased);
        EventBus.Instance.Subscribe<AKeyReleasedSignal>(OnAKeyReleased);
        EventBus.Instance.Subscribe<DKeyReleasedSignal>(OnDKeyReleased);
        EventBus.Instance.Subscribe<SKeyReleasedSignal>(OnSKeyReleased);
    }

    void Update()
    {
        if (_movementDirection.magnitude > 0)
        {
            _animator.SetBool("isWalking", true);
            _movementDirection.Normalize();
            
            _rigidbody.velocity = _movementDirection * _movementSpeed;
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    void OnWKeyPressed(WKeyPressedSignal signal)
    {
        _w = true;
        _movementDirection.y = 1;
    }

    void OnAKeyPressed(AKeyPressedSignal signal)
    {
        _a = true;
        _movementDirection.x = -1;
        _view.GetComponent<SpriteRenderer>().flipX = true;
        transform.GetChild(1).transform.localScale = new Vector3(-1, 1, 1);
    }

    void OnDKeyPressed(DKeyPressedSignal signal)
    {
        _d = true;
        _movementDirection.x = 1;
        _view.GetComponent<SpriteRenderer>().flipX = false;
        transform.GetChild(1).transform.localScale = new Vector3(1, 1, 1);
    }

    void OnSKeyPressed(SKeyPressedSignal signal)
    {
        _s = true;
        _movementDirection.y = -1;
    }

    void OnWKeyReleased(WKeyReleasedSignal signal)
    {
        _w = false;
        if (_s)
        {
            _movementDirection.y = -1;
        }
        else
        {
            _movementDirection.y = 0;
        }
    }

    void OnAKeyReleased(AKeyReleasedSignal signal)
    {
        _a = false;
        if (_d)
        {
            _movementDirection.x = 1;
        }
        else
        {
            _movementDirection.x = 0;
        }
    }

    void OnDKeyReleased(DKeyReleasedSignal signal)
    {
        _d = false;
        if (_a)
        {
            _movementDirection.x = -1;
        }
        else
        {
            _movementDirection.x = 0;
        }
    }

    void OnSKeyReleased(SKeyReleasedSignal signal)
    {
        _s = false;
        if (_w)
        {
            _movementDirection.y = 1;
        }
        else
        {
            _movementDirection.y = 0;
        }
    }
}
