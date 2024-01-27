using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBehaviour : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    private Vector3 initialPosition;
    public GameObject cube;
    public float spawnIntervalMin = 2f;
    public float spawnIntervalMax = 5f;

    void Start()
    {
        // Store the initial position of the cube
        initialPosition = transform.position;
        // Invoke the SpawnCharacter function with a delay and repeat at intervals
        InvokeRepeating("SpawnCharacter", Random.Range(spawnIntervalMin, spawnIntervalMax), Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void SpawnCharacter()
    {
        Instantiate(cube, initialPosition, Quaternion.identity);
    }
}
