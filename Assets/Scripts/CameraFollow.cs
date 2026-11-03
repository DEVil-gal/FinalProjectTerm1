using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float Speed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Vector3.Lerp(transform.position, target.transform.position + offset, Speed * Time.deltaTime);
        transform.position = targetPos;
        transform.LookAt(target.transform.position);
    }
}
