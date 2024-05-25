using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputField inputField = gameObject.GetComponent<InputField>();
        if (inputField != null)
        {
            InputField inputField1 = inputField;
            inputField1.onEndEdit.AddListener(displayText);
        }
        else
        {
            Debug.LogError("InputField component not found on the GameObject.");
        }
    }

    private void displayText(string textInField)
    {
        print(textInField);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
