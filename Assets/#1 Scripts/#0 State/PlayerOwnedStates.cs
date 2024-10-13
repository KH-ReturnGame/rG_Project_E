using UnityEngine;

namespace PlayerOwnedStates
{
    public class IsMove : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class CanDash : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
           
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsDashing : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class CanDefence : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsDefencing : State<Player>
    {
        public override void Enter(Player entity)
        {

        }
        public override void Execute(Player entity)
        {

        }
        public override void Exit(Player entity)
        {

        }
    }
    public class IsAttacking : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }

    public class IsBuff : State<Player>
    {
        public override void Enter(Player entity)
        {

        }
        public override void Execute(Player entity)
        {

        }
        public override void Exit(Player entity)
        {

        }
    }

    public class IsDebuff : State<Player>
    {
        public override void Enter(Player entity)
        {

        }
        public override void Execute(Player entity)
        {

        }
        public override void Exit(Player entity)
        {

        }
    }
    
    public class IsDie : State<Player>
    {
        public override void Enter(Player entity)
        {
            Debug.Log("사망");
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
}

