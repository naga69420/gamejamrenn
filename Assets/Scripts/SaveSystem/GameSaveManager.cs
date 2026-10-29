
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
	[SerializeField] private Transform player;

	// Example game values
	public int playerHealth = 100;
	public int coins = 0;

	public void SaveGame()
	{
		SaveData data = new SaveData();

		data.playerPosition = player.position;
		data.playerHealth = playerHealth;

		SaveSystem.Save(data);
	}

	public void LoadGame()
	{
		SaveData data = SaveSystem.Load();

		if (data == null)
			return;

		player.position = data.playerPosition;
		playerHealth = data.playerHealth;

		Debug.Log("Game loaded!");
	}
}
