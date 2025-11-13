using UnityEngine;
public class Bootstrap : MonoBehaviour
{
    public void Awake()
    {
        new EventBus();
    }
}