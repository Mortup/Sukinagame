using UnityEngine;
using TMPro;

public class Clonadora : MonoBehaviour
{
    [SerializeField] private TMP_Text screen;
    [SerializeField] private Transform cloneDestination;

    IClonable lastClonable;

    private void Awake() {
        lastClonable = null;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        IClonable clonable = collision.gameObject.GetComponent<IClonable>();
        if (clonable == null)
            return;

        screen.text = clonable.getName();
        lastClonable = clonable;
    }

    public void Clone() {
        GameObject clone = Instantiate(lastClonable.getGameObject(), cloneDestination.position, cloneDestination.rotation);
        clone.transform.SetParent(GameObject.FindGameObjectWithTag("Level").transform);
    }
}
