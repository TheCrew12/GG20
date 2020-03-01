using UnityEngine;

public class TrumpetScript : MonoBehaviour
{
    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Monster")
        {
            sound.Play();
        }
    }
}
