using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class orbeVideoSpeedController : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    float volume;

    float startYCoord;

    [SerializeField]
    float maxVolumePoint = 4f;

    float range;

    // Différence/écart entre le maxVolumePoint et l'orbe
    float diffAbsMaxVolPoint_Orbe;

    float maxVolNeg;

    [Range(0f, 1f)] public float textSoftness = 0.5f;
    [SerializeField]
    TMP_Text gettingItText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startYCoord = transform.position.y;
        range = maxVolumePoint - startYCoord;

        // Cloner le matériau pour ne pas modifier celui de toutes les instances
        gettingItText.fontMaterial = new Material(gettingItText.fontMaterial);
    }

    // Update is called once per frame
    void Update()
    {
        diffAbsMaxVolPoint_Orbe = Mathf.Abs(maxVolumePoint - transform.position.y);

        volume = 1 - (diffAbsMaxVolPoint_Orbe / range);
        audioSource.volume = Mathf.Max(0, volume);

        textSoftness = 1 - volume;
        gettingItText.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, textSoftness);
        gettingItText.fontMaterial.SetFloat(ShaderUtilities.ID_UnderlaySoftness, textSoftness);
    }
}
