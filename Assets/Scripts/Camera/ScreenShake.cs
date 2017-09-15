using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenShake : MonoBehaviour
{
	public static ScreenShake Singleton;

	void Awake ()
	{
		if (ScreenShake.Singleton == null) {
			ScreenShake.Singleton = this;
		} else {
			Destroy (gameObject);
		}
	}

	public void ShakeHit (float side)
	{
		side = Mathf.Clamp (side, -2f, 2f);
		transform.DOKill (true);

		transform.DOPunchRotation (Vector3.forward * side * 0.4f, .3f, 1, 1);
		transform.DOPunchPosition (Vector3.one * 0.4f, .3f, 1, 0.5f);
	}

    public void DoubleRoastHit(float side)
    {
        side = Mathf.Clamp(side, -1f, 1f);
        transform.DOKill(true);

        transform.DOPunchRotation(Vector3.forward * side * 0.2f, .3f, 1, 1);
        transform.DOPunchPosition(Vector3.one * 0.2f, .3f, 1, 0.5f);
    }


    public void ProtectHit(float side)
    {
        side = Mathf.Clamp(side, -2f, 2f);
        transform.DOKill(true);

        transform.DOPunchRotation(Vector3.forward * side * 0.4f, .15f, 1, .95f);
        transform.DOPunchPosition(Vector3.one * 0.4f, .25f, 1, .4f);
    }


    public void Win (float side)
	{
		transform.DOShakeRotation (2f, 2f, 15, 90);
		transform.DOShakePosition (2f, 2f, 15, 90);
	}

    public void Destroy()
    {
        transform.DOShakeRotation(1f, .9f, 22, 90);
        transform.DOShakePosition(1f, .9f, 22, 90);
    }

    public void Respawn()
    {
        transform.DOShakeRotation(.5f, 1.4f, 17, 180);
        transform.DOShakePosition(.5f, 1.4f, 17, 180);
    }

    public void StartPropulsion (float side)
	{
		side = Mathf.Clamp (side, -2f, 2f);
		transform.DOKill (true);
		transform.DORotate (transform.forward * side * 1.5f, .35f).SetEase (Ease.InOutExpo);
	}

    public void StartThumbsUp(float side)
    {
        side = Mathf.Clamp(side, -20f, 20f);
        transform.DOKill(true);
        transform.DORotate(transform.forward * side * 2f, .15f).SetEase(Ease.InOutExpo);

        ScreenShake.Singleton.GetComponentInChildren<Camera>().DOOrthoSize(3.5f, .8f);
        DOVirtual.DelayedCall(2f, () =>
        {
            ScreenShake.Singleton.GetComponentInChildren<Camera>().DOOrthoSize(4f, 1f);
            transform.DOKill(true);
            transform.DORotate(Vector3.zero, .5f);
            /*DOVirtual.DelayedCall(7f, () =>
            {
                transform.DOKill(true);
                transform.DORotate(Vector3.zero, .5f);
            });*/
        });
    }

    public void EndThumbsUp()
    {
        transform.DOKill(true);
        transform.DORotate(Vector3.zero, 1f).SetEase(Ease.InOutExpo);
    }

    public void EndPropulsion ()
	{
		transform.DOKill (true);
		transform.DORotate (Vector3.zero, 1f).SetEase (Ease.InOutExpo);
	}

    public void MenuShake()
    {
        transform.DOKill(true);

        transform.DOPunchRotation(Vector3.one * 0.4f, .3f, 1, 1);
        transform.DOPunchPosition(Vector3.one * 0.4f, .3f, 1, 0.5f);
    }
}
