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

    [SerializeField]
    TMP_Text percentageText;
    float percentage = 0f;
    bool isOrbInZone = false;
    [SerializeField]
    float percentIncrSpeed = 5f;
    float percentDecrSpeed = 5f;

    [SerializeField]
    Animator animatorCam;
    bool animWasPlayed = false;

    Vector3 positionFinale;

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
        // music volume
        if (animWasPlayed == false)
        {
            diffAbsMaxVolPoint_Orbe = Mathf.Abs(maxVolumePoint - transform.position.y);
            volume = 1 - (diffAbsMaxVolPoint_Orbe / range);
            audioSource.volume = Mathf.Max(0, volume);
        }

        // "getting it" text softness
        textSoftness = 1 - volume;
        gettingItText.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, textSoftness);
        gettingItText.fontMaterial.SetFloat(ShaderUtilities.ID_UnderlaySoftness, textSoftness);
        percentageText.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, textSoftness);
        percentageText.fontMaterial.SetFloat(ShaderUtilities.ID_UnderlaySoftness, textSoftness);

        // percentage
        if (isOrbInZone)
        {
            IncreasePercentage();
        }
        else
        {
            DecreasePercentage();
        }
        SetPercentage();

        if (Mathf.Round(percentage) == 100)
        {
            HundredReached();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "zone activation")
        {
            isOrbInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "zone activation")
        {
            isOrbInZone = false;
        }
    }

    // Baisse en permanence
    void DecreasePercentage()
    {
        // si % > 0
        if (percentage > percentDecrSpeed * Time.deltaTime)
        {
            percentage -= percentDecrSpeed * Time.deltaTime;
        }
    }

    // Augmente quand dans la zone
    void IncreasePercentage()
    {
        if (percentage < 100 + percentIncrSpeed * Time.deltaTime)
        {
            percentage += percentIncrSpeed * Time.deltaTime;
        }
    }

    void SetPercentage()
    {
        percentageText.text = Mathf.Round(percentage).ToString() + " %";
    }

    void HundredReached()
    {
        if (animWasPlayed == false)
        {
            animWasPlayed = true;
            animatorCam.SetTrigger("playCamAnim");
            positionFinale = transform.position;
        }
        transform.position = positionFinale;
    }
}
