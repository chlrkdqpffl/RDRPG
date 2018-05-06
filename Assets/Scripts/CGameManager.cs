using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour {

	public int nowStage = 1;
    public int nowWave = 1;
    
	// ======= UI Variable ====== //


	// ========================== //
    
	private float gameTime;

	private static CGameManager _instance = null;
	public static CGameManager Instance
	{
		get
		{ 
			if (_instance == null){
				_instance = FindObjectOfType<CGameManager> ();

				if (_instance == null) {
					Debug.LogError ("Not Create Instance");
				}
			}

			return _instance;
		}
	}

	void Awake()
	{
	
	}

	void Start()
	{

	}

	void Update()
	{
	//	if(fpsText)
	//		fpsText.text = (1.0f / Time.deltaTime).ToString("N0");

	}

    /*
	void UpdateGameTime()
	{
		if (isStart == true) {
			gameTime -= Time.deltaTime;
			TimeImage.fillAmount = gameTime / stageRemainTime;
		}

		if (gameTime < 0) {
			StageClear ();

			gameTime = 999;
		}
	}
    */
    
	public void StopGame()
	{
		Time.timeScale = 0.0f;
	}

	public void PlayGame()
	{
		Time.timeScale = 1.0f;
	}

    /*
	public IEnumerator FadeOut()
	{
		Color color = FrontImage.color;
		float fTime = 0.0f;

		color.a = Mathf.Lerp (0.0f, 1.0f, fTime);
		FrontImage.gameObject.SetActive (true);

		while (color.a < 1.0f) {

			fTime += Time.deltaTime / 2.0f;

			color.a = Mathf.Lerp (0.0f, 1.0f, fTime);
			FrontImage.color = color;

			yield return null;
		}

		SceneManager.LoadScene (0);
	}
    */
}
