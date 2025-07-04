using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Yielders
{
	private static Dictionary<float, WaitForSeconds> _timeInterval = new Dictionary<float, WaitForSeconds>(100);

	private static WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();

	private static WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

	public static WaitForEndOfFrame EndOfFrame => _endOfFrame;

	public static WaitForFixedUpdate FixedUpdate => _fixedUpdate;

	public static WaitForSeconds Get(float seconds)
	{
		if (!_timeInterval.ContainsKey(seconds))
		{
			_timeInterval.Add(seconds, new WaitForSeconds(seconds));
		}
		return _timeInterval[seconds];
	}

	public static IEnumerator DelayEndOfFrame(int delayFrames)
	{
		for (int i = 0; i < delayFrames; i++)
		{
			yield return EndOfFrame;
		}
	}

	public static IEnumerator DelayFrames(int delayFrames)
	{
		for (int i = 0; i < delayFrames; i++)
		{
			yield return null;
		}
	}
}
