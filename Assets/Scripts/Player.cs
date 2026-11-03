using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 inputMovement;
    public float BaseSpeed = 1;
    public float CurrentSpeed = 1;
    private Rigidbody rb;
    public double BoostTime = 1;
    public double CurrentTime = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
        
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSpeed != BaseSpeed)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
            }
            else
            {
                CurrentSpeed = CurrentSpeed - 1;
                CurrentTime = BoostTime;
            }
        }
    }

    private void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        inputMovement = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        Vector3 direction = new Vector3(0, 1, 0);
        rb.AddForce(direction * CurrentSpeed);
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(inputMovement.x, 0, inputMovement.y);
        rb.AddForce(direction * CurrentSpeed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            if (CurrentSpeed < 20)
            {
                CurrentSpeed = CurrentSpeed + 1;
            }
        }
        else if (other.gameObject.tag == "Respawn")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        else if (other.gameObject.tag == "Victory")
        {
            SceneManager.LoadScene("VictoryScreen");
        }
    }
}
