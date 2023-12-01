using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _step = 0.05f;
    private float _minVolume = 0;
    private float _maxVolume = 1;
    private WaitForSeconds _sleep = new WaitForSeconds(0.1f);

    private Coroutine _increaseVolume;
    private Coroutine _decreaseVolume;

    private void Start()
    {
        _audioSource.volume = _minVolume;
    }

    public void RougeEnter()
    {
        TryPlayAudioSurce();

        if (_decreaseVolume != null)
            StopCoroutine(_decreaseVolume);

        _increaseVolume = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void RougeExit()
    {
        if (_increaseVolume != null)
            StopCoroutine(_increaseVolume);

        _decreaseVolume = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _step);

            yield return _sleep;
        }

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
