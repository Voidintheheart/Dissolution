using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float moveSpeed;
    private float trajectoryRelativeMaxHeight;
    private AnimationCurve trajectoryAnimationCurve;

    private float travelProgress = 0f;

    public AudioSource destroyAudioSource; // AudioSource para sonido destrucción
    private bool isDestroying = false;     // Para evitar reproducir varias veces

    public void InitializeProjectile(Vector3 targetPos, float moveSpeed, float trajectoryMaxHeight)
    {
        startPoint = transform.position;
        endPoint = targetPos;
        this.moveSpeed = moveSpeed;

        float distance = Vector3.Distance(startPoint, endPoint);
        this.trajectoryRelativeMaxHeight = distance * trajectoryMaxHeight;
    }

    public void InitializeAnimationCurves(AnimationCurve curve)
    {
        this.trajectoryAnimationCurve = curve;
    }

    private void Update()
    {
        if (isDestroying)
            return; // No hacer nada mientras suena el audio de destrucción

        // Update progress over time
        float distance = Vector3.Distance(startPoint, endPoint);
        travelProgress += (moveSpeed / distance) * Time.deltaTime;

        // Clamp progress to [0, 1]
        travelProgress = Mathf.Clamp01(travelProgress);

        // Calculate position along the flat (linear) line
        Vector3 flatPosition = Vector3.Lerp(startPoint, endPoint, travelProgress);

        // Add vertical arc using curve
        float heightOffset = trajectoryAnimationCurve.Evaluate(travelProgress) * trajectoryRelativeMaxHeight;
        Vector3 arcPosition = flatPosition + new Vector3(0f, heightOffset, 0f); // Only vertical offset

        transform.position = arcPosition;

        // Destroy at end, pero con sonido
        if (travelProgress >= 1f)
        {
            StartCoroutine(DestroyWithSound());
        }
    }

    private IEnumerator DestroyWithSound()
    {
        isDestroying = true;

        if (destroyAudioSource != null)
        {
            destroyAudioSource.Play();
            yield return new WaitForSeconds(destroyAudioSource.clip.length);
        }

        Destroy(gameObject);
    }
}