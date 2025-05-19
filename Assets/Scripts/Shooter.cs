using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private float shootRate = 0.5f;
    [SerializeField] private float projectileMoveSpeed = 5f;
    [SerializeField] private float trajectoryMaxHeight = 1f;
    [SerializeField] private AnimationCurve trajectoryAnimationCurve;

    public AudioSource launchAudioSource;

    private float shootTimer;

    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && shootTimer <= 0f)
        {
            shootTimer = shootRate;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            GameObject projObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectile = projObj.GetComponent<Projectile>();
            projectile.InitializeProjectile(mouseWorldPos, projectileMoveSpeed, trajectoryMaxHeight);
            projectile.InitializeAnimationCurves(trajectoryAnimationCurve);

            if (launchAudioSource != null) // <-- Y aquí
            {
                launchAudioSource.Play();
            }
        }
    }
}