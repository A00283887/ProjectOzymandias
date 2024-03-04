using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Add this to use UI components

public class CommanUI : MonoBehaviour
{
    public TMP_Text displayText; // Assign your UI Text component in the Inspector
    public string text = "Your text here"; // The text you want to type out
    public float typingSpeed = 0.05f; // Time between each character display

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        int textLength = text.Length;
        int currentCharIndex = 0;
        bool showCursor = true;

        while (currentCharIndex <= textLength)
        {
            string textToShow = text.Substring(0, currentCharIndex) + (showCursor ? "_" : "");
            displayText.text = textToShow;

            // Toggle cursor visibility
            showCursor = !showCursor;

            // Wait for a bit before adding the next character
            yield return new WaitForSeconds(typingSpeed);

            // Only add a new character if the cursor is about to be hidden
            if (showCursor && currentCharIndex < textLength)
            {
                currentCharIndex++;
            }
            // If at the end of the text, keep blinking the cursor indefinitely
            else if (currentCharIndex == textLength)
            {
                typingSpeed = 1f; // Slow down to blink the cursor once per second
            }
        }
    }
}