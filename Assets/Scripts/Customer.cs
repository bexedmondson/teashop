using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Customer 
{

	private CustomerData customerData;
    
	public bool beenServed = false;

	public bool successfulTea = false;

	public string FirstName { get { return customerData.firstName; } }
    
	public string FirstEnquiry { get { return customerData.firstEnquiry; } }
    
	public int GetStat(StatData.StatType stat)
	{
		return customerData.statData.FirstOrDefault(statData => statData.statType == stat).statValue;
	}

	public Customer(CustomerData data)
	{
		customerData = data;
	}
}
