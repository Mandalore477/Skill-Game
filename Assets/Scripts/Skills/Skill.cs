using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public enum SkillTier
    {
        low,
        mid,
        high,
        max
    }

    public class Skill : MonoBehaviour
    {
        [SerializeField] protected string skillName_s = " ";
        [SerializeField] protected string skillNameLow_s = " ";
        [SerializeField] protected string skillNameMid_s = " ";
        [SerializeField] protected string skillNameHigh_s = " ";
        [SerializeField] protected string skillNameMax_s = " ";
        [SerializeField] protected int skillLv_i = 0;
        protected int lastSkillLv_i = 0;
        protected int nextSkillLv_i = 0;
        [SerializeField] protected float skillExp_f = 0;
        [SerializeField] protected float expRequired = 100;
        [SerializeField] protected bool isSkillMax = false;
        [SerializeField] protected bool isSkillActive = true;
        [SerializeField] protected SkillTier skillTier = SkillTier.low;
        [SerializeField] protected SkillTier curSkillTier = SkillTier.low;

        protected void SetSkill()
        {
            curSkillTier = skillTier;
            switch (curSkillTier)
            {
                case SkillTier.low:
                    expRequired = (skillLv_i + 1) * (skillLv_i + 1) * 100;
                    break;
                case SkillTier.mid:
                    expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 1000) + 10000;
                    break;
                case SkillTier.high:
                    expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 100000) + 110000;
                    break;
                default:
                    expRequired = 0;
                    break;
            }
        }

        protected void SetSkillName(string newSkillName)
        {
            skillName_s = newSkillName;
        }

        public int GetCurSkillLv_i()
        {
            return skillLv_i;
        }

        public int GetNextSkillLv_i()
        {
            return nextSkillLv_i;
        }

        public int GetLastSkillLv_i()
        {
            return lastSkillLv_i;
        }

        protected void OnSkillTierUp(SkillTier newSkillTier)
        {
            // sets the skill name according to new tier
            switch (newSkillTier)
            {
                case SkillTier.low:
                    SetSkillName(skillNameLow_s);
                        break;
                case SkillTier.mid:
                    SetSkillName(skillNameMid_s);
                    break;
                case SkillTier.high:
                    SetSkillName(skillNameHigh_s);
                    break;
                case SkillTier.max:
                    SetSkillName(skillNameMax_s);
                    break;
                default:
                    SetSkillName("Name not found");
                    break;
            }
        }

        public virtual void AddSkillExp_f(float exp)
        {
            // check if skill is max else no need to add exp.
            if (!isSkillMax)
            {
                skillExp_f += exp;
                // checks skill tier to add according to required exp level
                switch (curSkillTier)
                {
                    case SkillTier.low:
                        // while loop in case exp exceeds single level up.
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            expRequired = (skillLv_i + 1) * (skillLv_i + 1) * 100;
                            // allows to level up to next skill tier
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.mid;
                                curSkillTier = SkillTier.mid;
                                skillLv_i = 1;
                                expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 1000) + 10000;
                                // to be used to change skill names for each specific skills on upgrade.
                                OnSkillTierUp(SkillTier.mid);
                            }
                        }
                        break;
                    case SkillTier.mid:
                        // while loop in case exp exceeds single level up.
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 1000) + 10000;
                            // allows to level up to next skill tier
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.high;
                                curSkillTier = SkillTier.high;
                                skillLv_i = 1;
                                expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 100000) + 110000;
                                // to be used to change skill names for each specific skills on upgrade.
                                OnSkillTierUp(SkillTier.high);
                            }
                        }
                        break;
                    case SkillTier.high:
                        // while loop in case exp exceeds single level up.
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 100000) + 110000;
                            // allows to level up to next skill tier
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.max;
                                curSkillTier = SkillTier.max;
                                isSkillMax = true;
                                // to be used to change skill names for each specific skills on upgrade.
                                OnSkillTierUp(SkillTier.max);
                            }
                        }
                        break;
                    case SkillTier.max:

                        break;
                    default:
                        break;
                }
            }
        }
    }




}
