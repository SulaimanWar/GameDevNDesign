using UnityEngine;

public class Pickup : MonoBehaviour
{

    public enum PickupType
    {
        WEAPON, INVENTORY
    }
    public PickupType pickupType;

    public enum KeyType
    {
        FLOAT, INT, STRING
    }

    [Space(20)]
    
    public KeyType keyType;

    public string keyName;

    public float floatKey;
    public int intKey;
    public string stringKey;
}
