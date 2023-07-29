using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    [SerializeField] private float velocity;

    private Rigidbody2D _rigidbody2D;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _rigidbody2D.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        var tube = other.collider.GetComponentInParent<Tube>();
        var floor = other.collider.name == "BottomBorder" || other.collider.name == "TopBorder";

        if (tube != null) {
            var tubes = FindObjectsByType<Tube>(FindObjectsSortMode.None);

            foreach (var pipe in tubes) {
                pipe.SetMovementSpeed(0);
                pipe.SetDeleteTimer(0);
            }
                
            velocity = 0;
        }
        else if (floor) {
            velocity = 0;
        }
    }
}