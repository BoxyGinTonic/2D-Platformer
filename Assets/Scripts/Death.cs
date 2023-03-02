using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
            StartCoroutine(ReloadLevel());
        }
    }

    private void Die()
    {
        rigid.bodyType = RigidbodyType2D.Static; 
        anim.SetTrigger("Die"); 
        
    }

   IEnumerator ReloadLevel()
   {
        yield return new WaitForSeconds(0.5f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("GameManager").GetComponent<GameManager>().playerpos;
        rigid.bodyType = RigidbodyType2D.Dynamic;        
        anim.ResetTrigger("Die");
        anim.SetTrigger("Revive");

   }

    
}
