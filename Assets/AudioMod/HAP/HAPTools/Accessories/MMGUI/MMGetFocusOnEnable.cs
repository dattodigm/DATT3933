#if MM_UI
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XboxHaptics.Tools;
using UnityEngine.EventSystems;

namespace XboxHaptics.Tools
{
	/// <summary>
	/// Add this helper to an object and focus will be set to it on Enable
	/// </summary>
	[AddComponentMenu("More Mountains/Tools/GUI/MM Get Focus On Enable")]
	public class MMGetFocusOnEnable : MonoBehaviour
	{
		protected virtual void OnEnable()
		{
			EventSystem.current.SetSelectedGameObject(this.gameObject, null);
		}
	}
}
#endif