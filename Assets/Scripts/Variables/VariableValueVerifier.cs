using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VariableValueVerifier<V, T> where V : Variable<T>
{
	[SerializeField]
	protected V variableToBeChecked;
    
	[SerializeField]
	protected T requiredValue;

	public abstract bool Verify();
}
