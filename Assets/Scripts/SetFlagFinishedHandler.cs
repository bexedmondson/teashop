using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFlagFinishedHandler : MonoBehaviour 
{   
    [SerializeField] private StateProcessFlag flagToBeSet;


	public void SetFlagFinished()
    {
		flagToBeSet.SetFinished();
    }
}
