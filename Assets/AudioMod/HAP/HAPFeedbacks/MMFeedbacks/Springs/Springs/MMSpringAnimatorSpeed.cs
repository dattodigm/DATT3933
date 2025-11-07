using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Animator Speed")]
	public class MMSpringAnimatorSpeed : MMSpringFloatComponent<Animator>
	{
		public override float TargetFloat
		{
			get => Target.speed;
			set => Target.speed = Mathf.Abs(value); 
		}
	}
}
