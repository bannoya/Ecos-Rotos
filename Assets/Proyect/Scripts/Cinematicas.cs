using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Cinematicas : MonoBehaviour
{
    [System.Serializable]
    public class CinematicScene
    {
        public Sprite image;

        [TextArea(3, 6)]
        public string[] lines;
    }

    [Header("UI")]
    [SerializeField] private GameObject cinematicPanel;
    [SerializeField] private Image cinematicImage;
    [SerializeField] private TMP_Text cinematicText;

    [Header("Contenido")]
    [SerializeField] private CinematicScene[] scenes;

    [Header("Configuración")]
    [SerializeField] private float textSpeed = 0.05f;

    private int sceneIndex;
    private int lineIndex;

    private bool isTyping;

    void Start()
    {
        cinematicPanel.SetActive(true);

        sceneIndex = 0;
        lineIndex = 0;

        ShowScene();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isTyping)
            {
                StopAllCoroutines();

                cinematicText.text =
                    scenes[sceneIndex].lines[lineIndex];

                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    void ShowScene()
    {
        cinematicImage.sprite =
            scenes[sceneIndex].image;

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;

        cinematicText.text = "";

        string currentLine =
            scenes[sceneIndex].lines[lineIndex];

        foreach (char c in currentLine)
        {
            cinematicText.text += c;

            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        lineIndex++;

        if (lineIndex <
            scenes[sceneIndex].lines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            sceneIndex++;

            if (sceneIndex < scenes.Length)
            {
                lineIndex = 0;

                ShowScene();
            }
            else
            {
                EndCinematic();
            }
        }
    }

    void EndCinematic()
    {
        cinematicPanel.SetActive(false);

        Debug.Log("Fin de la cinemática");
    }
}
