using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limits : MonoBehaviour
{
    private Transform transform;
    public Vector2 hrango = Vector2.zero;
    public Vector2 vrango = Vector2.zero;
    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, vrango.x, vrango.y),
            Mathf.Clamp(transform.position.y, hrango.x, hrango.y),
            transform.position.z
            );
    }
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
