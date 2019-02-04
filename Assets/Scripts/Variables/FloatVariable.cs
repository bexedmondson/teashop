using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Float Variable")]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif

	private float value;

	public void SetValue(float v)
	{
		value = v;
	}
    
    public float Value
	{
		get { return value; }
	}
}