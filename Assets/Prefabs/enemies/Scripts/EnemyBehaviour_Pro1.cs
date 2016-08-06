using UnityEngine;
using System.Collections;

public class EnemyBehaviour_Pro1 : MonoBehaviour {

    public GameObject enemyLaser;
    public float laserSpeed = 2f;
    public float hp = 1f;
    public float fireRate = 0.5f;
    public int scoreValue = 5;

    //item drop setting
    public GameObject regen;
    public GameObject shield;
    public GameObject laserUp;
    public float regenDrop = 1f;
    public float shieldDrop = 1f;
    public float laserDrop = 1f;
    
    public AudioClip fireSound;
    public AudioClip deathSound;
    public AudioClip hitSound;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        float probability = Time.deltaTime * fireRate;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject beam = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        GameObject beam_l1 = Instantiate(enemyLaser, transform.position, Quaternion.Euler(0, 0, -15)) as GameObject;
        GameObject beam_r1 = Instantiate(enemyLaser, transform.position, Quaternion.Euler(0, 0, 15)) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -laserSpeed, 0);
        beam_l1.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, -laserSpeed + 0.5f, 0);
        beam_r1.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, -laserSpeed + 0.5f, 0);

        GameObject missile = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);

        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
        Laser missile = collider.gameObject.GetComponent<Laser>();
        if (missile)
        {
            hp -= missile.GetDamage();
            missile.Hit();
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);

        if (Random.value <= 0.3)
        {
            if(Random.value < regenDrop)
            {
                Regen();
            }
        }
        else if(Random.value >0.3 && Random.value <= 0.6)
        {
            if(Random.value < shieldDrop)
            {
                Shield();
            }
        }
        else
        {
            if(Random.value < laserDrop)
            {
                Laser();
            }
        }

    }
    void Regen()
    {
        GameObject _regen = Instantiate(regen, transform.position, Quaternion.identity) as GameObject;
        _regen.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f);
    }
    void Shield()
    {
        GameObject _shield = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
        _shield.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f);
    }
    void Laser()
    {
        GameObject _laser = Instantiate(laserUp, transform.position, Quaternion.identity) as GameObject;
        _laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f);
    }

}
