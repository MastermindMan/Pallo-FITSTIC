using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LorenzoCastelli {

public class CPU_Attacking : CPUState
{
        public int maxAttackTime = 10;
        public int currentAttackTime;

        public CPU_Attacking(CPUBehaviour owner) : base(owner, NEWPLAYERSTATES.ATTACKING) {
        }



        public override void Exit() {
            base.Exit();
            owner.OnAttackFinished -= EndAttack;
        }

        public override void Init() {

            base.Init();
            currentAttackTime = 0;
            owner.OnAttackFinished += EndAttack;
            owner.transform.LookAt(owner.stateMachine.CurrentTarget.transform.position);
        }

        public override void Update() {
            currentAttackTime += (int)Time.deltaTime;
            if (currentAttackTime > 10) {
                owner.stateMachine.DecideAction();
            }
        }
        private void EndAttack() {
                if ((!GameLogic.instance.IsPlayerClose(owner.GetComponent<PlayerData>(), owner.stateMachine.CurrentTarget.GetComponent<PlayerData>()) || (!owner.stateMachine.CurrentTarget.GetComponent<PlayerData>().IsHoldingBall()))){
                //Se � ancora vicino al nemico con la palla fai il coin flip
                owner.stateMachine.ChangeState(NEWPLAYERSTATES.IDLE);
            }
          
            }
           // owner.stateMachine.ChangeState(NEWPLAYERSTATES.Recovering);
        }
    }