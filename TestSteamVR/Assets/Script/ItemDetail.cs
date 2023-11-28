using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDetail : MonoBehaviour
{
    public string name,detail;
    public int energy,fat,vitamin;
    public Sprite image2d;
    public ItemDetail(string Name, string Detail, int Energy, int Fat, int Vitamin,Sprite image)
    {
        name = Name;
        detail = Detail;
        energy = Energy;
        fat = Fat;
        vitamin = Vitamin;
        image2d = image;
    }
}
