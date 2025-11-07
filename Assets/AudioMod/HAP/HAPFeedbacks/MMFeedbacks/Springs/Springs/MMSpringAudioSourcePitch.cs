using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Audio Source Pitch")]
	public class MMSpringAudioSourcePitch : MMSpringFloatComponent<AudioSource>
	{
		public override float TargetFloat
		{
			get => Target.pitch;
			set => Target.pitch = value; 
		}
	}
}
