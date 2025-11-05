using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiAudioHandler : MonoBehaviour
{
    private List<AudioSource> activeAudioSources = new List<AudioSource>();
    private bool isVibrating = false;
    private float vibrationTimer = 0f;
    private const float MAX_VIBRATION_DURATION = 2.0f; // 最大震动持续时间
    
    private void Update()
    {
        // 检查是否有活跃音频源
        if (activeAudioSources.Count > 0)
        {
            ApplyMixedVibration();
            isVibrating = true;
            vibrationTimer = 0f;
        }
        else if (isVibrating)
        {
            // 逐渐停止震动
            vibrationTimer += Time.deltaTime;
            if (vibrationTimer >= MAX_VIBRATION_DURATION)
            {
                StopVibration();
                isVibrating = false;
            }
        }
    }
    
    private void StopVibration()
    {
        // 平滑停止震动
        Gamepad.current.SetMotorSpeeds(0f, 0f);
    }

    
    private AudioVibrationType GetDominantVibrationType()
    {
        // According to distance and audio type priority to determine the dominant vibration type
        AudioSource dominantSource = null;
        float highestPriority = -1;
        
        foreach (var source in activeAudioSources)
        {
            float priority = CalculateAudioPriority(source);
            if (priority > highestPriority)
            {
                highestPriority = priority;
                dominantSource = source;
            }
        }
        
        return DetermineVibrationType(dominantSource.clip);
    }
    
    private float CalculateAudioPriority(AudioSource source)
    {
        // Consider distance, volume, and audio type
        float distanceFactor = 1.0f - (Vector3.Distance(transform.position, source.transform.position) / source.maxDistance);
        float volumeFactor = source.volume;
        
        return distanceFactor * volumeFactor;
    }
    
    private AudioVibrationType DetermineVibrationType(AudioClip clip)
    {
        // According to AudioClip characteristics to determine vibration type
        string clipName = clip.name.ToLower();
        
        if (clipName.Contains("water") || clipName.Contains("river") || clipName.Contains("stream"))
            return AudioVibrationType.Gentle;
        else if (clipName.Contains("wind") || clipName.Contains("car") || clipName.Contains("traffic"))
            return AudioVibrationType.Moderate;
        else if (clipName.Contains("explosion") || clipName.Contains("storm") || clipName.Contains("thunder"))
            return AudioVibrationType.Strong;
            
        return AudioVibrationType.Moderate; // Modern default
    }
    
    private float CalculateSourceWeight(AudioSource source)
    {
        // Calculate the weight of the audio source based on distance and volume
        float distance = Vector3.Distance(transform.position, source.transform.position);
        float distanceWeight = Mathf.Clamp01(1.0f - (distance / source.maxDistance));
        float volumeWeight = source.volume;
        
        return distanceWeight * volumeWeight;
    }
    
    private Vector2 GetMotorSpeedsForType(AudioVibrationType type)
    {
        // Return the motor speeds for the given vibration type
        switch(type)
        {
            case AudioVibrationType.Gentle:
                return new Vector2(0.1f, 0.05f);
            case AudioVibrationType.Moderate:
                return new Vector2(0.3f, 0.2f);
            case AudioVibrationType.Strong:
                return new Vector2(0.8f, 0.6f);
            default:
                return new Vector2(0.0f, 0.0f);
        }
    }
    
    private void ApplyMixedVibration()
    {
        float leftMotor = 0f;
        float rightMotor = 0f;
        float totalWeight = 0f;
    
        foreach (var source in activeAudioSources)
        {
            float weight = CalculateSourceWeight(source);
            AudioVibrationType type = DetermineVibrationType(source.clip);
            Vector2 motorSpeeds = GetMotorSpeedsForType(type);
        
            leftMotor += motorSpeeds.x * weight;
            rightMotor += motorSpeeds.y * weight;
            totalWeight += weight;
        }
    
        // apply and normalize
        if (totalWeight > 0)
        {
            Gamepad.current.SetMotorSpeeds(leftMotor / totalWeight, rightMotor / totalWeight);
        }
    }
    
    

}

