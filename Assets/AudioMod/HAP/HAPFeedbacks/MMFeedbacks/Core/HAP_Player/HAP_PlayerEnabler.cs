using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	/// <summary>
	/// A helper class added automatically by MMF_Player if they're in AutoPlayOnEnable mode
	/// This lets them play again should their parent game object be disabled/enabled
	/// </summary>
	[AddComponentMenu("")]
	public class MMF_PlayerEnabler : MonoBehaviour
	{
		/// the MMF_Player to pilot
		public virtual HAP_Player TargetHapPlayer { get; set; }
        
		/// <summary>
		/// On enable, we re-enable (and thus play) our MMF_Player if needed
		/// </summary>
		protected virtual void OnEnable()
		{
			if ((TargetHapPlayer != null) && !TargetHapPlayer.enabled && TargetHapPlayer.AutoPlayOnEnable)
			{
				TargetHapPlayer.enabled = true;
			}
		}
	}    
}