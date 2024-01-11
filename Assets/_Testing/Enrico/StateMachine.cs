using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
	public class StateMachine
	{
		public Player player;
		public PlayerState currentState;
		public PlayerState previousState;

		public State_IDLE idle;
		public State_MOVE move;
		public State_THROW throww; //throw is a keyword, have to use throww
		public State_DODGE dodge;
		public State_PARRY parry;
		public State_STUN stun;
		public State_DEATH death;

		public StateMachine()
		{
			idle = new State_IDLE(player);
			move = new State_MOVE(player);
			throww = new State_THROW(player);
			dodge = new State_DODGE(player);
			parry = new State_PARRY(player);
			stun = new State_STUN(player);
			death = new State_DEATH(player);
		}


		public void ChangeState(PlayerState state)
		{
			currentState.Exit();
			previousState = currentState;
			currentState = state;
			currentState.Enter();
		}

		/*
		void PrintBestemmia(Player owner)
		{
			Debug.Log("Accipigna");
		}
		
		public void DiventaCristiano()
		{
			parry.OnExit -= PrintBestemmia;
		}
		*/
	}
}

