using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomerManager))]
public class Game : MonoBehaviour
{
    public static Game instance = null;

	public List<IngredientPile> ingredientSpawnPoints;
	public List<IngredientHolder> selectedIngredientHolders;

	[SerializeField] private IngredientEditableList currentIngredientList;

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

    private IngredientData chosenIngredient = null;   

    void Start()
    {
        SetupScene();
    }

	private void SetupScene()
	{      
		EventManager.TriggerEvent(EventManager.NextCustomer);
	}

    private void CustomerArrives()
    {
        Customer currentCustomer = CustomerManager.instance.GetNextUnservedCustomer();

        if (currentCustomer == null)
        {
            //ShowResults();
            return;
        }

		UIManager.instance.ShowSpeechBubble(currentCustomer.data.FirstEnquiry);
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
