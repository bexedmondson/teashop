using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Customer 
{   
	public CustomerData data;
    
	public bool beenServed = false;

	public bool successfulTea = false;
    
	public int GetStat(StatData.StatType stat)
	{
		return data.StatData.FirstOrDefault(statData => statData.statType == stat).statValue;
	}

	public Customer(CustomerData data)
	{
		this.data = data;
	}
}
