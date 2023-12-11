using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Task3: MonoBehaviour
{
    public Volume postProcessingVolume;
    public ColorAdjustments colorAdjustments;

    void Start()
    {
        if (postProcessingVolume == null)
        {
            postProcessingVolume = gameObject.AddComponent<Volume>();
            postProcessingVolume.sharedProfile = new VolumeProfile();
        }

        colorAdjustments = postProcessingVolume.sharedProfile.Add<ColorAdjustments>();

        colorAdjustments.saturation.Override(1.5f);
    }
}
