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

        public virtual void AddSkillExp_f(float exp)
        {
            if (!isSkillMax)
            {
                skillExp_f += exp;
                switch (curSkillTier)
                {
                    case SkillTier.low:
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            expRequired = (skillLv_i + 1) * (skillLv_i + 1) * 100;
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.mid;
                                curSkillTier = SkillTier.mid;
                                skillLv_i = 1;
                                expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 1000) + 10000;
                            }
                        }
                        break;
                    case SkillTier.mid:
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 1000) + 10000;
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.high;
                                curSkillTier = SkillTier.high;
                                skillLv_i = 1;
                                expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 100000) + 110000;
                            }
                        }
                        break;
                    case SkillTier.high:
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 100000) + 110000;
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.max;
                                curSkillTier = SkillTier.max;
                                isSkillMax = true;
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
