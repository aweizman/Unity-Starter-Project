using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    private float speed = 40.0f;
    private float bound = 25.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > bound || transform.position.z < -bound || transform.position.x > bound || transform.position.x < -bound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(gameObject.tag+"Enemy")) //if spell hits enemy with same type, destroy both enemy and spell.
        {
            Destroy(other.gameObject);
        }
        //otherwise, only destroy spell
        Destroy(gameObject);
    }

}
