using UnityEngine;
using UnityEngine.UIElements;

// Create vibration adjustment interface using UIToolkit
public class VibrationEditorUI : MonoBehaviour
{
    private void CreateEditorInterface()
    {
        // Contol left and right motor intensity
        var leftMotorSlider = new Slider();
        var rightMotorSlider = new Slider();
        
        // add callback functions
        leftMotorSlider.RegisterValueChangedCallback(OnLeftMotorChanged);
        rightMotorSlider.RegisterValueChangedCallback(OnRightMotorChanged);
    }
    
    // add missing callback method implementations
    private void OnLeftMotorChanged(ChangeEvent<float> evt)
    {
        // handle left motor slider value change
        float leftMotorValue = evt.newValue;
        // TODO: apply left motor vibration setting
    }
    
    private void OnRightMotorChanged(ChangeEvent<float> evt)
    {
        // handle right motor slider value change
        float rightMotorValue = evt.newValue;
        // TODO: apply right motor vibration setting
    }
}

