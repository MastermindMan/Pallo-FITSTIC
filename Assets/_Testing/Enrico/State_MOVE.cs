using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
	public class State_MOVE : PlayerState
	{
		public Vector3 moveVector;

		public State_MOVE(Player owner) : base(owner)
		{

		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Exit()
		{
			base.Exit();
		}

		public override void Update()
		{
			base.Update();

			HandleMovement();
			HandleRotation();
		}

		private void HandleMovement()
		{
			player.controller.Move(player.movementInput * Time.deltaTime * player.playerSpeed);
		}

		private void HandleRotation()
		{
			/*if (player.heldPallo && player.rotationInput != Vector3.zero)
			{
				Vector3 rotationVector = player.transform.position + player.rotationInput;
				player.transform.LookAt(rotationVector, Vector3.up);
			}
			else */
			if (player.movementInput != Vector3.zero)
			{
				moveVector = player.transform.position + player.movementInput;
				player.transform.LookAt(moveVector, Vector3.up);
			}
		}
	}
}

