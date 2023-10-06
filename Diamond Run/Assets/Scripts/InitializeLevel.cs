using UnityEngine;
using System.Collections;
using System.IO;

public class InitializeLevel : MonoBehaviour {

	public string fileName;
	public StreamReader sr;
	public Vector3 pos = new Vector3();

	// Use this for initialization
	void Start ()
	{
		// Create the walls and pillars
		for (int i = 0; i < 1000; i+=10)
		{
			GameObject leftPillar = (GameObject)Instantiate(Resources.Load("Pillar"));
			leftPillar.transform.position = new Vector3(-5.0f, 0, i);
			GameObject rightPillar = (GameObject)Instantiate(Resources.Load("Pillar"));
			rightPillar.transform.position = new Vector3(5.0f, 0, i);
        }

		LoadGems("gem_data.txt");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void LoadGems(string fileName)
	{
		try
		{
			sr = new StreamReader(Application.dataPath + "/" + fileName);
			string dataline = "";

			while ((dataline = sr.ReadLine()) != null)
			{
				Debug.Log(dataline);

				string[] values = dataline.Split(',');

				if((values.Length).Equals(4))
				{
                    pos.x = float.Parse(values[1]);
                    pos.y = float.Parse(values[2]);
                    pos.z = float.Parse(values[3]);

                    GameObject gem = (GameObject)Instantiate(Resources.Load(values[0]));
                    gem.transform.position = pos;
                }
				
			}

			sr.Close();
		}

		catch (FileNotFoundException e)
		{
			Debug.Log("Your file could not be found.");
		}

		catch (FileLoadException e)
		{
			Debug.Log("Your file could not be loaded");
		}

		catch(IOException e)
		{
			Debug.Log("There are errors with your file.");
		}

    }

}
