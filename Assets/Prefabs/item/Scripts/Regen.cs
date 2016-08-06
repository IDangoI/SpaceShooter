using UnityEngine;
using System.Collections;

public class Regen : MonoBehaviour {

    public int regenAmount = 1;

    public int GetRegen()
    {
        return regenAmount;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
