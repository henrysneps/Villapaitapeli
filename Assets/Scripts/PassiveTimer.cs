using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// A timer with no callbacks to report its state. Runs on <see cref="Time"/>.
/// </summary>
public class PassiveTimer
{
	private float targetTime = float.MaxValue;

	public void SetTimerFor(float durationInSeconds)
	{
		targetTime = Time.time + durationInSeconds;
	}

	public bool isDone()
	{
		if (Time.time >= targetTime) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void ResetTimer()
	{
		targetTime = float.MaxValue;
	}
}
