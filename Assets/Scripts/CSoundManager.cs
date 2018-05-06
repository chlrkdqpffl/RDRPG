using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSoundManager : MonoBehaviour {
	Dictionary<string, AudioSource> m_dicChannel;
	Dictionary<string, AudioClip> m_dicSound;

	private static CSoundManager _instance = null;
	public static CSoundManager Instance
	{
		get
		{ 
			if (_instance == null){
				_instance = FindObjectOfType<CSoundManager> ();

				if (_instance == null) {
					Debug.LogError ("Not Create Instance");
				}
			}

			return _instance;
		}
	}
		
	void Awake()
	{
		m_dicChannel = new Dictionary<string, AudioSource>();

		Transform trSound = GameObject.Find("Sound").transform;

		for (int i = 0; i < trSound.childCount; ++i)
		{
			Transform child = trSound.GetChild(i);

			m_dicChannel.Add(child.name, child.GetComponent<AudioSource>());
		}

		m_dicSound = new Dictionary<string, AudioClip>();

		AudioClip[] audios = Resources.LoadAll<AudioClip>("Sounds");

		for (int i = 0; i < audios.Length; ++i)
			m_dicSound.Add(audios[i].name, audios[i]);
	}

	public void PlaySound (string szSound, string szChannel, float fVolume = 1f)
	{
		if (!m_dicSound.ContainsKey(szSound))
			return;

		m_dicChannel[szChannel].PlayOneShot (m_dicSound[szSound]);
		m_dicChannel[szChannel].volume = fVolume;
	}

	public void StopSound(string szChannel)
	{
		m_dicChannel[szChannel].Stop();
	}

	public void SetVolume(string szChannel, float fVolume)
	{
		m_dicChannel[szChannel].volume = fVolume;
	}

	public bool IsPlaying(string szChannel)
	{
		if (m_dicChannel[szChannel].isPlaying)
			return true;

		return false;
	}
}