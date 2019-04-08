
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Partiality.Modloader;
using UnityEngine;


public class MyMod : PartialityMod
{
    public MyMod()
    {
        this.ModID = "Counter Cooldown Reduction";
        this.Version = "0100";
        this.author = "Ashnal";
    }

    public static MyScript script;

    public override void OnEnable()
    {
        base.OnEnable();
        MyScript.mod = this;
        GameObject go = new GameObject();
        script = go.AddComponent<MyScript>();
        script.Initialize();
    }
}

public class MyScript : MonoBehaviour
{

    public static MyMod mod;
    public static XmlSerializer xmlSerializer;
    public static FileStream fileStream;
    public static StreamWriter streamWriter;

    public void Initialize()
    {
        On.Skill.StartInit += new On.Skill.hook_StartInit(SkillPatch);
    }

    public void SkillPatch(On.Skill.orig_StartInit orig, Skill instance)
    {
        //Defaults
        //8100360_Brace_T2b-i9VLWk Cooldown: 200
        //8100362_PommelCounter_IJbv25Xd6E Cooldown: 100
        //8100261_Serpent's Parry_Njco9iRrXU Cooldown: 100
        //8100340_Deflection Strike_xn67zUxgnU Cooldown: 100
        switch (instance.Name)
        {
            case "Brace":
                instance.Cooldown = 120f;
                break;
            case "Counterstrike":
                instance.Cooldown = 30f;
                break;
            case "Serpent's Parry":
                instance.Cooldown = 30f;
                break;
            case "Pommel Counter":
                instance.Cooldown = 30f;
                break;
            case "Simeon's Gambit":
                instance.Cooldown = 30f;
                break;
        }


        orig(instance);
        //Debug.Log("Skill ctor:\r\nName: " + instance.Name + "\r\nIsPassive: " + instance.IsPassive + "\r\nManaCost: " + instance.ManaCost + "\r\nStaminaCost: " + instance.StaminaCost + 
        //    "\r\nCooldown: " + instance.Cooldown + "\r\nLifespan: " + instance.Lifespan + "\r\nDurabilityCost: " + instance.DurabilityCost + "\r\nDurabilityCostPercent: " + instance.DurabilityCostPercent);

    }    
}
