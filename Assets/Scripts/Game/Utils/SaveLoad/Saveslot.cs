using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saveslot : MonoBehaviour
{
    public static Saveslot instance;
    private void Start()
    {
        instance = this;
    }
    [Header("User")]
    public int SaveSlot;
    public string UserName;
    [Header("Content")]
    [SerializeField] private GameObject[] m_NoDataContent = new GameObject[4];
    [SerializeField] private GameObject[] m_HasDataContent = new GameObject[4];
    [SerializeField] private Button[] m_Button = new Button[4];

    private GameData _data;
    public void DataLoad()
    {
        List<GameData> datas = DataManager.instance.LoadAllSlots();
        int i = 0;
        foreach (GameData data in datas)
        {
            m_HasDataContent[i].SetActive(true);
            m_NoDataContent[i].SetActive(false);
            i++;
        }
        while (i < 4)
        {
            i++;
            m_HasDataContent[i].SetActive(true);
            m_NoDataContent[i].SetActive(false);
        }
    }
    public GameData GetData() => _data;
    public int GetSaveSlot() => SaveSlot;

    public void DeleteData()
    {
        if (_data == null) return;

    }
}
