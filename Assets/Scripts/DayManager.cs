using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Day Manager")]
public class DayManager : GameEventListenerSO
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
	}

    public void NextUnservedCustomer()
    {
        if (customerIndex >= todayCustomersList.customers.Count)
        {
			//do nothing so the game doesn't crash lol. just show the last person again
            //currentCustomer.customer = null;
        }
        else
        {
            currentCustomer.customer = todayCustomersList.customers[customerIndex];

#if UNITY_EDITOR
			GameMonitor.OnCustomerChanged(currentCustomer);         
#endif

			customerIndex++;
        }
    }
}
