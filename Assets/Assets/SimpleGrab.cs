using UnityEngine;

public class SimpleGrab : MonoBehaviour
{
    public float grabRange = 0.5f;
    private GameObject grabbedObject;

    void Update()
    {
        // Klik Kiri Mouse untuk ambil
        if (Input.GetMouseButtonDown(0)) 
        {
            TryGrab();
        }
        // Lepas Klik Kiri untuk taruh
        if (Input.GetMouseButtonUp(0) && grabbedObject != null)
        {
            Drop();
        }
    }

    void TryGrab()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, grabRange);
        foreach (var hit in hitColliders)
        {
            // Pastikan objek target punya nama "Book" atau "cat"
            if (hit.CompareTag("Interactable") || hit.gameObject.name.Contains("Book") || hit.gameObject.name.Contains("cat"))
            {
                grabbedObject = hit.gameObject;
                grabbedObject.transform.SetParent(this.transform); 
                
                if (grabbedObject.GetComponent<Rigidbody>()) 
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true; 
                
                break;
            }
        }
    }

    void Drop()
    {
        if (grabbedObject == null) return;

        grabbedObject.transform.SetParent(null); 
        if (grabbedObject.GetComponent<Rigidbody>()) 
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false; 
        
        grabbedObject = null;
    }
}