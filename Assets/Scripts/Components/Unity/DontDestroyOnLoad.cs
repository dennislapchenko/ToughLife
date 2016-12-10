using System;
using UnityEngine;

namespace ToughLife
{
	public class DontDestroyOnLoad : MonoBehaviour
	{
		void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}

