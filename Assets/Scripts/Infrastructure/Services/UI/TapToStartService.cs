using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Canvas))]
public class TapToStartService : MonoBehaviour
{
    [SerializeField] private Transform _text;
    [SerializeField] private float _showDelay = 0.6f;
    [SerializeField] private float _scaleDelay = 0.3f;
    [SerializeField] private float _scaleModifier = 1.6f;
    [SerializeField] private float _duration = 0.6f;
    [SerializeField] private Canvas _canvas;
    private Vector3 _showPosition;
    private Vector3 _hidePosition;


    private void Awake()
    {
        _canvas.enabled = false;
        _showPosition = _text.position;
        _hidePosition = _showPosition - _showPosition.y * 2 * Vector3.up;
    }

    public void Show()
    {
        Reset();
        StartCoroutine(Showing());
    }

    public void Hide()
    {
        Reset();
        _text.DOMoveY(_hidePosition.y, _showDelay).SetEase(Ease.InOutBack).OnComplete(() =>
        {
            _canvas.enabled = false;
        });
    }

    private IEnumerator Showing()
    {
        _text.localScale = Vector3.one;
        _canvas.enabled = true;
        _text.position = _hidePosition;
        yield return _text
            .DOMoveY(_showPosition.y, _showDelay)
            .SetDelay(_showDelay)
            .SetEase(Ease.OutBack)
            .WaitForCompletion();
        _text
            .DOScale(Vector3.one * _scaleModifier, _duration)
            .SetDelay(_scaleDelay)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void Reset()
    {
        StopAllCoroutines();
        DOTween.Kill(_text);
    }
}
