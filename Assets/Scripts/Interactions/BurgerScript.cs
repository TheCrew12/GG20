using UnityEngine;

public class BurgerScript : MonoBehaviour
{
    public float FeedAmount = 0.5f;
    private bool eaten = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (eaten)
        {
            return;
        }

        if(other.gameObject.tag == "Monster")
        {
            var monster = other.gameObject.GetComponent<MonsterScript>();
            monster.AdultAgeScale += FeedAmount;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 1);
            eaten = true;
        }
    }
}
