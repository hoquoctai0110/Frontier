using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteraction interactor)
    {
        Debug.Log("Interact successfull");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
