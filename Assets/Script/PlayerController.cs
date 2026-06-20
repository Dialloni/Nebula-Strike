using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float tilt = 4f;
    public Boundary boundary = new Boundary { xMin = -6f, xMax = 6f, zMin = -4f, zMax = 8f };
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.25f;
    public int shotCount = 3;
    public float spreadAngle = 15f;  // degrees between each bullet

    private Rigidbody rb;
    private AudioSource audioSource;
    private float nextFire;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            Debug.LogWarning("No AudioSource found on Player!");
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (shot == null || shotSpawn == null)
            {
                Debug.LogError("shot or shotSpawn is not assigned!");
                return;
            }

            nextFire = Time.time + fireRate;

            float startAngle = -(shotCount - 1) * spreadAngle * 0.5f;
            for (int i = 0; i < shotCount; i++)
            {
                float angle = startAngle + i * spreadAngle;
                Quaternion rotation = shotSpawn.rotation * Quaternion.Euler(0f, angle, 0f);
                Instantiate(shot, shotSpawn.position, rotation);
            }

            if (audioSource != null)
                audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.linearVelocity = movement * speed;  // ✅ Fixed from linearVelocity

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.linearVelocity.x * -tilt); // ✅ Fixed here too
    }
}