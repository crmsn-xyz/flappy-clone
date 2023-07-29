using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {
    public static int Counter { get; set; }

    [SerializeField] private TMP_Text counterText;

    private void Awake() {
        Counter = 0;
    }

    private void Update() {
        IncreaseCounter();
    }

    private void IncreaseCounter() {
        counterText.text = Counter.ToString();
    }
}
