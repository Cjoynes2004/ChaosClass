using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    public int numStudents;
    private List<GameObject> studentList;
    public bool cooldown = false;
    
    //Creates a list of student objects, each a copy of the manager (hidden off the game world)
    void Start()
    {
        studentList = new List<GameObject>();
        MeshFilter parentMeshFilter = GetComponent<MeshFilter>();
        MeshRenderer parentMeshRenderer = GetComponent<MeshRenderer>();
        MeshCollider parentCollider = GetComponent<MeshCollider>();
        Rigidbody parentRigidbody = GetComponent<Rigidbody>();

        for (int i = 0; i < numStudents; i++)
        {
            GameObject student = new GameObject("Student" + i.ToString());
            student.transform.parent = transform;
            student.AddComponent<StudentQuestion>();

            MeshFilter childMeshFilter = student.AddComponent<MeshFilter>();
            MeshRenderer childMeshRenderer = student.AddComponent<MeshRenderer>();
            MeshCollider childMeshCollider = student.AddComponent<MeshCollider>();
            Rigidbody childRigidbody = student.AddComponent<Rigidbody>();

            childMeshFilter.sharedMesh = parentMeshFilter.sharedMesh;
            childMeshRenderer.sharedMaterial = parentMeshRenderer.sharedMaterial;
            childMeshCollider.sharedMaterial = parentCollider.sharedMaterial;
            childMeshCollider.convex = parentCollider.convex;
            childMeshCollider.isTrigger = parentCollider.isTrigger;
            childMeshCollider.providesContacts = parentCollider.providesContacts;
            childMeshCollider.sharedMesh = parentCollider.sharedMesh;

            childRigidbody.mass = parentRigidbody.mass;
            childRigidbody.drag = parentRigidbody.drag;
            childRigidbody.angularDrag = parentRigidbody.angularDrag;
            childRigidbody.useGravity = parentRigidbody.useGravity;
            childRigidbody.isKinematic = parentRigidbody.isKinematic;
            childRigidbody.interpolation = parentRigidbody.interpolation;
            childRigidbody.collisionDetectionMode = parentRigidbody.collisionDetectionMode;
            childRigidbody.constraints = parentRigidbody.constraints;


            Vector3 position = new Vector3(i, 0, 0);
            student.transform.position = position * 5;


            studentList.Add(student);
        }
        
    }
    public IEnumerator Cooldown(float time)
    {
        cooldown = true; // Set cooldown to true
        yield return new WaitForSeconds(time); // Wait for 'time' seconds
        cooldown = false; // Reset cooldown
        Debug.Log("Cooldown ended. You can interact again.");
    }
}
