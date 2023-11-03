using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetail : MonoBehaviour
{
    public string name,detail;
    public int energy,fat,vitamin;
    public ItemDetail(string Name, string Detail, int Energy, int Fat, int Vitamin)
    {
        name = Name;
        detail = Detail;
        energy = Energy;
        fat = Fat;
        vitamin = Vitamin;
    }
}
