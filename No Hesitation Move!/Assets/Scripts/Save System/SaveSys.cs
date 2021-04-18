using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSys
{
	public static void save_data()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.lhr";
		FileStream stream = new FileStream(path, FileMode.Create);

		SaveData data = new SaveData();

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static SaveData load_data()
	{
		string path = Application.persistentDataPath + "/player.lhr";
		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			SaveData new_data = formatter.Deserialize(stream) as SaveData;
			stream.Close();

			return new_data;

		}else{
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}
}
