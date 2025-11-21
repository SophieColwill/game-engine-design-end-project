using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsManager : MonoBehaviour
{
    public bool useOptimisation = true;

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

    List<GameObject> NonOptimisedObjectsList = new List<GameObject>();

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
        if (useOptimisation)
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
        else
        {
            for (int i = 0; i < NonOptimisedObjectsList.Count; i++)
            {
                NonOptimisedObjectsList[i].transform.position -= Vector3.up * Time.deltaTime * 3;

                if (NonOptimisedObjectsList[i].transform.position.y <= LowerBounds)
                {
                    Destroy(NonOptimisedObjectsList[i].gameObject);
                    NonOptimisedObjectsList.Remove(NonOptimisedObjectsList[i]);
                }
            }
        }
    }

    public void InitiateEffect(bool isBuild)
    {
        if (useOptimisation)
        {
            for (int i = 0; i < allInstantiatedMoneyPrefabs.Length; i++)
            {
                if (!allInstantiatedMoneyPrefabs[i].activeSelf)
                {
                    allInstantiatedMoneyPrefabs[i].SetActive(true);
                    allInstantiatedMoneyPrefabs[i].transform.position = new Vector3(Random.Range(coinXStartLocation.x, coinXStartLocation.y), Random.Range(coinYStartLocation.x, coinYStartLocation.y));
                    currentCurrencySpeed[i] = Random.Range(-1.5f, -3.5f);

                    allInstantiatedMoneyPrefabs[i].transform.rotation = Quaternion.Euler(0,0, Random.Range(0, 360));

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
        else
        {
            for (int i = 0; i < AmountOfCoinsToGrab; i++)
            {
                GameObject newItem = Instantiate(MoneyPrefab);
                newItem.transform.position = new Vector3(Random.Range(coinXStartLocation.x, coinXStartLocation.y), Random.Range(coinYStartLocation.x, coinYStartLocation.y));

                SpriteRenderer imageRenderer = newItem.GetComponent<SpriteRenderer>();

                newItem.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

                if (isBuild)
                {
                    imageRenderer.sprite = HammerSprite;
                }
                else
                {
                    imageRenderer.sprite = MoneySprite;
                }

                NonOptimisedObjectsList.Add(newItem);
            }
        }
    }
}
