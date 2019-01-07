using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour 
{
	public static CustomerManager instance = null;

    private void Awake()
    {
        //singleton time!
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

		EventManager.StartListening(EventManager.CustomerServed, MarkCurrentCustomerServed);
        
        InitialiseCustomers();
    }


	public List<CustomerData> customerDataList;

	[HideInInspector]
	public List<Customer> customers = new List<Customer>(); //TODO make private

	private List<Customer> unservedCustomers = new List<Customer>();

    private Customer currentCustomer;


	private void InitialiseCustomers()
	{
		foreach (CustomerData customerData in customerDataList)
		{
			Customer c = new Customer(customerData);
            
			customers.Add(c);
			unservedCustomers.Add(c);
		}
	}

	public Customer GetNextUnservedCustomer()
	{      
		Customer customer = null;

		if (unservedCustomers.Count == 0)
			return customer;

		currentCustomer = unservedCustomers[Random.Range(0, unservedCustomers.Count)];

		return currentCustomer;
    }

	public string GetCurrentCustomerThankYou()
	{
		return currentCustomer.data.ThankYou;
	}
    
	public void MarkCurrentCustomerServed()
	{
        currentCustomer.beenServed = true;
		unservedCustomers.Remove(currentCustomer);

		EventManager.TriggerEvent(EventManager.NextCustomer);
	}
}
