using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableData data;
    public MeshFilter filter;
    public MeshRenderer rend;

    void Start()
    {
        //Set the properties from data.
        transform.localScale = Vector3.one * data.scale;
        filter.mesh = data.mesh;
        rend.material.color = data.color;
    }

    void Update()
    {
        //Rotate the collectable.
        transform.Rotate(Vector3.up, data.spin_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        data.PrintPoints();
        Destroy(this.gameObject);
    }
}
