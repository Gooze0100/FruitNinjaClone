using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {

        Blade b = collider.GetComponent<Blade>();

        if (!b) {

            return;
        }

        FindObjectOfType<GameManager>().OnBombHit();

    }
}