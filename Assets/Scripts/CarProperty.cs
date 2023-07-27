using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class CarProperty : MonoBehaviour
{
    private string Name;
    private string Type;
    private int Price;
    private string ID;
    private string Size;
    private string Date;



    public void SetProperty(GameManager.CarJson carJson)
    {
        Name = carJson.Name;
        Type = carJson.Type;
        Price = int.Parse(carJson.Price);
        ID = carJson.ID;
        Size = carJson.Size;
        Date = carJson.Date;
    }

    public string GetCarProperty()
    {
        return "��Ī : " + Name + "\n"
            + "���� : " + Type + "\n"
            + " ���� : " + Price + "\n"
            + "ID : " + ID + "\n"
            + "�԰� : " + Size + "\n"
            + "����� : " + Date + "\n"; 
    }

    public string GetCarName()
    {
        return Name;
    }
}
