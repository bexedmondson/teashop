using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance = null;

	[SerializeField] private CurrentCustomerManager currentCustomerManager;

	[SerializeField] private CurrentCustomer currentCustomer;

    private void Awake()
    {
        //singleton time!
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        EventManager.StartListening(EventManager.NextCustomer, CustomerArrives);
    }

    void Start()
    {
		EventManager.TriggerEvent(EventManager.NextCustomer);
    }

    private void CustomerArrives()
    {
       currentCustomerManager.NextUnservedCustomer();

		if (currentCustomer.customer == null) //TODO CHANGE
        {
            //ShowResults();
            return;
        }

		UIManager.instance.ShowSpeechBubble(currentCustomer.customer.FirstEnquiry);
    }

    /*public void TeaChosen()
    {
        CalculateSuccess();

        customerManager.MarkCustomerServed(currentCustomer);
    }

	private void CalculateSuccess()
    {
		if (currentCustomer.GetStat(StatData.StatType.Insomnia) <= chosenIngredient.GetStat(StatData.StatType.Insomnia)
		    && currentCustomer.GetStat(StatData.StatType.Insomnia) <= chosenIngredient.GetStat(StatData.StatType.Stress))
        {
            currentCustomer.successfulTea = true;
        }
        else
        {
            currentCustomer.successfulTea = false;
        }
    }

    public void ShowResults()
    {
        string resultString = "";

        foreach (Customer customer in customerManager.customers)
        {
            if (customer.beenServed)
            {
                resultString += customer.FirstName;
                resultString += ": ";

                if (customer.successfulTea)
                    resultString += "your tea solved their problem!";
                else
                    resultString += "your tea didn't solve their problem this time.";
                
                resultString += "\n";
            }
        }
    }*/

    public void QuitGame()
    {
        // save any game data here

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
