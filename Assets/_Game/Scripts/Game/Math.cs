using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MathData
{
    public float number1;
    public float number2;
    public float result;
    public string _operator;
}


public class Math
{

    public string GetOperator(int oper)
    {
        switch (oper)
        {
            case 0: return "+";
            case 1: return "-";
            case 2: return "x";
            case 3: return ":";
            default: return "";
        }
    }


    public MathData GenerateOperaterAddition(int level, string oper, TurnData turnData)
    {
        MathData mathData = new MathData();
        while (true)
        {
            bool isOK = true;
            mathData.number1 = UnityEngine.Random.Range(1, 100);
            mathData.number2 = UnityEngine.Random.Range(1, 100);

            switch (level)
            {
                // easy
                case 0: if (mathData.number1 >= turnData.maxLevelEasy || mathData.number2 >= turnData.maxLevelEasy) isOK = false; break;
                // medium
                case 1: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
                // high
                case 2: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
            }

            if (isOK)
            {
                mathData.result = mathData.number1 + mathData.number2;
                mathData._operator = oper;
                break;
            }
        }
        return mathData;
    }


    public MathData GenerateOperaterSubtract(int level, string oper, TurnData turnData)
    {
        MathData mathData = new MathData();
        while (true)
        {
            bool isOK = true;
            mathData.number1 = UnityEngine.Random.Range(1, 100);
            mathData.number2 = UnityEngine.Random.Range(1, 100);

            switch (level)
            {
                // easy
                case 0: if (mathData.number1 >= turnData.maxLevelEasy || mathData.number2 >= turnData.maxLevelEasy) isOK = false; break;
                // medium
                case 1: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
                // high
                case 2: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
            }

            if (isOK)
            {
                mathData.result = mathData.number1 - mathData.number2;
                mathData._operator = oper;
                break;
            }
        }
        return mathData;
    }


    public MathData GenerateOperaterMultiple(int level, string oper, TurnData turnData)
    {
        MathData mathData = new MathData();
        while (true)
        {
            bool isOK = true;
            mathData.number1 = UnityEngine.Random.Range(1, 100);
            mathData.number2 = UnityEngine.Random.Range(1, 100);

            switch (level)
            {
                // easy
                case 0: if (mathData.number1 >= turnData.maxLevelEasy || mathData.number2 >= turnData.maxLevelEasy) isOK = false; break;
                // medium
                case 1: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
                // high
                case 2: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
            }

            if (isOK)
            {
                mathData.result = mathData.number1 * mathData.number2;
                mathData._operator = oper;
                break;
            }
        }
        return mathData;
    }


    public MathData GenerateOperaterDivision(int level, string oper, TurnData turnData)
    {
        MathData mathData = new MathData();
        while (true)
        {
            bool isOK = true;
            mathData.number1 = UnityEngine.Random.Range(1, 100);
            mathData.number2 = UnityEngine.Random.Range(1, 100);

            switch (level)
            {
                // easy
                case 0: if (mathData.number1 >= turnData.maxLevelEasy || mathData.number2 >= turnData.maxLevelEasy) isOK = false; break;
                // medium
                case 1: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
                // high
                case 2: if (mathData.number1 >= turnData.maxLevelMedium || mathData.number2 >= turnData.maxLevelMedium) isOK = false; break;
            }

            if (isOK)
            {
                double num = mathData.number1 / mathData.number2;
                mathData.result = (float)System.Math.Round(num, 2);
                mathData._operator = oper;
                break;
            }
        }
        return mathData;
    }


}
