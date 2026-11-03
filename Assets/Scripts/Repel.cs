using UnityEngine;

public class Repel : MonoBehaviour
{

    public float radius = 5.0f;
    public float power = 10.0f;
    public float upwardsModifier = 3.0f;
    public ForceMode forceMode = ForceMode.Force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public LayerMask affectedLayers = ~0; // All layers by default

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("touched");
            ApplyExplosionForce();
        }
    }

    public void ApplyExplosionForce()
    {
        Debug.Log("exploding");
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius, affectedLayers);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upwardsModifier, forceMode);
            }
        }
    }
}
