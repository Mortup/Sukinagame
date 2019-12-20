using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
       spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.localPosition.y * 100); 
    }
}
