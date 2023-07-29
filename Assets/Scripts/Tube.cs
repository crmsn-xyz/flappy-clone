using System;
using UnityEngine;
using Random = System.Random;

public class Tube : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float waitForDelete;

    private float _deleteTimer;

    private void Start() {
        HightDifference();
    }

    private void Update() {
        transform.position += Vector3.left * (movementSpeed * Time.deltaTime);

        WaitForDeletion();
    }

    private void HightDifference() {
        Random random = new Random();
        var hightDifference = random.Next(-2, 3);

        transform.position =
            new Vector3(transform.position.x, transform.position.y + hightDifference, transform.position.z);
    }

    private void WaitForDeletion() {
        _deleteTimer += Time.deltaTime;

        if (_deleteTimer > waitForDelete) {
            Destroy(this.gameObject);
        }
    }
}