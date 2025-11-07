using XboxHaptics.Tools;
using UnityEngine;

#if MM_UI
namespace XboxHaptics.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Shader Controller")]
	public class MMSpringShaderController : MMSpringFloatComponent<ShaderController>
	{
		public override float TargetFloat
		{
			get => Target.DrivenLevel;
			set => Target.DrivenLevel = value;
		}
	}
}
#endif