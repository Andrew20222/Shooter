using Enemies;
using Guns.Barrels;
using Mechanics.Aiming;
using Mechanics.Healths;
using Mechanics.Shooting;
using Runners;
using Units;
using UnityEngine;
using Inputs;
using Stats;

namespace Bootstraps
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Player Components")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Health playerHealth;
        [SerializeField] private CharacterController characterController;
        
        [Space]
        [Header("Enemy Components")]
        
        [SerializeField] private EnemyDetected enemyDetected;
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private Health enemyHealth;
        
        [Space]
        [Header("Input Component")]
        
        [SerializeField] private InputProvider inputProvider;
        
        [Space]
        [Header("Shooting Component")]
        
        [SerializeField] private Shooting shooting;
        
        [Space]
        [Header("Scope Component")]
        
        [SerializeField] private Scope scope;
        
        [Space]
        [Header("GunBarrel Component")]
        
        [SerializeField] private GunBarrel gunBarrel;
        
        [Space]
        [Header("Stats Components")]
        
        [SerializeField] private StatsController statsController;
        [SerializeField] private StatsView statsView;
        
        [Space]
        [Header("EndGameView Component")]
        
        [SerializeField] private EndGameView endGameView;

        private void Awake()
        {
            Cursor.visible = false;

            playerController.Initialize(characterController);
            playerHealth.Initialize();
            
            enemyDetected.Initialize(playerController.transform);
            enemyAttack.Initialize(playerHealth,enemyDetected);
            enemyController.Initialize(playerController.transform);
            
            shooting.Initialize();
            scope.Initialize(Camera.main);
            gunBarrel.Initialize(scope);
            
            inputProvider.Initialize(playerController,shooting,scope);

            var statsData = new StatsData();
            endGameView.Initialize(playerHealth, enemyHealth);
            statsController.Initialize(statsView, statsData,endGameView);
        }
    }
}