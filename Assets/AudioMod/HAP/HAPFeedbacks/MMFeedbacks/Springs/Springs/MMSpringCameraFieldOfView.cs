using XboxHaptics.Tools;
using UnityEngine;

namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Camera Field Of View")]
	public class MMSpringCameraFieldOfView : MMSpringFloatComponent<Camera>
	{
		public override float TargetFloat
		{
			get => Target.fieldOfView;
			set => Target.fieldOfView = value;
		}
	}
}
