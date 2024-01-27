using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThowObject : MonoBehaviour
{
    public float throwForce = 15f;
    public GameObject throwableObject1, throwableObject2, throwableObject3, throwableObject4, throwableObject5;
    private GameObject currentObject;
    private int currentPos = 0;

    private Vector3 initialPosition;
    private List<GameObject> throwableObjects;

    // Start is called before the first frame update
    void Start()
    {
        throwableObjects = new List<GameObject> { throwableObject1, throwableObject2, throwableObject3, throwableObject4, throwableObject5 };
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollAmount = Input.mouseScrollDelta.y;

        if (Input.GetMouseButtonDown(0))
        {
            ThrowObject();
        }
        else if (scrollAmount != 0)
        {
            ChangeThrowableObject();
        }
    }

    void ThrowObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 clickPosition = hit.point;
            Vector3 throwDirection = (clickPosition - transform.position).normalized;

            // Destroy the current object if it exists
            if (currentObject != null)
            {
                Destroy(currentObject);
            }

            currentObject = Instantiate(throwableObjects[currentPos], initialPosition, Quaternion.identity);
            currentObject.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }
    }

    void ChangeThrowableObject()
    {
        // Destroy the current object if it exists
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        currentPos = (currentPos + 1) % throwableObjects.Count;
        currentObject = Instantiate(throwableObjects[currentPos], initialPosition, Quaternion.identity);
    }
}