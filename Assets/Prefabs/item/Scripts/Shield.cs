using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public int shieldHp = 10;

    public float GetRegen()
    {
        return shieldHp;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
