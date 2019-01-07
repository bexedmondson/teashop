using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TeaShop/CustomerData")]
public class CustomerData : ScriptableObject 
{
	[SerializeField] private string firstName;
	public string FirstName { get { return firstName; } }

	[SerializeField] private Sprite sprite;
	public Sprite Sprite { get { return sprite; } }

	[SerializeField] private List<StatData> statData;
	public List<StatData> StatData { get { return statData; } }

	[SerializeField] private string firstEnquiry;
	public string FirstEnquiry { get { return firstEnquiry; } }

	[SerializeField] private string thankYou;
	public string ThankYou { get { return thankYou; } }
}
