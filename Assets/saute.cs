using UnityEngine;
using UnityEngine.InputSystem;

public class saute : MonoBehaviour
{
    Rigidbody rigidBody;

    [SerializeField]
    Vector3 forceAdded = new Vector3(0, 1, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rigidBody.AddForce(forceAdded);
        }
    }
}
