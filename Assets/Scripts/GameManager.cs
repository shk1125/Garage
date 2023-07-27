using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GameManager : MonoBehaviour
{
    
    public List<GameObject> carPrefabs;
    public Button prevCarButton;
    public Button nextCarButton;
    public Text carNameText;
    public Text carInfoText;
    public Transform placeHolderTransform;

    private List<GameObject> carPool;

    public static GameManager instance;

    private int icurrentCarNum;

    private CarProperty carProperty;

    [System.Serializable]
    public class CarJson
    {
        public string Name;
        public string Type;
        public string Price;
        public string ID;
        public string Size;
        public string Date;
    }



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    void Start()
    {
        Application.targetFrameRate = 60;

       
        //List<CarJson> carJsons = JsonConvert.DeserializeObject<List<CarJson>>(Resources.Load<TextAsset>("carJson").text);

        
        carPool = new List<GameObject>();
        for(int i = 0; i < carPrefabs.Count; i++)
        {
            carProperty = Instantiate(carPrefabs[i], placeHolderTransform).GetComponent<CarProperty>();

            //carProperty.SetProperty(carJsons[i]);

            
            carPool.Add(carProperty.gameObject);
            carPool[i].gameObject.SetActive(false);
        }
        SetCarNameAndInfoText(carPool[0].GetComponent<CarProperty>());
        
        carPool[0].gameObject.SetActive(true);
    }

    



    public void NextCar()
    {
        if(icurrentCarNum == (carPool.Count-1))
        {
            carPool[icurrentCarNum].SetActive(false);
            icurrentCarNum = 0;
            carPool[icurrentCarNum].SetActive(true);
        }
        else
        {
            carPool[icurrentCarNum].SetActive(false);
            carPool[++icurrentCarNum].SetActive(true);
        }
        SetCarNameAndInfoText(carPool[icurrentCarNum].GetComponent<CarProperty>());
    }

    public void PrevCar()
    {
        if (icurrentCarNum == 0)
        {
            carPool[icurrentCarNum].SetActive(false);
            icurrentCarNum = (carPool.Count-1);
            carPool[icurrentCarNum].SetActive(true);
        }
        else
        {
            carPool[icurrentCarNum].SetActive(false);
            carPool[--icurrentCarNum].SetActive(true);
        }
        SetCarNameAndInfoText(carPool[icurrentCarNum].GetComponent<CarProperty>());
    }

    
    void SetCarNameAndInfoText(CarProperty carProperty)
    {
        carNameText.text = carProperty.GetCarName();
        carInfoText.text = carProperty.GetCarProperty();
    }


}
