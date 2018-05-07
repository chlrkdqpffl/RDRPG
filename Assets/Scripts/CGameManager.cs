using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour {

    //	public int nowStage = 1;

    public int startMana;
    public float mana;

    private float totalTime;
    // ======= UI Variable ====== //
    public Text timeText;
    public Image summonImage;
    public Text summonText;

    public Image waveGage;
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

    private void Start()
    {
        mana = startMana;

        StageInfo stage = CDataFileManager.Instance.stageDic[1];

        for (int i = 0; i < stage.WaveData.Length; ++i)
        {
            totalTime += stage.WaveData[i].AppearCount * stage.WaveData[i].RepeatTime;
        }
    }

    void Update()
	{
        //	if(fpsText)
        //		fpsText.text = (1.0f / Time.deltaTime).ToString("N0");

        UpdateGameTime();
        UpdateMana();
        UpdateWaveGage();
    }

    private void UpdateMana()
    {
        if (mana < 200)
        {
            mana += Time.deltaTime * 10;
        }
        else mana = 200;

        summonImage.fillAmount = mana / 100;
        summonText.text = ((int)mana / 100).ToString() + "/2";
    }

    private void UpdateGameTime()
	{
        gameTime += Time.deltaTime;
        timeText.text = gameTime.ToString("N2");

    }
    
    private void UpdateWaveGage()
    {
        waveGage.fillAmount = gameTime / totalTime;
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
