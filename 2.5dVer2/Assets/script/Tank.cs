using UnityEngine;

public class Tank : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.AddOxygen();
            Debug.Log("you add Your Oxygen");
            Destroy(gameObject);
        }
    }
}
