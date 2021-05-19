using System;
using FPS;
using UnityEngine;

namespace SaveLoad
{
    [Serializable]
    public class PlayerData
    {
        public int health;
        public float[] position;

        public PlayerData(GameManager player)
        {
            health = GameManager.CurrentHealth;

            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
    }
}
