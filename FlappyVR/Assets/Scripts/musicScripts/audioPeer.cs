using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class audioPeer : MonoBehaviour {

	AudioSource _audiosource;
	public static float[] _samples = new float[512];
	public static float[] _freqBand = new float[8]; 
	// Use this for initialization
	void Start () {
		_audiosource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetSpectrumAudioSource ();
		MakeFreqBands ();
	}

	void GetSpectrumAudioSource (){
		_audiosource.GetSpectrumData (_samples, 0, FFTWindow.Blackman);
	}
	void MakeFreqBands(){
		int count = 0;
		for (int i = 0; i < 8; i++) {
			float average = 0;
			int sampleCount = (int)Mathf.Pow (2, 1) * 2;

			if (i == 7) {
				sampleCount += 2;
			}
			for (int j = 0; j < sampleCount; j++) {
				average += _samples [count] * (count + 1);
				count++;
			}
			average /= count;
			_freqBand [i] = average * 10;
		}
	}
}
