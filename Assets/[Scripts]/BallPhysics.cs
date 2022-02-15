using UnityEngine.Assertions;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    public float force;

    [SerializeField]
    // Note: In order for this example to work, you MUST at least set Y to > 0. Set in Start
    private Vector3 m_vTargetPos; 
   
    [SerializeField]
    private Vector3 m_vInitialVel;

    private Rigidbody m_rb = null;

    public bool m_bIsGrounded = true;
    
    [SerializeField]
    private float m_fDistanceToTarget = 0f;

    //
    [SerializeField]
    private bool m_bDebugKickBallReset = false;

    private Vector3 startPos;

    [SerializeField]
    [Range(0f, 90f)]
    public float angle = 0f;

    [SerializeField]
    public float m_rotationAngle = 0f;

    [SerializeField]
    private float m_rotationSpeed = 5f;

    [SerializeField]
    private Vector3 projectileTrayectory;
    [SerializeField]
    private float aRadians;
    [SerializeField]
    private float vX;
    [SerializeField]
    private float vY;
    [SerializeField]
    private float dt;

    //
    [SerializeField]
    public float PlayerGoals;

    private bool set = false;



    // Start is called before the first frame update
    void Start()
    {
        //For Reset
        startPos = transform.position;

        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem here! No Rigidbody attached");

        m_vTargetPos = new Vector3(0.0f, 0.55f, 0.0f);

        PlayerGoals = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Setting trajectory and setting limits
        //X angle
        float xf = Input.GetAxis("Horizontal");
        m_rotationAngle += xf/5;
        if (m_rotationAngle < -500.0f)
            m_rotationAngle = -500.0f;
        if (m_rotationAngle > 500.0f)
            m_rotationAngle = 500.0f;

        //Y angle
        float yf = Input.GetAxis("Vertical");
        angle += yf;
        if(angle>90)
        {
            angle = 90;
        }
        else if(angle<0)
        {
            angle = 0;
        }    

        //Initial velocity
        float zf = Input.GetAxis("Force")/2;
        force += zf;
        if (force < 0.0f)
            force = 0.0f;
        if (force > 10.0f)
            force = 10.0f;
    }

    //Function is called from World Manager
    public void OnKickBall(float f, float a)
    {

        // H = Vi^2 * sin^2(theta) / 2g
        // R = 2Vi^2 * cos(theta) * sin(theta) / g

        // Vi = sqrt(2gh) / sin(tan^-1(4h/r))
        // theta = tan^-1(4h/r)

        // Vy = V * sin(theta)
        // Vz = V * cos(theta)

        //dt = Time.deltaTime;

        //Degree to radians
        aRadians = a * Mathf.Deg2Rad;
        float xRadians = m_rotationAngle * Mathf.Deg2Rad;

        // vX and vY
        vX = f * Mathf.Cos(aRadians);
        vY = f * Mathf.Sin(aRadians);

        //Horizontal Angle
        float vZ = f * Mathf.Sin(xRadians);

        //Setting Trajectory
        projectileTrayectory = new Vector3(vZ, vY, vX);

        m_rb.velocity = projectileTrayectory;

    }

    //Called from WorldSettings. Reset Ball physics to before shooting
    public void Reset()
    {
        m_bIsGrounded = true;
        transform.position = startPos;
        m_rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        m_rb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        projectileTrayectory = new Vector3(0.0f, 0.0f, 0.0f);
        dt = 0f;
    }

    //Goal trigger
    void OnTriggerEnter(Collider other)
    {
        //If goal Add goal
        if (other.gameObject.tag == "Goal")
        {
            PlayerGoals += 1;
            set = true;
        }

        //If it touches the keeper sent it back
        if (other.gameObject.tag == "Keeper")
        {
            m_rb.velocity = new Vector3(m_rb.velocity.x,  m_rb.velocity.y,  m_rb.velocity.z * -1);
        }

    }
}
