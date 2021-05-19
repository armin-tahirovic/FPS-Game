using System;
using System.Collections;
using System.Timers;
using SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FPS
{
    public class GameManager : MonoBehaviour
    {
        public int startHealth = 100;
        public static int CurrentHealth;
        public HealthBar healthBar;
        
        private bool dead = false;

        private float timeStart;
        public Text timerCount;
        // Start is called before the first frame update
        void Start()
        {
            CurrentHealth = startHealth;
            healthBar.SetMaxHealth(startHealth);
            
            
            timeStart += Time.deltaTime;
            timerCount.text = timeStart.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if (dead)
                return;
        
            if (CurrentHealth <= 0)
            {
                EndGame();
            }
        }

        public void SavePlayer()
        {
            SaveSystem.SavePlayer(this);
        }

        public void LoadPlayer()
        {
            var data = SaveSystem.LoadPlayer();

            CurrentHealth = data.health;
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
        }

        void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            healthBar.SetHealth(CurrentHealth);
        }
        
        void EndGame()
        {
            dead = true;
            Debug.Log("Game over");
            SceneManager.LoadScene(1);
        }

        void KilledEnemy()
        {
            dead = true;
            Debug.Log("Dead enemy");
            Destroy(GameObject.FindGameObjectWithTag("Dummie"));
        }
    }
}
