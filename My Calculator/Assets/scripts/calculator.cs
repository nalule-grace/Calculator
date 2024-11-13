using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class calculator : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private string currentInput = "";
    private string currentOperator = "";
    private double firstOperand ;

    public void OnDigitButtonPressed(string digit)
    {
    
        currentInput += digit;
        Debug.Log("Button pressed: " + digit);
        Debug.Log("Current input: " + currentInput);
        UpdateDisplay();
    }

    public void OnOperatorButtonPressed(string op)
    {
        if (currentOperator != "")
        {
            Calculate();
        }
        firstOperand = double.Parse(currentInput);
        currentOperator = op;
        currentInput = "";
        UpdateDisplay();
    }

    public void OnClearButtonPressed()
    {
        currentInput = "";
        currentOperator = "";
        firstOperand = 0;
        UpdateDisplay();
    }

    public void OnEqualsButtonPressed()
    {
        Calculate();
        UpdateDisplay();
    }

    //calculator
    private void Calculate()
    {
        double secondOperand = double.Parse(currentInput);
        double result = 0;

        switch (currentOperator)
        {
            case "+":
                result = firstOperand + secondOperand;
                break;
            case "-":
                result = firstOperand - secondOperand;
                break;
            case "*":
                result = firstOperand * secondOperand;
                break;
            case "/":
                if(secondOperand != 0)
                {
                    result = firstOperand / secondOperand;
                }
                else
                {
                    result = double.NaN;
                }
                break;
            default:
                break;    
        }
        currentInput = result.ToString();
    }

    private void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    // Start is called before the first frame update

}
