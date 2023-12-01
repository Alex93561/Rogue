using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _step = 0.05f;
    private float _minVolume = 0;
    private float _maxVolume = 1;
    private WaitForSeconds _sleep = new WaitForSeconds(0.1f);
    private Coroutine _changeVolume;

    private void Start()
    {
        _audioSource.volume = _minVolume;
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryPlayAudioSurce();
        _changeVolume = StartCoroutine(ChangeVolume(_maxVolume));
    }

    private void OnCollisionExit(Collision collision)
    {
        _changeVolume = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        if (_changeVolume != null)
            StopCoroutine(_changeVolume);

        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _step);

            yield return _sleep;
        }

        StopCoroutine(_changeVolume);
        TryStopAudioSurce();
    }

    private void TryPlayAudioSurce()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();
    }

    private void TryStopAudioSurce()
    {
        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}