using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    private Player _player;

    [SerializeField] // 0 = Triple shot, 1 = Speed, 2 = Shields
    private int powerupID;

    [SerializeField]
    private AudioClip _clip;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -5.55f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = GameObject.Find("Player").GetComponent<Player>();

            if (_player == null)
            {
                Debug.Log("player is null!");
            }

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if (_player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        _player.TripleShotActive();
                        break;
                    case 1:
                        _player.SpeedBoostActive();
                        break;
                    case 2:
                        _player.ShieldActive();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
            }

            Destroy(this.gameObject);
        }
    }
}