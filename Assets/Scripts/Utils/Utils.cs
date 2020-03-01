using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static List<T> Shuffle<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int randomIndex = Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }

        return _list;
    }

    public static string GetRandomFirstName()
    {
        var names = new List<string>();
        names.Add("Moggy");
        names.Add("Palma");
        names.Add("Exox");
        names.Add("Lana");
        names.Add("Alistar");
        names.Add("Danel");
        names.Add("Mavric");
        names.Add("Chrose");
        names.Add("Antap");
        names.Add("Membem");
        names.Add("Sada");
        names.Add("Togop");
        names.Add("Yeta");
        names.Add("Pomly");
        names.Add("Inter");
        names.Add("Wolly");
        names.Add("Umberg");
        names.Add("Sinny");
        names.Add("Skiz");
        names.Add("Eta");
        return Shuffle(names)[3];
    }
    
    public static string GetRandomLastName()
    {
        var names = new List<string>();
        names.Add("Toast");
        names.Add("VHS");
        names.Add("Long");
        names.Add("Tesco");
        names.Add("Pepsi");
        names.Add("Woofer");
        names.Add("Point");
        names.Add("Marx");
        names.Add("Tall");
        names.Add("Long");
        names.Add("Flan");
        names.Add("Panasonic");
        names.Add("Axis");
        names.Add("Atari");
        names.Add("Derian");
        names.Add("Time");
        names.Add("Fool");
        names.Add("Livingston");
        names.Add("Sad");
        names.Add("Volume");
        return Shuffle(names)[3];
    }
}