using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    [SerializeField] private float velocity;

    private float _gravity;

    private Rigidbody2D _rigidbody2D;

    public static bool stopGame = false;
    public static bool startGame = false;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        _gravity = _rigidbody2D.gravityScale;
        _rigidbody2D.gravityScale = 0;
    }

    private void Update() {
        if (!startGame)
            MakeGameStart();

        if (Input.GetKeyDown(KeyCode.Space) && (!stopGame || startGame)) {
            _rigidbody2D.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        var tube = other.collider.GetComponentInParent<Tube>();
        var floor = other.collider.name == "BottomBorder" || other.collider.name == "TopBorder";

        if (tube != null) {
            stopGame = true;
        }
        else if (floor) {
            stopGame = true;
        }
    }

    private void MakeGameStart() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            startGame = true;
            _rigidbody2D.gravityScale = _gravity;
        }

    }
}