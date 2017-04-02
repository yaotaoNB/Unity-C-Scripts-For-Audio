using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

namespace Completed
{
	public class TaoAudioManager : MonoBehaviour 
	{
		public AudioSource[] efxSource;					
		public AudioSource musicSource;					
		public static TaoAudioManager instance = null;						
		public AudioMixerGroup sfx;
		public AudioMixerGroup music;

		int sourceNumber(){
			for(int i = 0;i < efxSource.Length;i++){
				if (!efxSource [i].isPlaying)
					return i;
				}
			return efxSource.Length - 1;
		}

		void Awake ()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy (gameObject);
			DontDestroyOnLoad (gameObject);
			efxSource [sourceNumber ()].outputAudioMixerGroup = sfx;
			musicSource.outputAudioMixerGroup = music;
		}


		public void PlaySingle(AudioClip clip)
		{
			efxSource[sourceNumber()].clip = clip;

			efxSource[sourceNumber()].Play();
		}


		public void RandomizeSfx (AudioClip[] clips)
		{
			int randomIndex = (int)Random.Range(0, clips.Length);

			efxSource[sourceNumber()].pitch = Random.Range(0.9f, 1.1f);

			efxSource[sourceNumber()].clip = clips[randomIndex];

			efxSource [sourceNumber ()].Play ();
		}
	}
}
