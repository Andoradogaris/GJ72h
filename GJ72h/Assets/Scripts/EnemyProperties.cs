using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyProperties : MonoBehaviour
    {
        [SerializeField]
        private AgentMover _movement;
        [SerializeField]
        private AgentAnimation _agentAnimation;


        private void Start()
        {
            _movement.OnSpeedChanged += _agentAnimation.SetSpeed;
            _movement.OnStartJump.AddListener(_agentAnimation.Jump);
            _agentAnimation.SetSpeed(0);
        }
    }
}
