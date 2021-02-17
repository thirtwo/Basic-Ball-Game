using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    Rigidbody rb;
    [Header("Properties")]
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isOnGround;
    [SerializeField] int playerHealth;
    float vertical;
    float horizontal;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        Move();
        CheckInput();
    }
    void Move()
    {
        rb.AddForce(Vector3.forward * movementSpeed * Time.fixedDeltaTime * vertical, ForceMode.VelocityChange);
        rb.AddForce(Vector3.right * movementSpeed * Time.fixedDeltaTime * horizontal, ForceMode.VelocityChange);
    }
    void Jump()
    {
        if (!isOnGround)
            return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }
    void OnGround()
    {
        isOnGround = true;
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
            OnGround();
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectible")
        {
            int x = other.GetComponent<Collectible>().collectibleType;
            if (x <= 1)
            {
                other.GetComponent<Collectible>().Collected();
                StartCoroutine(Boost(x));
            }
            else
            {
                FindObjectOfType<GameManager>().AddMoney();
                other.GetComponent<Collectible>().Collected();
            }
        }
    }

    private IEnumerator Boost(int boostType)
    {
        if(boostType == 0)
        {
            movementSpeed += 5;
            yield return new WaitForSeconds(2);
            movementSpeed -= 5;
        }
        else if (boostType == 1)
        {
            jumpForce += 5;
            yield return new WaitForSeconds(2);
            jumpForce -= 5;
        }
    }
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
