using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject panelScore;
    public Text t_lastScore, t_highScore;
    public int lastScore, highScore;
    static public ScoreScript myScore_instance;


	private void Awake()
	{
        myScore_instance = this;
	}
	// Start is called before the first frame update
	void Start()
    {
        ShowPanel();

        //if(PlayerPrefs.GetInt("GameStatus", 0) == 1)
        //{
            //panelScore.SetActive(true);
        //}

    }

    public void ShowPanel(){
        
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        lastScore = PlayerPrefs.GetInt("MyScore", 0);
        if (lastScore > highScore)
        {
            highScore = lastScore;
            PlayerPrefs.SetInt("Highscore", highScore);
        }

        t_lastScore.text = "Last  Score : " + lastScore;
        t_highScore.text = "High Score : " + highScore;
        //panelScore.SetActive(true);
        print("Score TAMPIL"+"Skorku: "+lastScore+" Highscore: "+highScore);

    }
  
    public void DisablePanel()
    {
        panelScore.SetActive(false);
        //PlayerPrefs.SetInt("GameStatus", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
