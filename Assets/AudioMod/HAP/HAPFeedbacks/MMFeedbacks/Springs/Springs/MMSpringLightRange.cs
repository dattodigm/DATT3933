using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Light Range")]
	public class MMSpringLightRange : MMSpringFloatComponent<Light>
	{
		public override float TargetFloat
		{
			get => Target.range;
			set => Target.range = value; 
		}
	}
}
