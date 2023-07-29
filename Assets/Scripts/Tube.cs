using UnityEngine;

public class Tube : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float waitForDelete;

    private float _deleteTimer;

    private void Update() {
        transform.position += Vector3.left * (movementSpeed * Time.deltaTime);

        _deleteTimer += Time.deltaTime;

        if (_deleteTimer > waitForDelete) {
            Destroy(this.gameObject);
        }
    }
}