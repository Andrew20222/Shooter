using Bar;
using Enemies;
using Units;
using Timers;
using UnityEngine;

namespace Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private TimeBar timeBar;
        [SerializeField] private InputProvider inputProvider;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private Enemy enemy;
        
        private void Awake()
        {
            playerController.Initialize();
            inputProvider.Initialize(playerController);
            enemy.Initialize(playerHealth);
            
            var timer = new Timer(this);
            
            timeBar.Initialize(timer);
            timer.Set(20f);
            timer.StartCoutingTime();
            
            
        }
    }
}