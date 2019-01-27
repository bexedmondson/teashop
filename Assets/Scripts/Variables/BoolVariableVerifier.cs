using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolVariableVerifier : VariableValueVerifier<BoolVariable, bool>
{
	public override bool Verify()
	{
		return variableToBeChecked.Value == requiredValue;
	}
}
