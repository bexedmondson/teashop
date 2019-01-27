using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectVariableNotNullVerifier : VariableValueVerifier<ObjectVariable, object>
{
	public override bool Verify()
	{
		return variableToBeChecked != null;
	}
}
