using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimalContainer : MonoBehaviour {

	private Dictionary<int, GameObject> animalPrefabDic;
	public Dictionary<string, List<GameObject>> animalDic;

	private static CAnimalContainer _instance = null;
	public static CAnimalContainer Instance
	{
		get
		{ 
			if (_instance == null){
				_instance = FindObjectOfType<CAnimalContainer> ();

				if (_instance == null) {
					Debug.LogError ("Not Create Instance");
				}
			}

			return _instance;
		}
	}

	void Awake()
	{
		animalPrefabDic = new Dictionary<int, GameObject> ();
		animalDic = new Dictionary<string, List<GameObject>> ();

		int count = 0;
		foreach(GameObject animal in Resources.LoadAll("Prefabs/FenceAnimal", typeof(GameObject)))
		{
			animalPrefabDic.Add(count++, animal);
		}

		for (int j = 0; j < animalPrefabDic.Count; ++j) {
			List<GameObject> animalList = new List<GameObject> ();

			for (int i = 0; i < 5; ++i) {
				GameObject obj = Instantiate (animalPrefabDic [j], this.gameObject.transform);
				obj.SetActive (false);

				animalList.Add (obj);
			}
			animalDic.Add(animalPrefabDic [j].name, animalList);

		}
	}
}