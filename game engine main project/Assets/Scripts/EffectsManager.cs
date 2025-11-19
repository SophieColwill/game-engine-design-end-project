using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsManager : MonoBehaviour
{
    [Header("Sell")]
    [SerializeField] GameObject MoneyPrefab;
    [SerializeField] int AmountOfCoinsToGrab;
    GameObject[] allInstantiatedMoneyPrefabs;
    float[] currentCurrencySpeed;
    [SerializeField] Vector2 coinXStartLocation;
    [SerializeField] Vector2 coinYStartLocation;
    [SerializeField] float LowerBounds;

    [SerializeField] Sprite MoneySprite;
    [SerializeField] Sprite HammerSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allInstantiatedMoneyPrefabs = new GameObject[AmountOfCoinsToGrab];
        currentCurrencySpeed = new float[AmountOfCoinsToGrab];

        for(int i = 0; i < allInstantiatedMoneyPrefabs.Length; i++)
        {
            allInstantiatedMoneyPrefabs[i] = Instantiate(MoneyPrefab);
            allInstantiatedMoneyPrefabs[i].SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < allInstantiatedMoneyPrefabs.Length; i++)
        {
            if (allInstantiatedMoneyPrefabs[i].activeSelf)
            {
                allInstantiatedMoneyPrefabs[i].transform.position += Vector3.up * currentCurrencySpeed[i] * Time.deltaTime;

                if (allInstantiatedMoneyPrefabs[i].transform.position.y <= LowerBounds)
                {
                    allInstantiatedMoneyPrefabs[i].SetActive(false);
                }
                else
                {
                    currentCurrencySpeed[i] -= Time.deltaTime * 9;
                }
            }
        }
    }

    public void InitiateEffect(bool isBuild)
    {
        for (int i = 0; i < allInstantiatedMoneyPrefabs.Length; i++)
        {
            if (!allInstantiatedMoneyPrefabs[i].activeSelf)
            {
                allInstantiatedMoneyPrefabs[i].SetActive(true);
                allInstantiatedMoneyPrefabs[i].transform.position = new Vector3(Random.Range(coinXStartLocation.x, coinXStartLocation.y), Random.Range(coinYStartLocation.x, coinYStartLocation.y));
                currentCurrencySpeed[i] = -2;

                SpriteRenderer imageRenderer = allInstantiatedMoneyPrefabs[i].GetComponent<SpriteRenderer>();

                if (isBuild)
                {
                    imageRenderer.sprite = HammerSprite;
                }
                else
                {
                    imageRenderer.sprite = MoneySprite;
                }
            }
        }
    }
}
