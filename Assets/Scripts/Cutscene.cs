using System.Collections;
using UnityEngine;

public abstract class Cutscene : MonoBehaviour
{
    private Coroutine _coroutine;

    protected abstract IEnumerator Play();
    protected abstract void End();

    protected virtual void Start()
    {
        _coroutine = StartCoroutine(Play());
        PlayerPrefs.SetString("player", "orange");
    }

    protected virtual void Update()
    {
        if (Input.anyKeyDown) {
            StopCoroutine(_coroutine);
            End();
        }
    }
}