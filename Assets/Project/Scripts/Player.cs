using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    [SerializeField] private float velocity;

    private Rigidbody2D _rigidbody2D;

    public static bool stopGame = false;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && stopGame == false) {
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
}