using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPKeeper : MonoBehaviour {

    int hp;
    private Text t_Hp;

	void Start () {
	    t_Hp = GetComponent<Text>();
        PlayerController _hp = GameObject.Find("_Player").GetComponent<PlayerController>();
        hp = _hp.hp;
        t_Hp.text = hp.ToString();
	}

    public int TrackHP(int points)
    {
        hp += points;
        t_Hp.text = hp.ToString();
        return hp;
    }
}
