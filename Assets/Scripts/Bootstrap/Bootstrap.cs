using Bar;
using DefaultNamespace;
using Enemies;
using Mechanics.Shooting;
using Units;
using Timers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private TimeBar timeBar;
        [SerializeField] private InputProvider inputProvider;
        [SerializeField] private Health playerHealth;
        [SerializeField] private Enemy enemy;
        [SerializeField] private Shooting shooting;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Aiming aiming;
        
        private void Awake()
        {
            playerController.Initialize(characterController);
            playerHealth.Initialize();
            aiming.Initialize(Camera.main);
            inputProvider.Initialize(playerController,shooting,aiming);
            enemy.Initialize(playerHealth);
            
            var timer = new Timer(this);
            
            timeBar.Initialize(timer);
            timer.Set(20f);
            timer.StartCoutingTime();
            
            
        }
    }
}