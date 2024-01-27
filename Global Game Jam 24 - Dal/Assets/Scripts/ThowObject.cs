using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThowObject : MonoBehaviour
{
    public float throwForce = 15f;
    public GameObject cubePrefab;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 clickPosition = hit.point;

                Vector3 throwDirection = (clickPosition - transform.position).normalized;

                GameObject newCube = Instantiate(cubePrefab, initialPosition, Quaternion.identity);
                print(throwDirection);
                newCube.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce, ForceMode.Impulse);
            }
        }
    }
}
