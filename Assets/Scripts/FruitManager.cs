using System;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class FruitManager : MonoBehaviour
{
    [SerializeField] private Transform[] fruitPosition;
    [SerializeField] private GameObject fruitPrefab;


    private int fruitIndex;
    void Start()
    {
        fruitPosition = GetComponentsInChildren<Transform>();

        for (int i = 0; i < fruitPosition.Length; i++)
        {
            GameObject newFruit = Instantiate(fruitPrefab, fruitPosition[i]);



            int levelNumber = GameManager.instance.levelNumber;
            int totalAmountOffFruits = PlayerPrefs.GetInt("Level" + levelNumber + "TotalFruits");

            if(totalAmountOffFruits != fruitPosition.Length -1)
                PlayerPrefs.SetInt("Level" + levelNumber + "TotalFruits", fruitPosition.Length - 1);
            
        }
    }
}
