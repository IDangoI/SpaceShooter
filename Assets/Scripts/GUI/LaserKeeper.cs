using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LaserKeeper : MonoBehaviour {

    int weaponlv;
    private Text t_lv;

	void Start () {
        t_lv = GetComponent<Text>();
        PlayerController _lv = GameObject.Find("_Player").GetComponent<PlayerController>();
        weaponlv = _lv.laserLevel;
        t_lv.text = weaponlv.ToString();
	}

    public int TrackLv(int points)
    {
        weaponlv += points;
        t_lv.text = weaponlv.ToString();
        return weaponlv;
    }
}
