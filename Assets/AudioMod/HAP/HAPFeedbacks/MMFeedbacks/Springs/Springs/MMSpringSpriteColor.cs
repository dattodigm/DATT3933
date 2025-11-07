using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Sprite Color")]
	public class MMSpringSpriteColor : MMSpringColorComponent<SpriteRenderer>
	{
		public override Color TargetColor
		{
			get => Target.color;
			set => Target.color = value;
		}
	}
}
