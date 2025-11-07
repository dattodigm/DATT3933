using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XboxHaptics.Tools
{
	public class MMDropdownAttribute : PropertyAttribute
	{
		public readonly object[] DropdownValues;

		public MMDropdownAttribute(params object[] dropdownValues)
		{
			DropdownValues = dropdownValues;
		}
	}
}