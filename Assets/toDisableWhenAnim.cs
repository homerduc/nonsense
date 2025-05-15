using TMPro;
using UnityEngine;

public class toDisableWhenAnim : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateAll()
    {
        canvas.SetActive(false);
    }
}
