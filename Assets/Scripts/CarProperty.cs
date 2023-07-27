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
        return "명칭 : " + Name + "\n"
            + "차종 : " + Type + "\n"
            + " 가격 : " + Price + "\n"
            + "ID : " + ID + "\n"
            + "규격 : " + Size + "\n"
            + "출고일 : " + Date + "\n"; 
    }

    public string GetCarName()
    {
        return Name;
    }
}
