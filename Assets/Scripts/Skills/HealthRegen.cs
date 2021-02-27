using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class HealthRegen : Skill
    {
        [SerializeField] float healthRegenTimerAmount_f;
        [SerializeField] float healthRegenTimer_f;
        [SerializeField] float baseRegenAmount;
        [SerializeField] float healthRegenAmount_f;
        [SerializeField] bool isRegen;
        // Start is called before the first frame update
        void Start()
        {
            SetSkill();
            
        }

        private void Update()
        {
            if (isRegen)
            {
                healthRegenTimer_f += Time.deltaTime;
            }
        }

        public override void AddSkillExp_f(float exp)
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
                            baseRegenAmount += 5;
                            expRequired = (skillLv_i + 1) * (skillLv_i + 1) * 100;
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.mid;
                                curSkillTier = SkillTier.mid;
                                skillLv_i = 1;
                                expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 1000) + 10000;
                                healthRegenTimerAmount_f = 2.5f;
                            }
                        }
                        break;
                    case SkillTier.mid:
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            baseRegenAmount += 100;
                            expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 1000) + 10000;
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.high;
                                curSkillTier = SkillTier.high;
                                skillLv_i = 1;
                                expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 100000) + 110000;
                                healthRegenTimerAmount_f = 1.0f;
                            }
                        }
                        break;
                    case SkillTier.high:
                        while (skillExp_f >= expRequired)
                        {
                            skillLv_i++;
                            baseRegenAmount += 1000;
                            expRequired = ((skillLv_i + 1) * (skillLv_i + 1) * 100000) + 110000;
                            if (skillLv_i >= 10)
                            {
                                skillTier = SkillTier.max;
                                curSkillTier = SkillTier.max;
                                isSkillMax = true;
                                baseRegenAmount = 5000;
                                healthRegenTimerAmount_f = 0.1f;
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


        public float Regen_f()
        {
            if (!isRegen && isSkillActive && skillLv_i > 0)
            {
                isRegen = true;
            }
            
            if(isRegen)
            {
                if (healthRegenTimer_f >= healthRegenTimerAmount_f)
                {
                    healthRegenAmount_f = ( baseRegenAmount * ( healthRegenTimerAmount_f / 60) );
                    AddSkillExp_f(healthRegenAmount_f);
                    healthRegenTimer_f = 0;
                    return healthRegenAmount_f;
                }

            }
            return 0;
        }

        public void StopRegen()
        {
            isRegen = false;
            healthRegenTimer_f = 0;
        }

        public bool IsRegen() { return isRegen; }
    }












}