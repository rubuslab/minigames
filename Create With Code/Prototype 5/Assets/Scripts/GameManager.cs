using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // public variables
    public GameObject[] thingsPrefabs;
    public TextMeshProUGUI textScore;

    // private variables
    private float m_spawnRate = 3.2f;
    private int score = 0;
    private bool m_isGameOver = false;

    private ParticleSystem m_particleRed;
    private ParticleSystem m_particleBlack;

    // Start is called before the first frame update
    void Start()
    {
        // deactive gameover text
        GameObject gameover = GameObject.Find("UI/Canvas/GameOver");
        gameover.SetActive(false);

        GameObject obj = GameObject.Find("Particles/Explosion_Red");
        m_particleRed = obj.GetComponent<ParticleSystem>();
        GameObject obj2 = GameObject.Find("Particles/Explosion_Black");
        m_particleBlack = obj2.GetComponent<ParticleSystem>();

        UpdateScore();

        // InvokeRepeating("SpawnThingObject", 3.0f, 3.2f);
        StartCoroutine(SpawnObject());
    }

    private void UpdateScore()
    {
        textScore.text = score.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("hit object tag: " + hit.transform.tag);
                if (hit.transform.CompareTag("GoodThing") || hit.transform.CompareTag("BadThing"))
                {
                    ParticleSystem particle = null;
                    if (hit.transform.CompareTag("GoodThing")) {
                        score += 10;
                        particle = m_particleRed;
                    }
                    if (hit.transform.CompareTag("BadThing")) {
                        score += -15;
                        particle = m_particleBlack;
                    }

                    Object.Destroy(hit.transform.gameObject);

                    particle.transform.position = hit.transform.position;
                    particle.Play();

                    UpdateScore();

                    if (score <= 0) {
                        GameOver();
                    }
                }
            }
        }
    }

    //private void SpawnThingObject()
    //{
    //    GameObject obj = thingsPrefabs[Random.Range(0, thingsPrefabs.Length)];
    //    Instantiate(obj);
    //}

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_spawnRate);
            if (!m_isGameOver)
            {
                int index = Random.Range(0, thingsPrefabs.Length);
                Instantiate(thingsPrefabs[index]);
            }
            else {
                break;
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over.");
        m_isGameOver = true;

        GameObject gameover = GameObject.Find("UI/Canvas/GameOver");
        gameover.SetActive(true);

        StopCoroutine(SpawnObject());
        score = 0;
        UpdateScore();
    }
}
