using System;
using UnityEngine;
using Random = System.Random;

public class Tube : MonoBehaviour {
    [Header("Tube Settings")] [SerializeField]
    private float movementSpeed;

    [SerializeField] private float waitForDelete;

    private float _deleteTimer;

    private void Start() {
        HeightDifference();
    }

    private void Update() {
        if (Player.stopGame)
            movementSpeed = 0;
        else {
            transform.position += Vector3.left * (movementSpeed * Time.deltaTime);
            WaitForDeletion();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        var player = other.GetComponent<Player>();

        if (player != null) {
            CounterManager.Counter++;
        }
    }

    /// <summary>
    /// For more difficulty
    /// </summary>
    private void HeightDifference() {
        Random random = new Random();
        var difference = random.Next(-2, 3);

        transform.position = new Vector3(transform.position.x, transform.position.y + difference, transform.position.z);
    }

    /// <summary>
    /// For saving more data, by deleting unused gameObjects
    /// </summary>
    private void WaitForDeletion() {
        _deleteTimer += Time.deltaTime;

        if (_deleteTimer > waitForDelete) {
            Destroy(this.gameObject);
        }
    }

    private void SetValues() {
        movementSpeed = 0;
        _deleteTimer = 0;
    }
}