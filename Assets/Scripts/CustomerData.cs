using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TeaShop/CustomerData")]
public class CustomerData : ScriptableObject 
{   
	public string firstName;

	public Sprite sprite;

	public List<StatData> statData;

    public string firstEnquiry;

	public string thankYou;
}
