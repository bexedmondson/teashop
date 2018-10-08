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


    private CustomerLibrary customerLibrary;

    private IngredientLibrary ingredientLibrary;

    private Customer currentCustomer;

    private Ingredient chosenIngredient = null;


    void Start()
    {
        customerLibrary = GetComponent<CustomerLibrary>();
        ingredientLibrary = GetComponent<IngredientLibrary>();

        CustomerArrives();
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

		CameraManager.instance.StartMoveDown();

        /*if (chosenIngredient == null)
        {
            
        }
        else
        {
            chosenIngredient = null;
            CustomerArrives();
        }*/
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
        if (currentCustomer.InsomniaLevel <= chosenIngredient.insomniaRelief
            && currentCustomer.StressLevel <= chosenIngredient.stressRelief)
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
