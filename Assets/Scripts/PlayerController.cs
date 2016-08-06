using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public GameObject theShield;

    public float speed = 5f;
    public float laserSpeed = 2f;
    public float fireDelay = 0.5f;
    public int laserLevel = 1;
    public int hp = 1;

    public AudioClip fireSound; 

    float xmin = -5;
    float xmax = 5;

    private HPKeeper s_HPKeeper;
    private LaserKeeper s_laserlv;

	// Use this for initialization
	void Start () {

        //Android
        if (Application.platform == RuntimePlatform.Android)
        {
            InvokeRepeating("Fire", 0.00000001f, fireDelay);
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        s_HPKeeper = GameObject.Find("HP").GetComponent<HPKeeper>();
        s_laserlv = GameObject.Find("lv").GetComponent<LaserKeeper>();
            
        float distance = transform.position.z - Camera.main.transform.position.z;       
        Vector3 lmost =Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = lmost.x + 0.5f;
        xmax = rmost.x - 0.5f;
	}

    void Fire()         //Laser fire
    {
        Vector3 offset = new Vector3(0f, 0.7f, 0f);
        if (laserLevel == 1) {
            GameObject beam = Instantiate(laser1, transform.position + offset, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
        }
        else if (laserLevel == 2)
        {
            GameObject beam = Instantiate(laser2, transform.position + offset, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
        }
        else if (laserLevel == 3)
        {
            GameObject beam = Instantiate(laser3, transform.position + offset, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
        }
        else if (laserLevel == 4)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
        }
        else if (laserLevel == 5)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser1, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser1, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed - 0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed - 0.5f, 0);
        }
        else if (laserLevel == 6)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser2, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser2, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed - 0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed - 0.5f, 0);
        }
        else if (laserLevel == 7)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser3, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser3, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed - 0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed - 0.5f, 0);
        }
        else if (laserLevel == 8)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed -0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed -0.5f, 0);
        }
        else if (laserLevel == 9)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            GameObject beam_l2 = Instantiate(laser1, transform.position + offset, Quaternion.Euler(0, 0, 30)) as GameObject;
            GameObject beam_r2 = Instantiate(laser1, transform.position + offset, Quaternion.Euler(0, 0, -30)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed - 0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed - 0.5f, 0);
            beam_l2.GetComponent<Rigidbody2D>().velocity = new Vector3(-3, laserSpeed - 1.5f, 0);
            beam_r2.GetComponent<Rigidbody2D>().velocity = new Vector3(3, laserSpeed - 1.5f, 0);
        }
        else if (laserLevel == 10)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            GameObject beam_l2 = Instantiate(laser2, transform.position + offset, Quaternion.Euler(0, 0, 30)) as GameObject;
            GameObject beam_r2 = Instantiate(laser2, transform.position + offset, Quaternion.Euler(0, 0, -30)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed - 0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed - 0.5f, 0);
            beam_l2.GetComponent<Rigidbody2D>().velocity = new Vector3(-3, laserSpeed - 1.5f, 0);
            beam_r2.GetComponent<Rigidbody2D>().velocity = new Vector3(3, laserSpeed - 1.5f, 0);
        }
        else if (laserLevel == 11)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            GameObject beam_l2 = Instantiate(laser3, transform.position + offset, Quaternion.Euler(0, 0, 30)) as GameObject;
            GameObject beam_r2 = Instantiate(laser3, transform.position + offset, Quaternion.Euler(0, 0, -30)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed - 0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed - 0.5f, 0);
            beam_l2.GetComponent<Rigidbody2D>().velocity = new Vector3(-3, laserSpeed - 1.5f, 0);
            beam_r2.GetComponent<Rigidbody2D>().velocity = new Vector3(3, laserSpeed - 1.5f, 0);
        }
        else if (laserLevel == 12)
        {
            GameObject beam = Instantiate(laser4, transform.position + offset, Quaternion.identity) as GameObject;
            GameObject beam_l1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, 15)) as GameObject;
            GameObject beam_r1 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, -15)) as GameObject;
            GameObject beam_l2 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, 30)) as GameObject;
            GameObject beam_r2 = Instantiate(laser4, transform.position + offset, Quaternion.Euler(0, 0, -30)) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
            beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, laserSpeed - 0.5f, 0);
            beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, laserSpeed - 0.5f, 0);
            beam_l2.GetComponent<Rigidbody2D>().velocity = new Vector3(-3, laserSpeed - 1.5f, 0);
            beam_r2.GetComponent<Rigidbody2D>().velocity = new Vector3(3, laserSpeed - 1.5f, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // This is PC input
        // Control the Ship use left and right arrow
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.00000001f, fireDelay);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        //This is for Android
        transform.Translate(Input.acceleration.x, 0, 0);


        //Clamp player to Camera
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector2(newX, transform.position.y);


    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Laser _missile = collider.gameObject.GetComponent<Laser>();
        Regen _regen = collider.gameObject.GetComponent<Regen>();
        Shield _shield = collider.gameObject.GetComponent<Shield>();
        Laserlv _laserlv = collider.gameObject.GetComponent<Laserlv>();

        ScoreKeeper scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

        if (_missile)
        {
            hp -= _missile.GetDamage();
            _missile.Hit();
            s_HPKeeper.TrackHP(-(_missile.damage));    
                    
            if(laserLevel > 1)
            {
                laserLevel -= 1;
                s_laserlv.TrackLv(-1);
            }
            if (hp <= 0)
            {
                Die();
            }
        }

        if (_regen)
        {
            hp += _regen.GetRegen();
            s_HPKeeper.TrackHP(_regen.regenAmount);
            _regen.Hit();
        }
        if(_shield)
        {
            if (Shielded() == false)
            {
                foreach (Transform child in transform)
                {
                    GameObject newShield = Instantiate(theShield, transform.position, Quaternion.identity) as GameObject;
                    newShield.transform.parent = child;
                }
            }
            else
            {
                foreach (Transform child in transform)
                {
                    Destroy(GameObject.FindWithTag("Shield"));
                    GameObject newShield = Instantiate(theShield, transform.position, Quaternion.identity) as GameObject;
                    newShield.transform.parent = child;
                }

            }
            _shield.Hit();            
        }

        if (_laserlv)
        {
            if (laserLevel >= 12)
            {
                laserLevel = 12;
                scoreKeeper.Score(1000);
            }
            else
            {
                laserLevel++;
                s_laserlv.TrackLv(1);
            }            
            _laserlv.Hit();
        }
    }

    bool Shielded()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if(childPositionGameObject.childCount > 0)
            {
                return true;               
            }
        }
        return false;
    }
    
    void Die()
    {
        LevelManager lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        lm.LoadLevel("Lose");
        Destroy(gameObject);
    }
 }