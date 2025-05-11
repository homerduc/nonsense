using UnityEngine;

public class orbeShaderController : MonoBehaviour
{
    private Renderer rend;
    private MaterialPropertyBlock mpb;

    void Start()
    {
        rend = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
    }

    void Update()
    {
        float angle = 10 + Time.time * 10f;
        rend.GetPropertyBlock(mpb);
        mpb.SetFloat("_monAngleOffsetVoronoi", angle);
        rend.SetPropertyBlock(mpb);
    }
}
