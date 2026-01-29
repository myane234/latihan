using UnityEngine;

public static class shotutil
{
    public static void Shoot(
        GameObject projectilePrefab,
        Transform spawnPoint,
        float speed
    )
    {
        GameObject proj = Object.Instantiate(
            projectilePrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.forward * speed;
        }
    }
}
