using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectilePrefabs; // Lista de proyectiles
    [SerializeField] private float shootRate = 0.5f;
    [SerializeField] private float projectileMoveSpeed = 5f;
    [SerializeField] private float trajectoryMaxHeight = 1f;
    [SerializeField] private AnimationCurve trajectoryAnimationCurve;

    public AudioSource launchAudioSource;

    private float shootTimer;
    private int selectedProjectileIndex = 0;

    void Update()
    {
        shootTimer -= Time.deltaTime;

        // Disparo con clic izquierdo
        if (Input.GetMouseButtonDown(0) && shootTimer <= 0f)
        {
            shootTimer = shootRate;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            GameObject selectedPrefab = projectilePrefabs[selectedProjectileIndex];
            GameObject projObj = Instantiate(selectedPrefab, transform.position, Quaternion.identity);

            Projectile projectile = projObj.GetComponent<Projectile>();
            projectile.InitializeProjectile(mouseWorldPos, projectileMoveSpeed, trajectoryMaxHeight);
            projectile.InitializeAnimationCurves(trajectoryAnimationCurve);

            if (launchAudioSource != null) // <-- Y aquí
            {
                launchAudioSource.Play();
            }
        }

        // Cambiar proyectil con teclas numÃ©ricas (1, 2, 3, ...)
        for (int i = 0; i < projectilePrefabs.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                selectedProjectileIndex = i;
                Debug.Log("Proyectil seleccionado: " + selectedProjectileIndex);
            }
        }
    }
}