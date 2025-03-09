using UnityEngine;

public class RotateGear : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private int stopperCount = 0; // Track number of stoppers in contact

    void Update()
    {
        if (stopperCount == 0)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stopper"))
        {
            stopperCount++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stopper"))
        {
            stopperCount = Mathf.Max(0, stopperCount - 1);
        }
    }
}
