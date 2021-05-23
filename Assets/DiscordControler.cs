using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using UnityEngine.SceneManagement;

public class DiscordControler : MonoBehaviour
{

	public Discord.Discord discord;

	// Use this for initialization
	void Start()
	{
		Scene activeScene = SceneManager.GetActiveScene();
		discord = new Discord.Discord(832643671055925248, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			
			State = $"Map: {activeScene.name}",
			Details = $"Version: {Application.version}"
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				//Debug.LogError("Everything is fine!");
			}
		});
	}

	// Update is called once per frame
	void Update()
	{
		discord.RunCallbacks();
	}
}