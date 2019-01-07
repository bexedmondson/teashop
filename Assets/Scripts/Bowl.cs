using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour, IPointerClickHandler, IDragHandler
{
	[SerializeField]
	private Rigidbody2D teaMix;

	private const float k_forceMultiplier = 0.01f;
	private const float k_teaSpinAmountTarget = 5000f;

	private float teaSpinAmount = 0f;

	public void OnDrag(PointerEventData eventData)
	{
		teaMix.AddForceAtPosition(eventData.delta * Time.deltaTime * k_forceMultiplier, eventData.position, ForceMode2D.Force);
        
		teaSpinAmount += eventData.delta.magnitude;

		if (teaSpinAmount > k_teaSpinAmountTarget)
		{
			TeaMixed();

			UIManager.instance.OnTeaMixed();
		}
	}

	public void OnPointerClick(PointerEventData pointerEventData)
    {      
		if (Game.instance.IngredientManager.NumberOfSelectedIngredients >= 1)
		{
            teaMix.gameObject.SetActive(true);
        }

        Game.instance.ClearIngredients();
		Game.instance.IngredientManager.ClearIngredients();
    }

	private void TeaMixed()
	{
		
		teaMix.gameObject.SetActive(false);
	}
}
