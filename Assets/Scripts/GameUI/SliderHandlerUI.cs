using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandlerUI : MonoBehaviour
{
    public enum SliderType
    {
        MusicVolume,
        SoundEffectVolume,
    }

    [SerializeField] private SliderType m_sliderType;

    [SerializeField] private Slider m_slider;
    [SerializeField] private TextMeshProUGUI m_valueText;



    private void Start()
    {
        int value = 0;
        switch (m_sliderType)
        {
            case SliderType.MusicVolume:
                value = Saver.HasData(Saver.MUSICVOLUMEPLAYERPREFS) ? Saver.LoadData(Saver.MUSICVOLUMEPLAYERPREFS) : (int)m_slider.value;
                break;
            case SliderType.SoundEffectVolume:
                value = Saver.HasData(Saver.SOUNDEFFECTSVOLUMEPLAYERPREFS) ? Saver.LoadData(Saver.SOUNDEFFECTSVOLUMEPLAYERPREFS) : (int)m_slider.value;
                break;
        }
        m_slider.value = value;
        m_valueText.text = value.ToString();

        m_slider.onValueChanged.AddListener(delegate { OnValueChange(); });
    }

    private void OnValueChange()
    {
        int value = (int)m_slider.value;
        m_valueText.text = value.ToString();
        switch (m_sliderType)
        {
            case SliderType.MusicVolume:
                Saver.SaveData(Saver.MUSICVOLUMEPLAYERPREFS, value);
                break;
            case SliderType.SoundEffectVolume:
                Saver.SaveData(Saver.SOUNDEFFECTSVOLUMEPLAYERPREFS, value);
                break;
        }
    }
}