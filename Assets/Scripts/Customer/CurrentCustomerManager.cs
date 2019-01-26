using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Customers/CurrentCustomerManager")] //TODO consider if it makes sense to mush this into Day?
public class CurrentCustomerManager : ScriptableObject 
{
	[SerializeField]
	public CurrentCustomer currentCustomer; //TODO MAKE PRIVATE

	[SerializeField]
	private CustomerList todayCustomersList;

	[System.NonSerialized]
	private int customerIndex = 0;

    public void NextUnservedCustomer()
    {
		if (customerIndex >= todayCustomersList.customers.Count)
		{
			currentCustomer.customer = null;
		}
		else
		{
			currentCustomer.customer = todayCustomersList.customers[customerIndex];
            customerIndex++;
		}
    }
}
