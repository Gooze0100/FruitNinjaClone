using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;

    private Rigidbody2D rb;
    private Vector3 lastMousePoss;
    private Vector3 mouseVelo;

    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        col.enabled = IsMouseMoving();

        SetBladeToMouse();
    }

    private void SetBladeToMouse() {
        var  mousePoss = Input.mousePosition;
        
        // distance of 10 units from the camera
        mousePoss.z = 10; 

        rb.position = Camera.main.ScreenToWorldPoint(mousePoss);
    }

    private bool IsMouseMoving() {
        Vector3 curMousePoss = transform.position;
        // it will tell lenght between values
        float traveled = (lastMousePoss - curMousePoss).magnitude;
        lastMousePoss = curMousePoss;

        if (traveled > minVelo)
            return true;
        else
            return false;

    }
}
