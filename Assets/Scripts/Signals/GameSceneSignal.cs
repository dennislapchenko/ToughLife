using System;
using Zenject;
using UnityEngine;

namespace ToughLife
{
	public static class GameStateSignals
	{
		public class Bootstrap : Signal<Bootstrap>
		{
		}
		public class Main : Signal<Main>
		{
		}		
		public class Session : Signal<Session>
		{
		}
		public class Gameover : Signal<Gameover>
		{
			
		}
	}
}

