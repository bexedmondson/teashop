using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	private SpriteRenderer teaMix;

	public void OnPointerClick(PointerEventData pointerEventData)
    {      
		if (Game.instance.IngredientManager.NumberOfSelectedIngredients >= 1)
		{
            teaMix.gameObject.SetActive(true);

			StartCoroutine(SpinTea());
        }

        Game.instance.ClearIngredients();
		Game.instance.IngredientManager.ClearIngredients();
    }   

	private IEnumerator SpinTea()
	{
		int i = 0;

		while (i < 365)
		{
			i += 5;
			teaMix.transform.Rotate(new Vector3(0, 0, 10f));
			yield return null;
		}

		teaMix.gameObject.SetActive(false);

		UIManager.instance.OnTeaMixed();
	}
}
