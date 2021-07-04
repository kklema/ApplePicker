using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [SerializeField]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> baskets;

    private void Start()
    {
        baskets = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tempBasket = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tempBasket.transform.position = pos;
            baskets.Add(tempBasket);
        }
    }

    public void DestroyFallenApples()
    {
        GameObject[] tempApples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in tempApples)
        {
            Destroy(apple);
        }

        int basketIndex = baskets.Count - 1;
        GameObject tempBasket = baskets[basketIndex];
        baskets.RemoveAt(basketIndex);
        Destroy(tempBasket);

        if (baskets.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}