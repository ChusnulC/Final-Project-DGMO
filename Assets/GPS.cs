using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        Auth();
    }

    public void Auth()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                txt.text = "Berhasil";
            }
            else
            {
                txt.text = "Gagal";
                Debug.Log("Gagal Login");
            }
        });
    }
    public void UnlockAchievement(string achievementID)
    {
        Social.ReportProgress(achievementID, 100f, (bool success) =>
        {
            Debug.Log("Achievement Unlocked");
        });
    }
}
