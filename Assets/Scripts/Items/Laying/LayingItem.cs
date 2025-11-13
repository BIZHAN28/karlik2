using UnityEngine;
public enum LayingTypes
{
	Healing,
	Damage_ups
}
public class LayingItem : MonoBehaviour
{
	public GameObject[] itemsPrefub;
	// 0 - for healing 
	// 1 - damage-ups
	public void Generate(Vector3 coordinates, LayingTypes type)
	{
		Instantiate(itemsPrefub[(int)type], coordinates, Quaternion.identity);
	}
}

