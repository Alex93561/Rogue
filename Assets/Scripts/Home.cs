using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnCollisionEnter(Collision collision)
    {
        _alarm.RougeEnter();
    }

    private void OnCollisionExit(Collision collision)
    {
        _alarm.RougeExit();
    }
}