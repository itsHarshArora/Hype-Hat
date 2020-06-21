using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public GameObject CollectCollectPS;
    public GameObject restartPanel;

    public GameObject deathSfx;
    public GameObject coinSfx;

    public GameObject deathPS;

    private void Start()
    {
        restartPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Instantiate(coinSfx, gameObject.transform.position, Quaternion.identity);
            CoinTextScript.coinAmount += 1;
            Instantiate(CollectCollectPS, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Death")
        {
            Instantiate(deathPS, gameObject.transform.position, Quaternion.identity);
            Instantiate(deathSfx, gameObject.transform.position, Quaternion.identity);
            ScoreCounter.pointIncreasePerSecond = 0;
            Destroy(gameObject);
            restartPanel.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GroundA" && ColourSwitch.secondndMaterial == true)
        {
            Instantiate(deathPS, gameObject.transform.position, Quaternion.identity);
            Instantiate(deathSfx, gameObject.transform.position, Quaternion.identity);
            ScoreCounter.pointIncreasePerSecond = 0;
            Destroy(gameObject);
            restartPanel.SetActive(true);
        }
        if (collision.gameObject.tag == "GroundB" && ColourSwitch.firstMaterial == true)
        {
            Instantiate(deathPS, gameObject.transform.position, Quaternion.identity);
            Instantiate(deathSfx, gameObject.transform.position, Quaternion.identity);
            ScoreCounter.pointIncreasePerSecond = 0;
            Destroy(gameObject);
            restartPanel.SetActive(true);
        }
    }
}
