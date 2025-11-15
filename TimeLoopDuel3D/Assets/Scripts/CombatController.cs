using UnityEngine;

public class CombatController : MonoBehaviour
{
    public ObjectPool projectilePool;
    public Transform firePoint;
    public float fireRate = 0.5f;

    private GhostRecorder recorder;
    private float nextFireTime;
    private bool isPlayer;

    void Start()
    {
        recorder = GetComponent<GhostRecorder>();
        isPlayer = GetComponent<PlayerController3D>() != null;
    }

    void Update()
    {
        if (isPlayer && Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        if(isPlayer)
        {
            recorder.RecordAttack();
        }

        GameObject projectile = projectilePool.GetPooledObject();
        if (projectile != null)
        {
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            projectile.SetActive(true);
        }
    }
}
