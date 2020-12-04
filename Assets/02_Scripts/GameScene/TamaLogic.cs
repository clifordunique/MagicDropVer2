using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TamaLogic : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ParticleSystem _effect;
    private static ParticleSystem _particleSystem;
    private void Start()
    {
        if (_particleSystem == null)
        {
            _particleSystem = Resources.Load<ParticleSystem>("Effect");
        }

        _effect = Instantiate(_particleSystem, transform);
        _effect.gameObject.SetActive(false);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    public void Splash(Action onComplete)
    {
        _spriteRenderer.enabled = false;
        _effect.gameObject.SetActive(true);
        
        Observable.Timer(TimeSpan.FromSeconds(_effect.main.startLifetimeMultiplier))
            .DoOnCompleted(() => Destroy(gameObject, 0.1f))
            .DoOnTerminate(onComplete)
            .Subscribe()
            .AddTo(this);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TamaSelectBox"))
        {
            //Debug.Log("BOX!");
            this.gameObject.tag = "CanSelect";
        }
    }
}
