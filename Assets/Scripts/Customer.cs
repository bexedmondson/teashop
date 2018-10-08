using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer 
{

	private CustomerData customerData;
    
	public bool beenServed = false;

	public bool successfulTea = false;

	public string FirstName { get { return customerData.firstName; } }

	public string FirstEnquiry { get { return customerData.firstEnquiry; } }

	public int InsomniaLevel { get { return customerData.insomniaLevel; } }

	public int StressLevel { get { return customerData.stressLevel; } }

	public Customer(CustomerData data)
	{
		customerData = data;
	}
}
