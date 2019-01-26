using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Customers/Customer")]
public class Customer : ScriptableObject 
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

    public bool beenServed = false;

    public bool successfulTea = false;

	public int GetStatValue(StatData.StatType stat)
    {
        return statData.FirstOrDefault(statData => statData.statType == stat).statValue;
    }
}
