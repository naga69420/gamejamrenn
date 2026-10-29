
using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
	private static string SavePath =>
		Path.Combine(
			Application.persistentDataPath,
			"save.json"
		);

	public static bool Save(SaveData data)
	{
		try
		{
			string json = JsonUtility.ToJson(data, true);

			File.WriteAllText(SavePath, json);

			Debug.Log("Game saved to: " + SavePath);
			return true;
		}
		catch (Exception e)
		{
			Debug.LogError("Save failed: " + e);
			return false;
		}
	}

	public static SaveData Load()
	{
		if (!File.Exists(SavePath))
		{
			Debug.Log("No save file found.");
			return null;
		}

		try
		{
			string json = File.ReadAllText(SavePath);

			return JsonUtility.FromJson<SaveData>(json);
		}
		catch (Exception e)
		{
			Debug.LogError("Load failed: " + e);
			return null;
		}
	}

	public static bool SaveExists()
	{
		return File.Exists(SavePath);
	}
}
