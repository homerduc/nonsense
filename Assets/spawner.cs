using UnityEngine;
using UnityEngine.InputSystem;

public class spawner : MonoBehaviour
{
    [SerializeField]
    float xCoordLim;

    [SerializeField]
    float zCoordLim;

    [SerializeField]
    GameObject thing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.isPressed)
        {
            SpawnBoule();
        }
    }

    void SpawnBoule()
    {
        float x = GenererCoord(xCoordLim);
        float z = GenererCoord(zCoordLim);
        Vector3 spawnPos = new Vector3(x, 0, z) + transform.position;

        GameObject spawnedThing = Instantiate(thing, spawnPos, Quaternion.identity);

        Light spotLight = spawnedThing.GetComponentInChildren<Light>();
        AudioSource audioSource = spawnedThing.GetComponentInChildren<AudioSource>();
        if (spotLight != null)
        {
            spotLight.color = GenererCouleur();
        }
        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(0.2f, 1.8f);
            audioSource.Play();
        }

        // Je leur donne un coup pour les faire rouler
        Rigidbody rigidbody = spawnedThing.GetComponent<Rigidbody>();
        rigidbody.AddForce(spawnPos*10);
    }

    float GenererCoord(float lim)
    {
        return Random.Range(-lim, lim);
    }

    Color GenererCouleur()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
