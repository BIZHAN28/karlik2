using UnityEngine;
using UnityEngine.UI;
public class HealingSystem : MonoBehaviour
{
    [SerializeField] 
    private int _value = 10;

    public int Value => _value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerHealth = other.GetComponentInParent<PlayerHealthSystem>();
        if (playerHealth == null)
            playerHealth = other.GetComponentInParent<PlayerHealthSystem>();
        if (playerHealth != null)
        {
            playerHealth.GetHealing(this);
            Destroy(gameObject);
        }
    }
}