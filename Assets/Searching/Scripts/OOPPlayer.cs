using System;
using System.Collections;
using System.Collections.Generic;
using Tree;
using Unity.VisualScripting;
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
        public int upGradePoint = 5;
        public Inventory inventory;
        public bool isRight = true; 
       
       [SerializeField]
       GameObject fireballPrefab;
        [SerializeField]
        SkillBook skillBook;
        [SerializeField]
        SpriteRenderer spriteRenderer;

        [SerializeField] private GameObject windowGameObject;
        [SerializeField] bool windowActive = false;

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
                AllCDMinus();
                EnergyRegen();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2.down);
                AllCDMinus();
                EnergyRegen();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2.left);
                AllCDMinus();
                spriteRenderer.flipX = true;
                isRight = false;
                EnergyRegen();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2.right);
                AllCDMinus();
                spriteRenderer.flipX = false;
                EnergyRegen();
                isRight = true;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (CheckCondition(5,energy,cd1,skillBook.fireBall))
                {
                    UseFireBall();
                    cd1 = 3;
                    AllCDMinusExcept(cd1);
                    Debug.Log(energy);
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (CheckCondition(5, energy, cd2, skillBook.waterBall))
                {
                    UseWaterBall();
                    cd2 = 3;
                    AllCDMinusExcept(cd2);
                    Debug.Log(energy);
                }
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (CheckCondition(5, energy, cd3, skillBook.leafBlade))
                {
                    UseLeafBlade();
                    cd3 = 3;
                    AllCDMinusExcept(cd3);
                    Debug.Log(energy);
                }
            }

            if (Input.GetKey(KeyCode.P))
            {
                windowGameObject.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.P))
            {
                windowGameObject.SetActive(false);
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
            Instantiate(fireballPrefab, this.transform.position, Quaternion.identity);
           /* OOPEnemy[] enemies = SortEnemiesByRemainningHealth1();
            int count = 1;
            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int a = 0; a < count; a++)
            {
                enemies[a].TakeDamage(ElementDamage(10,Element.Fire,enemies[a].element));
            }*/
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
            CDWontlessThan0();
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
            AllCDMinus();
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

        public bool DebugUpSkill(Skill skill ,int pointsToUp, int points)
        {
            bool CanUpgrade;
            if (pointsToUp >= points)
            {
                points -= pointsToUp;
                Debug.Log(skill.name + " is Unlocked");
                CanUpgrade = true;
            }
            else
            {
                Debug.Log(skill.name + " can't unlocked you don't have enough points");
                CanUpgrade = false;
            }
            return CanUpgrade;
        }

        public void LearnSkill(Skill skill)
        {
            skill.isAvailable = true;
            skill.isUnlocked = true;
            Debug.Log($"{skill.name} is unlocked");
        }

        public bool CheckCondition(int energyUse ,int energyTotal,int cdTurn,Skill skill)
        {
            bool result = false;
            if (cdTurn == 0 && energyUse <= energyTotal && skill.isAvailable && skill.isUnlocked)
            {
                result = true;
            }
            else if(!skill.isAvailable || !skill.isUnlocked)
            {
                Debug.Log($"can't use {skill.name} cause your skill is not unlocked or unavailable");
            }
            else if(energyUse > energyTotal)
            {
                Debug.Log($"can't use {skill.name} cause your energy");
            }
            else if(cdTurn > 0)
            {
                Debug.Log($"can't use {skill.name} cause your cd skill");
            }
            
            return result;

        }

        public void CDWontlessThan0()
        {
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

        public void FireBall()
        {
            if (DebugUpSkill(skillBook.fireBall, 5, upGradePoint))
            {
                LearnSkill(skillBook.fireBall);
            }
        }

        public void WaterBall()
        {
            if (DebugUpSkill(skillBook.waterBall, 5, upGradePoint))
            {
                LearnSkill(skillBook.waterBall);
            }
        }

        public void LeafBlade()
        {
            if (DebugUpSkill(skillBook.leafBlade, 5, upGradePoint))
            {
                LearnSkill(skillBook.leafBlade);
            }
        }

        public void FireWall()
        {
            if (DebugUpSkill(skillBook.fireWall, 10, upGradePoint))
            {
                LearnSkill(skillBook.fireWall);
            }
        }

        public void WaterCannon()
        {
            if (DebugUpSkill(skillBook.waterCannon, 10, upGradePoint))
            {
                LearnSkill(skillBook.waterCannon);
            }
        }

        public void SeedBomb()
        {
            if (DebugUpSkill(skillBook.seedBomb, 10, upGradePoint))
            {
                LearnSkill(skillBook.seedBomb);
            }
        }

        public void EnergyRegen()
        {
            energy += 2;
            if (energy > 30)
            {
                energy = 30;
            }
            Debug.Log($"energy : {energy}");
        }

        public int FaceSkill(SpriteRenderer spriteRenderer)
        {
            int result = 0;
            if (spriteRenderer.flipX)
            {
                result = 1;
            }
            else if (!spriteRenderer.flipX)
            {
                result = -1;
            }
            return result;
        }
        
    }
}