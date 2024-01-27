using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public Transform respawnTrigger;

    public float respawnYCoordinate = 0f;

    void Update()
    {
        // Move the cube along the X-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the respawn key is pressed (e.g., R key)
        // Check if the object has reached the specified Y-coordinate
        if (respawnTrigger.position.y <= respawnYCoordinate)
        {
            // Call a method to respawn the scene
            RespawnScene();
        }
    }

    void RespawnScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}
