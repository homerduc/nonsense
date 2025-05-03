using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    int currentSceneId;
    int tirage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSceneId = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            // Tire une scène au pif, empêche de tomber sur l'actuelle
            do
            {
                tirage = Random.Range(0, SceneManager.sceneCountInBuildSettings);
            }
            while (tirage == currentSceneId);
            SceneManager.LoadScene(tirage);
        }
    }
}
