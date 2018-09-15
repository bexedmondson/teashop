using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomerLibrary))]
[RequireComponent(typeof(IngredientLibrary))]
public class Game : MonoBehaviour
{
    public static Game instance = null;

    private void Awake()
    {
        //singleton time!
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    public CustomerLibrary customerLibrary;

    public IngredientLibrary ingredientLibrary;

    private Customer currentCustomer;

    private Ingredient chosenIngredient = null;


    void Start()
    {
        customerLibrary = GetComponent<CustomerLibrary>();
        ingredientLibrary = GetComponent<IngredientLibrary>();

        if (customerLibrary.IsValid() && ingredientLibrary.IsValid())
            CustomerArrives();
        else
            QuitGame();
    }

    private void CustomerArrives()
    {
        currentCustomer = customerLibrary.GetRandomUnservedCustomer();

        if (currentCustomer == null)
        {
            ShowResults();
            return;
        }
    }

    public void SpeechNext()
    {
        if (chosenIngredient == null)
        {
            
        }
        else
        {
            chosenIngredient = null;
            CustomerArrives();
        }
    }

    public void ChooseTea(Ingredient ingredient)
    {
        chosenIngredient = ingredient;
    }

    public void TeaChosen()
    {
        SetSuccess();

        customerLibrary.MarkCustomerServed(currentCustomer);
    }

    private void SetSuccess()
    {
        if (currentCustomer.insomniaLevel <= chosenIngredient.insomniaRelief
            && currentCustomer.stressLevel <= chosenIngredient.stressRelief)
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
                resultString += customer.firstName;
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
