using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private GameObject projectilePrefab; 
    [SerializeField] private float shootRate = 0.5f;
    [SerializeField] private float projectileMoveSpeed = 5f;
    [SerializeField] private float trajectoryMaxHeight = 1f;
    [SerializeField] private AnimationCurve trajectoryAnimationCurve;

    private float shootTimer;
    private Sprite currentProjectileSprite;

    public void SetProjectile(GameObject newPrefab, Sprite newSprite)
    {
        projectilePrefab = newPrefab;
        currentProjectileSprite = newSprite;
        Debug.Log("Nuevo proyectil asignado: " + newPrefab.name);
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && shootTimer <= 0f)
        {
            shootTimer = shootRate;

            if (projectilePrefab == null)
            {
                Debug.LogWarning("¡No hay proyectil asignado!");
                return;
            }

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            GameObject projObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            SpriteRenderer sr = projObj.GetComponent<SpriteRenderer>();
            if (sr != null && currentProjectileSprite != null)
            {
                sr.sprite = currentProjectileSprite;
            }

            Projectile projectile = projObj.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.InitializeProjectile(mouseWorldPos, projectileMoveSpeed, trajectoryMaxHeight);
                projectile.InitializeAnimationCurves(trajectoryAnimationCurve);
            }
            else
            {
                Debug.LogWarning("El prefab no tiene el script 'Projectile'");
            }
        }
    }
}
