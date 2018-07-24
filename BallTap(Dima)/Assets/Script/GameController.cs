using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    public GameObject ball;

    public GameObject BackgroundMenu;
    public GameObject scoreText;

    public GameObject[] platforms;

    private List<GameObject> redPlatforms;
    // Use this for initialization
    void Start () {
        redPlatforms = new List<GameObject>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
        foreach(GameObject platform in platforms)
        {
            switch (platform.GetComponent<Platform>().BallCollision)
            {
                case 1: PlatformColor(platform);
                    break;
                case 2: GameOver();
                    break;
            }
        }

	}

    private void PlatformColor(GameObject onePlatform)
    {        
        if(redPlatforms.Count == 4 && !redPlatforms.Contains(onePlatform))
        {
            RemuveRedPlatform(onePlatform);

            AddRedPlatform(onePlatform);
        }
        else if(redPlatforms.Count < 4 && !redPlatforms.Contains(onePlatform))
        {
            AddRedPlatform(onePlatform);
        }        
    }

    private void RemuveRedPlatform(GameObject onePlatform)
    {
        redPlatforms[0].GetComponent<Renderer>().material.color = Color.white;
        redPlatforms[0].GetComponent<Platform>().BallCollision = 0;
        redPlatforms[0].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        redPlatforms.RemoveAt(0);
    }

    private void AddRedPlatform(GameObject onePlatform)
    {
        onePlatform.GetComponent<Renderer>().material.color = Color.red;
        onePlatform.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        redPlatforms.Add(onePlatform);
    }

    private void GameOver()
    {
        BackgroundMenu.transform.position = new Vector3(0.0f, 0.0f, -2.0f);
        scoreText.transform.position = new Vector3(0.0f, 0.5f, -2.0f);
        string text = "Your score: " + scoreText.GetComponent<Text>().text;
        scoreText.GetComponent<Text>().text = text;
        Time.timeScale = 0;
    }

    public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
