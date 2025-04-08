using UnityEngine;
using UnityEngine.Events;
public class IdMatchBehaviour : MonoBehaviour
{
    public Id id;
    public UnityEvent matchEvent, noMatchEvent;

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIDBehaviour>();

        if (otherID.id == null)
        {
            Debug.Log("ID is null");
            return;
        }
        if (otherID.id == id)
        {
            Debug.Log("Matched ID: " + id);
            matchEvent.Invoke();
        }
        else
        {
            Debug.Log("No Match:" + id);
            noMatchEvent.Invoke();
        }
    }
}
