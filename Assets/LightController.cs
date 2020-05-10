using UnityEngine;
using Random = UnityEngine.Random;

public class LightController : MonoBehaviour
{
    private float _startTime = Time.time;
    public Light[] lights;

    void Update()
    {
        foreach (var lightComponent in lights)
        {
            if (lightComponent.enabled)
            {
                if (Random.value < ChanceForLightsToTurnOff())
                {
                    ToggleLight(lightComponent);
                }
            }
            else
            {
                if (Random.value < ChanceForLightsToTurnOn())
                {
                    ToggleLight(lightComponent);
                }
            }
        }
    }

    public void ToggleLight(Light lightComponent)
    {
        lightComponent.enabled = !lightComponent.enabled;
    }

    public float ChanceForLightsToTurnOff()
    {
        if (Duration() < 5)
        {
            return .004f;
        }
        else if (Duration() < 10)
        {
            return .002f;
        }
        else
        {
            return .0001f;
        }
    }
    public float ChanceForLightsToTurnOn()
    {
        if (Duration() < 5)
        {
            return .0002f;
        }
        else if (Duration() < 10)
        {
            return .0004f;
        }
        else
        {
            return .001f;
        }
    }

    public float Duration()
    {
        return Time.time - _startTime;
    }
}