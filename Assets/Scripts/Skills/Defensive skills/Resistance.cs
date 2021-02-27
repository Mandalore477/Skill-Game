using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class Resistance : Skill
    {
        [SerializeField] float resistanceModifier_f = 0;
        [SerializeField] float weaknessModifier_f = Mathf.Clamp(1, 0, 10);
        protected void SetResistance()
        {
            if (weaknessModifier_f == 0)
            {
                curSkillTier = SkillTier.max;
                isSkillMax = true;
            }
            SetSkill();
        }

        public override void AddSkillExp_f(float exp)
        {
            base.AddSkillExp_f(exp);
        }

        public float Mitigation_f(float damage)
        {
            if (!isSkillMax)
            {


                float actualDamage;

                float curDamage = damage * weaknessModifier_f - resistanceModifier_f;

                switch (skillTier)
                {
                    case SkillTier.low:
                        if (curDamage <= 1000)
                            actualDamage = Mathf.Max(curDamage * ((10 - skillLv_i) / 10), 0);
                        else
                        {
                            actualDamage = Mathf.Max(1000 * ((10 - skillLv_i) / 10), 0);
                            actualDamage = curDamage - actualDamage;
                        }
                        break;
                    case SkillTier.mid:
                        if (curDamage <= 1000)
                        {
                            actualDamage = 0;
                        }
                        else if (curDamage <= 10000)
                        {
                            actualDamage = Mathf.Max(curDamage * ((10 - skillLv_i) / 10), 0);
                        }
                        else
                        {
                            actualDamage = Mathf.Max(10000 * ((10 - skillLv_i) / 10), 0);
                            actualDamage = curDamage - actualDamage;
                        }
                        break;
                    case SkillTier.high:
                        if (curDamage <= 10000)
                        {
                            actualDamage = 0;
                        }
                        else
                        {
                            actualDamage = Mathf.Max(curDamage * ((10 - skillLv_i) / 10), 0);
                        }
                        break;
                    case SkillTier.max:
                        actualDamage = 0;
                        break;
                    default:
                        actualDamage = curDamage;
                        break;
                }
                AddSkillExp_f(damage / weaknessModifier_f);
                return actualDamage;
            }
            else
            {
                return 0;
            }

        }
    }





}
