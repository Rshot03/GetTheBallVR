using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    private Vector3 direction;
    private float speed;

    void Start()
    {
        direction = Random.onUnitSphere;
        direction.y = 0; // keep it on the XZ plane
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    public void IncreaseSpeed(float multiplier) //  add this
    {
        minSpeed *= multiplier;
        maxSpeed *= multiplier;
        speed = Random.Range(minSpeed, maxSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Reflect direction on collision
        direction = Vector3.Reflect(direction, collision.contacts[0].normal);
        direction.y = 0; // again, keep it flat
        speed = Random.Range(minSpeed, maxSpeed); // optional: change speed on bounce

    }
}