using UnityEngine;
using UnityEngine.InputSystem;

public class tourne : MonoBehaviour
{
    public Vector3 rotateVal = new Vector3(0, 1, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            transform.Rotate(rotateVal);
        }
    }
}
