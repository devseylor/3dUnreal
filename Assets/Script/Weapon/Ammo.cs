using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] _ammoSlots;

    [System.Serializable]
    private class AmmoSlot 
    {
        public AmmoType _ammoType;
        public int _ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType)._ammoAmount; 
    }
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType)._ammoAmount--;
    }
    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoToIncrease)
    {
        GetAmmoSlot(ammoType)._ammoAmount += ammoToIncrease;
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in _ammoSlots)
        {
            if(slot._ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
