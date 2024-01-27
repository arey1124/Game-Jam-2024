using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThowableObjects : MonoBehaviour
{
    private Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Can change it to find some other unique identifier for an object, e.g. tag
        if(collision.gameObject.name.Contains("LaneCharacter"))
        {
            scoreScript.IncreaseScore();
        }
    }
}
