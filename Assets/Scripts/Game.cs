using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomerLibrary))]
[RequireComponent(typeof(IngredientManager))]
public class Game : MonoBehaviour
{
    public static Game instance = null;

	public List<IngredientPile> ingredientSpawnPoints;
	public List<IngredientHolder> selectedIngredientHolders;

    private void Awake()
    {
        //singleton time!
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    private CustomerLibrary customerLibrary;

	private IngredientManager ingredientManager;
	public IngredientManager IngredientManager { get { return ingredientManager; } }

    private Customer currentCustomer;

    private IngredientData chosenIngredient = null;


    void Start()
    {
        customerLibrary = GetComponent<CustomerLibrary>();
        ingredientManager = GetComponent<IngredientManager>();

		SetupScene();

        CustomerArrives();
    }

	private void SetupScene()
	{
		for (int i = 0; i < ingredientSpawnPoints.Count; i++)
		{
			if (i < ingredientManager.ingredientMasterList.Count)
			{
				ingredientSpawnPoints[i].AssignDataToObject(ingredientManager.ingredientMasterList[i]);
			}
		}
	}

    private void CustomerArrives()
    {
        currentCustomer = customerLibrary.GetRandomUnservedCustomer();

        if (currentCustomer == null)
        {
            ShowResults();
            return;
        }

		UIManager.instance.ShowSpeechBubble(currentCustomer.FirstEnquiry);
    }

    public void SpeechNext()
    {
		UIManager.instance.HideSpeechBubble();
    }

	public void OnSelectedIngredientsUpdate()
	{
		for (int i = 0; i < IngredientManager.k_maxCurrentIngredients; i++)
		{
			if (ingredientManager.currentIngredients[i] != null)
			    selectedIngredientHolders[i].OnIngredientSelected(ingredientManager.currentIngredients[i]);
		}
	}

	public void ClearIngredients()
	{
		for (int i = 0; i < IngredientManager.k_maxCurrentIngredients; i++)
        {
			selectedIngredientHolders[i].ClearIngredient();
        }
	}

    public void TeaChosen()
    {
        CalculateSuccess();

        customerLibrary.MarkCustomerServed(currentCustomer);
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

        foreach (Customer customer in customerLibrary.customers)
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
    }

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
