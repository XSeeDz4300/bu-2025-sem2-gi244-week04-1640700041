using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    // Exam 05
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 4f;
    //
    private int currentBulletCount;
    private float regenerateTimer;
    private bool isRegenerating = false;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

        currentBulletCount = maxBulletCount;
    }

    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (shootAction.triggered && currentBulletCount > 0)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            currentBulletCount--;

            if (currentBulletCount <= 0)
            {
                isRegenerating = true;
                regenerateTimer = bulletRegenerateCooldown;
            }
        }


        if (isRegenerating)
        {
            regenerateTimer -= Time.deltaTime;

            if (regenerateTimer <= 0f)
            {
                currentBulletCount = maxBulletCount;
                isRegenerating = false;
            }
        }
    }
}