using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars 
{

    public abstract class Character
    {
        public int HP, attack, rateOfFire;
        public abstract bool shouldCollide();
    }

    public class Plant : Character
    {
        public override bool shouldCollide()
        {
            return true;
        }
    }

    public class Zombie : Character
    {
        public int speed;

        public override bool shouldCollide()
        {
            return false;
        }

    }
}