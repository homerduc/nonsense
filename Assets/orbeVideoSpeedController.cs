using UnityEngine;
using UnityEngine.Video;

public class orbeVideoSpeedController : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    float startYCoord;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startYCoord = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float volume = 0.1F * (transform.position.y - startYCoord);
        audioSource.volume = volume;
    }
}
