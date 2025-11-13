using UnityEngine;
using UnityEngine.UI;

public class ExpSystem : MonoBehaviour
{
    [SerializeField] private int _value = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerExp = other.GetComponentInParent<PlayerExperience>();
        if (playerExp == null)
            playerExp = other.GetComponentInParent<PlayerExperience>();
        if (playerExp != null)
        {
            playerExp.GetExp(_value);
            Destroy(gameObject);
        }
    }
}