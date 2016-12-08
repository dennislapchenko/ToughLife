using System;
using UnityEngine;
using System.Collections;

namespace ToughLife
{
	public abstract class SleepBehaviour : MonoBehaviour
	{
		protected abstract IEnumerator Coroutine();
	}
}

