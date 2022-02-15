using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeaperControl : MonoBehaviour
{
    float rand;
    public float cnt;

    private Vector3 startPos;
    
    public bool shoot = false;
    public bool move = false;
    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (shoot == true)
        {
            //Time for keaper to move
            cnt += Time.deltaTime;
            if (cnt > 0.2)
            {
                move = true;
            }

        }

        if (move == true)
        {
            //Random number to move
            rand = Random.Range(1, 4);

            if (rand == 1)
            {
                transform.position = new Vector3(transform.position.x - 0.50f, transform.position.y, transform.position.z);
            }
            else if (rand == 2)
            {
                transform.position = new Vector3(transform.position.x + 0.50f, transform.position.y, transform.position.z);
            }
            else { }

            move = false;
            shoot = false;
            done = true;
            cnt = 0;
        }
    }

    //Keaper Reset, Called From WorldManager
    public void Reset()
    {
        shoot = false;
        move = false;
        done = false;
        transform.position = startPos;
    }
}
