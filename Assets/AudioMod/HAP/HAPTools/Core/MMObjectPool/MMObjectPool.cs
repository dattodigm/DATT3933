using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XboxHaptics.Tools
{
	public class MMObjectPool : MonoBehaviour
	{
		[MMReadOnly]
		public List<GameObject> PooledGameObjects;
	}
}