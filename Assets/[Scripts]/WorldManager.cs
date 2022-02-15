using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public BallPhysics ball;
    public ScoreMan score;
    public KeaperControl keeper;

    public float PlayerScore;
    public float KeeperScore;
    public float ShootsLeft = 5;

    public float BAngle;
    public float BPower;
    public float BDirection;

    [SerializeField]
    private float timer = 0;
    [SerializeField]
    float rand;

    // NEED TO FIX SHOOTING, SHOOTING IS CALLED ONLY ONCE BECAUSE THE BOOL IS SET TO FALSE AFTER USING, SEE BALL SCRIPT FOR MORE NOTES

    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        KeeperScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore = ball.PlayerGoals;
        BAngle = ball.angle;
        BDirection = ball.m_rotationAngle;
        BPower = ball.force;

        //Shooting
        if (Input.GetKey(KeyCode.R))
        {
            if(ShootsLeft != 0)
            {
                //Keeper movement
                if (keeper.shoot == false && keeper.done == false)
                    keeper.shoot = true;

                if (ball.m_bIsGrounded)
                {
                    ball.m_bIsGrounded = false;  
                    ball.OnKickBall(ball.force, ball.angle);
                }
            }
        }

        //Soft Reset
        if (Input.GetKey(KeyCode.C))
        {
            ball.Reset();
            keeper.Reset();
            timer = 0;
        }

        //Game Reset
        if (Input.GetKey(KeyCode.T))
        {
            ball.Reset();
            keeper.Reset();
            ball.PlayerGoals = 0;
            KeeperScore = 0;
            timer = 0;
            ShootsLeft = 5;
        }

        //Timer For Reset
        if (ball.m_bIsGrounded == false)
        {
            timer += Time.deltaTime;
        }

        //Counting Shoots
        if (ShootsLeft!=0)
        {
            if (timer >= 4)
            {
                ball.Reset();
                keeper.Reset();
                timer = 0;
                ShootsLeft--;
                rand = Random.Range(1, 4);
                if (rand == 1)
                {

                }
                else
                {
                    KeeperScore++;
                }
            }
        }
    }
}
