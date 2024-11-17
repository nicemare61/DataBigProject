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
        public int cd1 = 0;
        public int cd2 = 0;
        public int cd3 = 0;
        public int cd4 = 0;
        public int cd5 = 0;
        public int cd6 = 0;
        public int energy = 30;
        public int point = 5;
        public Inventory inventory;

        public void Start()
        {
            PrintInfo();
            GetRemainHealth();
            
        }

        public void Update()
        {
            SkillBook skillBook = new SkillBook();
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
            if (Input.GetKeyDown(KeyCode.J)&& cd1 == 0)
            {
                UseFireBall();
                cd1 = 3;
                AllCDMinusExcept(cd1);
            }
            if (Input.GetKeyDown(KeyCode.K)&& cd2 == 0)
            {
                UseWaterBall();
                cd2 = 3;
                AllCDMinusExcept(cd2);
            }

            if (Input.GetKeyDown(KeyCode.L)&& cd3 == 0)
            {
                UseLeafBlade();
                cd3 = 3;
                AllCDMinusExcept(cd3);
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
            cd1--;
            cd2--;
            cd3--;
            cd4--;
            cd5--;
            cd6--;
            if (cd1 <= 0)
            {
                cd1 = 0;
            }

            if (cd2 <= 0)
            {
                cd2 = 0;
            }

            if (cd3 <= 0)
            {
                cd3 = 0;
            }

            if (cd4 <= 0)
            {
                cd4 = 0;
            }

            if (cd5 <= 0)
            {
                cd5 = 0;
            }

            if (cd6 <= 0)
            {
                cd6 = 0;
            }
        }
        public void AllCDMinusExcept(int CDnotremove)
        {
            if (cd1.ToString() == CDnotremove.ToString())
            {
                cd1++;
            }
            else if (cd2.ToString() == CDnotremove.ToString())
            {
                cd2++;
            }
            else if (cd3.ToString() == CDnotremove.ToString())
            {
                cd3++;
            }
            else if (cd4.ToString() == CDnotremove.ToString())
            {
                cd4++;
            }
            else if (cd5.ToString() == CDnotremove.ToString())
            {
                cd5++;
            }
            else if (cd6.ToString() == CDnotremove.ToString())
            {
                cd6++;
            }
            cd1--;
            cd2--;
            cd3--;
            cd4--;
            cd5--;
            cd6--;
            if (cd1 <= 0)
            {
                cd1 = 0;
            }

            if (cd2 <= 0)
            {
                cd2 = 0;
            }

            if (cd3 <= 0)
            {
                cd3 = 0;
            }

            if (cd4 <= 0)
            {
                cd4 = 0;
            }

            if (cd5 <= 0)
            {
                cd5 = 0;
            }

            if (cd6 <= 0)
            {
                cd6 = 0;
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
            
            return Damage;
        }
    }

}