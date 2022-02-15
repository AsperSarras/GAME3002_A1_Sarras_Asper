using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMan : MonoBehaviour
{
    public Text playerGoalsText;
    public Text keeperGoalsText;
    public Text triesLeft;
    public Text winLose;

    public Text DirectionT;
    public Text AngleT;
    public Text PowerT;

    public WorldManager WorldManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player,Keaper,Tries Count
        playerGoalsText.text = WorldManager.PlayerScore.ToString();
        keeperGoalsText.text = WorldManager.KeeperScore.ToString();
        triesLeft.text = WorldManager.ShootsLeft.ToString();

        //Direction
        if (WorldManager.BDirection < -10)
        {
            DirectionT.text = @"\\\|   ";
            DirectionT.color = Color.red;
        }
        else if (WorldManager.BDirection < -6)
        {
            DirectionT.text = @" \\|   ";
            DirectionT.color = Color.blue;
        }
        else if (WorldManager.BDirection < -3)
        {
            DirectionT.text = @"  \|   ";
            DirectionT.color = Color.green;
        }

        else if (WorldManager.BDirection > 10)
        {
            DirectionT.text = "   |/// ";
            DirectionT.color = Color.red;
        }
        
        else if (WorldManager.BDirection > 6)
        {
            DirectionT.text = "   |// ";
            DirectionT.color = Color.blue;
        }
        else if (WorldManager.BDirection > 3)
        {
            DirectionT.text = "   |/  ";
            DirectionT.color = Color.green;
        }
        else
        {
            DirectionT.text = "   |   ";
            DirectionT.color = Color.white;
        }

        //Angle
        if (WorldManager.BAngle > 60)
        {
            AngleT.text = "High";
            AngleT.color = Color.red;
        }
        else if (WorldManager.BAngle > 30)
        {
            AngleT.text = "Medium";
            AngleT.color = Color.blue;
        }
        else if (WorldManager.BAngle > 1)
        {
            AngleT.text = "Low";
            AngleT.color = Color.green;
        }
        else
        {
            AngleT.text = "Grounded";
            AngleT.color = Color.white;
        }

        //Power
        if (WorldManager.BPower == 10)
        {
            PowerT.text = "Max";
            PowerT.color = Color.red;
        }
        else if (WorldManager.BPower > 8)
        {
            PowerT.text = "|||||";
            PowerT.color = Color.magenta;
        }
        else if (WorldManager.BPower > 6)
        {
            PowerT.text = "||||";
            PowerT.color = Color.yellow;
        }
        else if (WorldManager.BPower > 4)
        {
            PowerT.text = "|||";
            PowerT.color = Color.blue;
        }
        else if (WorldManager.BPower > 2)
        {
            PowerT.text = "||";
            PowerT.color = Color.cyan;
        }
        else if (WorldManager.BPower > 0.1)
        {
            PowerT.text = "|";
            PowerT.color = Color.white;
        }
        else
        {
            PowerT.text = "None";
            PowerT.color = Color.green;
        }

        //Win/Lose/Draw Message
        if (WorldManager.ShootsLeft==0)
        {
            if(WorldManager.PlayerScore> WorldManager.KeeperScore)
            {
                winLose.text = "YOU WIN!";
            }
            else if (WorldManager.PlayerScore < WorldManager.KeeperScore)
            {
                winLose.text = "YOU LOSE!";
            }
            else
            {
                winLose.text = "DRAW";
            }    
        }

        if (WorldManager.ShootsLeft != 0)
        {
            winLose.text = "";
        }

    }
}
