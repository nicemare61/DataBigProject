using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tree
{

    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;
        public SkillTree fireSkillTree;
        public SkillTree waterSkillTree;
        public SkillTree plantSkillTree;

        public Skill attack;
        //Skill fireStorm;
        public Skill fireBall;
        //Skill fireBlast;
       // Skill fireWave;
        //Skill fireExplosion;
        public Skill waterBall;
        public Skill leafBlade;
        public Skill fireWall;
        public Skill waterCannon;
        public Skill seedBomb;

        public void Start()
        {
            #region Depicting the skill tree
            // build skill tree
            // └── Attack
            //     └── FireStorm
            //         ├── FireBlast
            //         └── FireBall
            //             └── FireWave
            //                 └── FireExplosion
            #endregion

            attack = new Skill("Attack");
            attack.isAvailable = true;
            
            this.attackSkillTree = new SkillTree(attack);

            //fireStorm = new Skill("FireStorm");
            fireBall = new Skill("FireBall");
            fireBall.isAvailable = true;
            
            
            fireWall = new Skill("FireWall");
            fireWall.isAvailable = false;
            this.fireSkillTree = new SkillTree(fireBall);
            fireBall.nextSkills.Add(fireWall);
            
            waterBall = new Skill("WaterBall");
            waterBall.isAvailable = true;
            
            waterCannon = new Skill("WaterCannon");
            waterCannon.isAvailable = false;
            this.waterSkillTree = new SkillTree(waterBall);
            waterBall.nextSkills.Add(waterCannon);
            
            leafBlade = new Skill("LeafBlade");
            leafBlade.isAvailable = true;
            
            seedBomb = new Skill("SeedBomb");
            seedBomb.isAvailable = false;
            this.plantSkillTree = new SkillTree(leafBlade);
            leafBlade.nextSkills.Add(seedBomb);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                attackSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                // attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
                
                fireSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                // attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
                waterSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                // attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
                plantSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                Debug.Log("====================================");
            }
        }

        public void UnlockFireBall()
        {
            fireBall.Unlock();
        }

        public void UnlockWaterBall()
        {
            waterBall.Unlock();
        }

        public void UnlockLeafBlade()
        {
            leafBlade.Unlock();
        }

        public void UnlockFireWall()
        {
            fireWall.Unlock();
        }

        public void UnlockWaterCannon()
        {
            waterCannon.Unlock();
        }

        public void UnlockSeedBomb()
        {
            seedBomb.Unlock();
        }

        
    }

}