using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tree
{

    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;

        Skill attack;
        //Skill fireStorm;
        Skill fireBall;
        //Skill fireBlast;
       // Skill fireWave;
        //Skill fireExplosion;
        private Skill waterBall;
        private Skill leafBlade;

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

            //fireStorm = new Skill("FireStorm");
            fireBall = new Skill("FireBall");
            //fireBlast = new Skill("FireBlast");
            //fireWave = new Skill("FireWave");
            //fireExplosion = new Skill("FireExplosion");

            attack.nextSkills.Add(fireBall);
            attack.nextSkills.Add(leafBlade);
            attack.nextSkills.Add(waterBall);
            //fireStorm.nextSkills.Add(fireBlast);
            //fireStorm.nextSkills.Add(fireBall);
            //fireBall.nextSkills.Add(fireWave);
            //fireWave.nextSkills.Add(fireExplosion);


            this.attackSkillTree = new SkillTree(attack);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                attackSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                // attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                attack.Unlock();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                fireBall.Unlock();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                waterBall.Unlock();
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                leafBlade.Unlock();
            }
        }
    }

}