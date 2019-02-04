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

	[SerializeField] private string firstEnquiryResponse1;
	public string FirstEnquiryResponse1 { get { return firstEnquiryResponse1; } }

	[SerializeField] private string firstEnquiryResponse2;
	public string FirstEnquiryResponse2 { get { return firstEnquiryResponse2; } }

	[SerializeField] private string secondEnquiry;
	public string SecondEnquiry { get { return secondEnquiry; } }

	[SerializeField] private string secondEnquiryResponse1;
	public string SecondEnquiryResponse1 { get { return secondEnquiryResponse1; } }

	[SerializeField] private string secondEnquiryResponse2;
	public string SecondEnquiryResponse2 { get { return secondEnquiryResponse2; } }

	[SerializeField] private string thankYou;
	public string ThankYou { get { return thankYou; } }

    public bool beenServed = false;

    public bool successfulTea = false;

	public int GetStatValue(StatData.StatType stat)
    {
        return statData.FirstOrDefault(statData => statData.statType == stat).statValue;
    }
}
