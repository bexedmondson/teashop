using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Customers/CustomerList")]
public class CustomerList : ScriptableObject 
{
	[SerializeField]
	public List<Customer> customers;
}
