using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float RespawnTime = 90;
    public double CurrentTime = 0;
    public GameObject Coin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Coin.activeSelf == false)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
            }
            else
            {
                Coin.SetActive(true);
                CurrentTime = RespawnTime;
            }
        }
    }
}
