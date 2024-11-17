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
        public int CD1 = 0;
        public int CD2 = 0;
        public int CD3 = 0;
        public int CD4 = 0;
        public int CD5 = 0;
        public int CD6 = 0;
        public int energy = 30;
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
                energy += 2;
                AllCDMinus();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2.down);
                energy += 2;
                AllCDMinus();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2.left);
                energy += 2;
                AllCDMinus();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2.right);
                energy += 2;
                AllCDMinus();
            }
            if (Input.GetKeyDown(KeyCode.J)&& CD1 == 0)
            {
                UseFireBall();
                CD1 = 3;
                AllCDMinusExcept(CD1);
            }
            if (Input.GetKeyDown(KeyCode.K)&& CD2 == 0)
            {
                UseWaterBall();
                CD2 = 3;
                AllCDMinusExcept(CD2);
            }

            if (Input.GetKeyDown(KeyCode.L)&& CD3 == 0)
            {
                UseLeafBlade();
                CD3 = 3;
                AllCDMinusExcept(CD3);
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

        /*public void UseFireStorm()
        {
            energy -=5;
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
        }*/

        public void UseFireBall()
        {
            energy-= 5;
            OOPEnemy[] enemies = SortEnemiesByRemainningHealth1();
            int count = 1;
            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int a = 0; a < count; a++)
            {
                enemies[a].TakeDamage(ElementDamage(10,Element.Fire,enemies[a].element));
            }
        }
        public void UseLeafBlade()
        {
            energy-= 5;
            OOPEnemy[] enemies = SortEnemiesByRemainningHealth1();
            int count = 1;
            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int a = 0; a < count; a++)
            {
                enemies[a].TakeDamage(ElementDamage(10,Element.Plant,enemies[a].element));
            }
        }
        public void UseWaterBall()
        {
            energy -= 5;
            OOPEnemy[] enemies = SortEnemiesByRemainningHealth1();
            int count = 1;
            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int a = 0; a < count; a++)
            {
                enemies[a].TakeDamage(ElementDamage(10,Element.Water,enemies[a].element));
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

        public void AllCDMinus()
        {
            CD1--;
            CD2--;
            CD3--;
            CD4--;
            CD5--;
            CD6--;
            if (CD1 <= 0)
            {
                CD1 = 0;
            }

            if (CD2 <= 0)
            {
                CD2 = 0;
            }

            if (CD3 <= 0)
            {
                CD3 = 0;
            }

            if (CD4 <= 0)
            {
                CD4 = 0;
            }

            if (CD5 <= 0)
            {
                CD5 = 0;
            }

            if (CD6 <= 0)
            {
                CD6 = 0;
            }
        }
        public void AllCDMinusExcept(int CDnotremove)
        {
            if (CD1.ToString() == CDnotremove.ToString())
            {
                CD1++;
            }
            if (CD2.ToString() == CDnotremove.ToString())
            {
                CD2++;
            }
            if (CD3.ToString() == CDnotremove.ToString())
            {
                CD3++;
            }
            if (CD4.ToString() == CDnotremove.ToString())
            {
                CD4++;
            }
            if (CD5.ToString() == CDnotremove.ToString())
            {
                CD5++;
            }
            if (CD6.ToString() == CDnotremove.ToString())
            {
                CD6++;
            }
            CD1--;
            CD2--;
            CD3--;
            CD4--;
            CD5--;
            CD6--;
            if (CD1 <= 0)
            {
                CD1 = 0;
            }

            if (CD2 <= 0)
            {
                CD2 = 0;
            }

            if (CD3 <= 0)
            {
                CD3 = 0;
            }

            if (CD4 <= 0)
            {
                CD4 = 0;
            }

            if (CD5 <= 0)
            {
                CD5 = 0;
            }

            if (CD6 <= 0)
            {
                CD6 = 0;
            }
        }

        public int ElementDamage(int Damage ,Element Attack, Element Defense)
        {
            if ((Attack == Element.Fire && Defense == Element.Water) ||
                (Attack == Element.Water && Defense == Element.Plant) ||
                (Attack == Element.Plant && Defense == Element.Fire))
            {
                Damage = Damage / 2;
            }
            else if ((Attack == Element.Fire && Defense == Element.Plant) ||
                (Attack == Element.Water && Defense == Element.Fire) ||
                (Attack == Element.Plant && Defense == Element.Water))
            {
                Damage = Damage * 2;
            }
            else
            {
                
            }

            return Damage;
        }
    }

}