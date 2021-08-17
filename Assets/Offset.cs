using UnityEngine;
using UnityEngine.UI;

public class Offset : MonoBehaviour
{
    public float Value;

    [SerializeField] float Change;
    [SerializeField] InputField InputField;

    void Start()
    {
        InputField.text = Value.ToString();
    }

    public void ChangedInputField()
    {
        Value = float.Parse(InputField.text);
    }

    public void OnClickMinus()
    {
        Value = float.Parse(InputField.text);
        Value -= Change;
        InputField.text = Value.ToString();
    }

    public void OnClickPlus()
    {
        Value = float.Parse(InputField.text);
        Value += Change;
        InputField.text = Value.ToString();
    }
}
