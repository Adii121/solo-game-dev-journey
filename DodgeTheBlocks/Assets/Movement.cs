using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float laneDistance = 2f;

    private int currentLane = 1; // 0 = Left, 1 = Center, 2 = Right
    private Vector3[] lanes;

    void Start()
    {
        // Set up lanes based on position
        lanes = new Vector3[]
        {
            new Vector3(-laneDistance, transform.position.y, 0),
            new Vector3(0, transform.position.y, 0),
            new Vector3(laneDistance, transform.position.y, 0)
        };
        transform.position = lanes[currentLane];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            transform.position = lanes[currentLane];
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
            transform.position = lanes[currentLane];
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
        }
    }
}
