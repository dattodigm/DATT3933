using UnityEngine;
using UnityEngine.InputSystem;

public class AudioVibrationController : MonoBehaviour
{
    // According to the audio type, map vibration parameters
    private void MapAudioToVibration(AudioClip clip, AudioVibrationType type)
    {
        switch(type)
        {
            case AudioVibrationType.Gentle:
                // Gentle vibration
                Gamepad.current.SetMotorSpeeds(0.1f, 0.05f);
                break;
            case AudioVibrationType.Moderate:
                // Moderate vibration
                Gamepad.current.SetMotorSpeeds(0.3f, 0.2f);
                break;
            case AudioVibrationType.Strong:
                // High intensity vibration
                Gamepad.current.SetMotorSpeeds(0.8f, 0.6f);
                break;
        }
    }
}
