using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Animation")]
    public float rotationSpeed = 100f;
    public float floatHeight = 0.5f;
    public float floatSpeed = 2f;
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate coin
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        
        // Float up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
