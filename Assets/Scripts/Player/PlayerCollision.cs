using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if (HealthManager.health <=0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if(collision.transform.tag == "Zombie")
        {
            HealthManager.health--;
            if (HealthManager.health <=0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if(collision.transform.tag == "Win")
        {
            PlayerManager.isYouWin = true;
            gameObject.SetActive(false);
            AudioManager.instance.Play("YouWin");

        }



        IEnumerator GetHurt()
        {
            Physics2D.IgnoreLayerCollision(6,8);
            GetComponent<Animator>().SetLayerWeight(1, 1);
            yield return new WaitForSeconds(3);
            GetComponent<Animator>().SetLayerWeight(1, 0);
            Physics2D.IgnoreLayerCollision(6,8, false);
        }
    }
}