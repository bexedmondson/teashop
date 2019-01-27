using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Day Manager")]
public class DayManager : ScriptableObject 
{
	[SerializeField] private DayState initialState;

    [SerializeField]
    private CurrentCustomer currentCustomer;

    [SerializeField]
    private CustomerList todayCustomersList;

    [System.NonSerialized]
    private int customerIndex = 0;

	public void Init()
	{
		if (initialState != null)
    		initialState.Activate();
	}

	public void PopulateTodayCustomerList()
	{
		//TODO actually generate a list instead of just using the premade one
		NextUnservedCustomer();
	}

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
