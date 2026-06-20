using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    private void Fire()
    {
        if (shot == null || shotSpawn == null)
        {
            Debug.LogError("shot or shotSpawn is not assigned on " + name);
            return;
        }

        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
            audioSource.Play();
    }
}
