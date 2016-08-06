using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public int damage = 1;
    public float laserSpeed = 2f;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
