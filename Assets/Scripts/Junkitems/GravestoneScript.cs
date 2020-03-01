using TMPro;
using UnityEngine;

public class GravestoneScript : MonoBehaviour
{
    public TextMeshPro graveText;

    public void NameGrave(string firstName, string lastName)
    {
        graveText.text = "DEAD\n" + firstName + "\n" + lastName;
    }
}