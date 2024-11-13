using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public interface IOperation
{
    double Calculate(double operand1, double operand2);
}

public class AddOperation : IOperation
{
    public double Calculate(double operand1, double operand2)
    {
        return operand1 + operand2;
    }
}

public class SubOperation : IOperation
{
    public double Calculate(double operand1, double operand2)
    {
        return operand1 - operand2;
    }
}

public class MulOperation : IOperation
{
    public double Calculate(double operand1, double operand2)
    {
        return operand1 * operand2;
    }
}

public class DivOperation : IOperation
{
    public double Calculate(double operand1, double operand2)
    {
        if (operand2 != 0)
        {
            return operand1 / operand2;
        }
        else
        {
            return double.NaN;
        }
    }    
}
public class calculator : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private string currentInput = "";
    private string currentOperator = "";
    private double firstOperand = 0;
    private IOperation currentOperation;

    public void OnDigitButtonPressed(string digit)
    {
    
        currentInput += digit;
        Debug.Log("Button pressed: " + digit);
        Debug.Log("Current input: " + currentInput);
        UpdateDisplay();
    }

    public void OnOperatorButtonPressed(string op)
    {
        //if (currentOperator != "")
        //{
         //   Calculate(firstOperand, secondOperand);
       // }
        firstOperand = double.Parse(currentInput);
        currentOperator = op;
        currentInput = "";
        UpdateDisplay();


        SetOperation(op[0]);
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
        double secondOperand = double.Parse(currentInput);
        if (currentOperation != null)
        {
            double result = Calculate(firstOperand, secondOperand);
            currentInput = result.ToString();
            UpdateDisplay();
        }
        else
        {
            Debug.Log("no operation selected");
        }
        
    }

    //calculator
    private void SetOperation(char op)
    {

        switch (op)
        {
            case '+':
                currentOperation = new AddOperation();
                break;
            case '-':
                currentOperation = new SubOperation();
                break;
                
            case '*':
                currentOperation = new MulOperation();
                break;
            case '/':
                currentOperation = new DivOperation();
                break;
            default:
                break;    
        }
        //currentInput = result.ToString();
    }

    private double Calculate (double operand1, double operand2)
    {
        return currentOperation.Calculate(operand1, operand2);
    }

    private void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    // Start is called before the first frame update

}
