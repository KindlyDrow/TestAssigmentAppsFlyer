using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultiesHandlerUI : MonoBehaviour
{
    [SerializeField] private Button m_easyButton;
    [SerializeField] private Button m_mediumButton;
    [SerializeField] private Button m_hardButton;

    [SerializeField] private Color m_selectedColor;
    private Color m_easyButtonColor;
    private Color m_mediumButtonColor;
    private Color m_hardButtonColor;


    private void Start()
    {
        GetDefaultColors();
        SetDifficulty((DifficultySetings.Difficulty) Saver.LoadData(Saver.DIFFICULTYPLAYERPREFS));
        m_easyButton.onClick.AddListener(delegate { SetDifficulty(DifficultySetings.Difficulty.Easy); });
        m_mediumButton.onClick.AddListener(delegate { SetDifficulty(DifficultySetings.Difficulty.Medium); });
        m_hardButton.onClick.AddListener(delegate { SetDifficulty(DifficultySetings.Difficulty.Hard); });
    }

    private void SetDifficulty(DifficultySetings.Difficulty difficulty)
    {
        SetAllColorsDefault();

        switch (difficulty)
        {
            case DifficultySetings.Difficulty.Easy:
                m_easyButton.image.color = m_selectedColor;
                break;
            case DifficultySetings.Difficulty.Medium:
                m_mediumButton.image.color = m_selectedColor;
                break;
            case DifficultySetings.Difficulty.Hard:
                m_hardButton.image.color = m_selectedColor;
                break;
        }

        Saver.SaveData(Saver.DIFFICULTYPLAYERPREFS,(int)difficulty);
        DifficultySetings.Instance.SetDifficulty(difficulty);
    }

    private void GetDefaultColors()
    {
        m_easyButtonColor = m_easyButton.image.color;
        m_mediumButtonColor = m_mediumButton.image.color;
        m_hardButtonColor = m_hardButton.image.color;
    }

    private void SetAllColorsDefault()
    {
        m_easyButton.image.color = m_easyButtonColor;
        m_mediumButton.image.color = m_mediumButtonColor;
        m_hardButton.image.color = m_hardButtonColor;
    }
}
