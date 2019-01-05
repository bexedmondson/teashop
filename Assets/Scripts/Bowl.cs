using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour, IPointerClickHandler, IDragHandler
{
	[SerializeField]
	private Rigidbody2D teaMix;

	private const float k_forceMultiplier = 0.01f;

	public void OnDrag(PointerEventData eventData)
	{
		teaMix.AddForceAtPosition(eventData.delta * Time.deltaTime * k_forceMultiplier, eventData.position, ForceMode2D.Force);
	}

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
		//int i = 0;

		//while (i < 365)
		//{
			//i += 5;
		//teaMix.AddForceAtPosition(new Vector2(10, 10), new Vector2(5, 5), ForceMode2D.Force);    //.Rotate(new Vector3(0, 0, 10f));
		yield return null;
		//}

		//teaMix.gameObject.SetActive(false);

		//UIManager.instance.OnTeaMixed();
	}
}
