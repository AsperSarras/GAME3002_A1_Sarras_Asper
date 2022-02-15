using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMan : MonoBehaviour
{
    // Start is called before the first frame update

    private Renderer renderer;

    void Start()
    {
        //MakesGoalZoneInvisible
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
