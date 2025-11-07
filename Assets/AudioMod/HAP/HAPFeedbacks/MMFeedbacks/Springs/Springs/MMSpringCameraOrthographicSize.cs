using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Camera Orthographic Size")]
	public class MMSpringCameraOrthographicSize : MMSpringFloatComponent<Camera>
	{
		public override float TargetFloat
		{
			get => Target.orthographicSize;
			set => Target.orthographicSize = value; 
		}
	}
}
