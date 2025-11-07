#if MM_UI
using XboxHaptics.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Image Alpha")]
	public class MMSpringImageAlpha : MMSpringFloatComponent<Image>
	{
		protected Color _color;
		
		public override float TargetFloat
		{
			get => Target.color.a;
			set
			{
				_color = Target.color;
				_color.a = value;
				Target.color = _color;
			}
		}
	}
}
#endif