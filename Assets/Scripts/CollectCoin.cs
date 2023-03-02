using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{

    [SerializeField] private AudioClip coinSound;
    private void Awake()
    {
        
    }

    private void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().Coins1++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Coins1--;
            //GameObject.Find("GameManager").GetComponent<GameManager>().RefreshCoin();
            GameObject.Find("SoundFX").GetComponent<AudioSource>().clip = coinSound;
            GameObject.Find("SoundFX").GetComponent<AudioSource>().PlayOneShot(coinSound);
            Destroy(gameObject);
           

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
