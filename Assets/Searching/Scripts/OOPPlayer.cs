using System;
using System.Collections;
using System.Collections.Generic;
using Tree;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Searching
{
    public class OOPPlayer : Character
    {
        public int energy;
        public Inventory inventory;

        public void Start()
        {
            PrintInfo();
            GetRemainHealth();
            
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2.down);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UseFireStorm();
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                UseFireBall();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                UseWaterBall();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                UseLeafBlade();
            }
        }

        public void Attack(OOPEnemy _enemy)
        {
            _enemy.TakeDamage(AttackPoint);
        }

        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }

        public void UseFireStorm()
        {
            energy--;
            if (inventory.numberOfItem("FireStorm") > 0)
            {
                inventory.UseItem("FireStorm");
                OOPEnemy[] enemies = SortEnemiesByRemainningHealth2();
                int count = 3;
                if (count > enemies.Length)
                {
                    count = enemies.Length;
                }
                for (int i = 0; i < count; i++)
                {
                    enemies[i].TakeDamage(10);
                }
            }
            else
            {
                Debug.Log("No FireStorm in inventory");
            }
        }

        public void UseFireBall()
        {
            energy--;
            OOPEnemy[] enemies = SortEnemiesByRemainningHealth1();
            int count = 1;
            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int a = 0; a < count; a++)
            {
                if (enemies[a].element == Element.Plant)
                {enemies[a].TakeDamage(4);}
                else
                {
                 enemies[a].TakeDamage(2);   
                }
            }
        }
        public void UseLeafBlade()
        {
            energy--;
            OOPEnemy[] enemies = SortEnemiesByRemainningHealth1();
            int count = 1;
            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int a = 0; a < count; a++)
            {
                if (enemies[a].element == Element.Water)
                {enemies[a].TakeDamage(4);}
                else
                {
                    enemies[a].TakeDamage(2);   
                }
            }
        }
        public void UseWaterBall()
        {
            OOPEnemy[] enemies = SortEnemiesByRemainningHealth1();
            int count = 1;
            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int a = 0; a < count; a++)
            {
                if (enemies[a].element == Element.Fire)
                {enemies[a].TakeDamage(4);}
                else
                {
                    enemies[a].TakeDamage(2);   
                }
            }
        }

        public OOPEnemy[] SortEnemiesByRemainningHealth1()
        {
            // do selection sort of enemy's energy
            var enemies = mapGenerator.GetEnemies();
            for (int i = 0; i < enemies.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < enemies.Length; j++)
                {
                    if (enemies[j].health < enemies[minIndex].health)
                    {
                        minIndex = j;
                    }
                }
                var temp = enemies[i];
                enemies[i] = enemies[minIndex];
                enemies[minIndex] = temp;
            }
            return enemies;
        }

        public OOPEnemy[] SortEnemiesByRemainningHealth2()
        {
            var enemies = mapGenerator.GetEnemies();
            Array.Sort(enemies, (a, b) => a.health.CompareTo(b.health));
            return enemies;
        }

    }

}