using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider2D[] colliders = new Collider2D[3];
    [SerializeField] private int numFound;

    // Update is called once per frame
    void Update()
    {
        numFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionPointRadius, colliders);

        if (numFound > 0)
        {
            var interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null && Input.GetKeyDown(KeyCode.E))

            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Ensure it's drawn in the XY plane by locking the Z position
        Gizmos.DrawWireSphere(new Vector3(interactionPoint.position.x, interactionPoint.position.y, 0f), interactionPointRadius);
    }


}
