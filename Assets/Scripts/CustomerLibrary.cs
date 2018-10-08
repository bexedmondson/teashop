using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLibrary : MonoBehaviour {

	public List<CustomerData> customerDataList;

	[HideInInspector]
	public List<Customer> customers = new List<Customer>(); //TODO make private

	private List<Customer> unservedCustomers = new List<Customer>();

	private void Awake()
	{
		foreach (CustomerData customerData in customerDataList)
		{
			Customer c = new Customer(customerData);

			customers.Add(c);
			unservedCustomers.Add(c); //TODO change this
		}
	}   

	public Customer GetRandomUnservedCustomer()
	{      
		Customer customer = null;

		if (unservedCustomers.Count == 0)
			return customer;

		customer = unservedCustomers[Random.Range(0, unservedCustomers.Count)];

		return customer;
    }
    
	public void MarkCustomerServed(Customer customer)
	{
        customer.beenServed = true;
		unservedCustomers.Remove(customer);
	}
}
