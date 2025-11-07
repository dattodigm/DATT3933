using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Light Intensity")]
	public class MMSpringLightIntensity : MMSpringFloatComponent<Light>
	{
		public override float TargetFloat
		{
			get => Target.intensity;
			set => Target.intensity = value; 
		}
	}
}
