// csharp
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using XboxHaptics.Feedbacks;

public class HAP_PlayerInput : MonoBehaviour
{
    [FormerlySerializedAs("hapPlayer")]
    [Tooltip("指向包含 HAP_Player 的组件（可留空，脚本会尝试自动查找）")]
    [SerializeField] private HAP_Player hapPlayer;

    private InputAction _playAction;

    private void Awake()
    {
        if (hapPlayer == null)
        {
            hapPlayer = GetComponent<HAP_Player>() ?? GetComponentInChildren<HAP_Player>();
        }

        // 建立一个 Button 类型的 InputAction，绑定 Xbox A（buttonSouth）和键盘 空格 作为备用
        _playAction = new InputAction("PlayHaptics", InputActionType.Button);
        _playAction.AddBinding("<Gamepad>/buttonSouth"); // Xbox A
        _playAction.AddBinding("<Keyboard>/space");      // 备用：空格键
        _playAction.performed += ctx => OnPlayPerformed();
    }

    private void OnEnable()
    {
        _playAction.Enable();
    }

    private void OnDisable()
    {
        _playAction.Disable();
    }

    private void OnDestroy()
    {
        _playAction.performed -= ctx => OnPlayPerformed();
        _playAction.Dispose();
    }

    private void OnPlayPerformed()
    {
        if (hapPlayer != null)
        {
            hapPlayer.PlayFeedbacks();
        }
        else
        {
            Debug.LogWarning("HAP_PlayerInput: HAP_Player 未设置或未找到。");
        }
    }
}