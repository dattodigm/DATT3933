using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Light Color")]
	public class MMSpringLightColor : MMSpringColorComponent<Light>
	{
		public override Color TargetColor
		{
			get => Target.color;
			set => Target.color = value;
		}
	}
}
