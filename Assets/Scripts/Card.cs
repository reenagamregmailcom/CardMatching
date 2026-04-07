using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
   public int id;
    public Sprite icon, hideIcon;
    [SerializeField] private Image myImage;
    [SerializeField] private Button myButton;

    [SerializeField] private GameManager manager;
    [SerializeField] private AudioSource flipSound;

    void Start()
    {
        manager = GameManager.Instance;//FindObjectOfType<GameManager>();
    }

    public void OnClick()
    {
        if (manager.canFlip)
        {
            Flip();
            manager.CardFlipped(this);
            flipSound.Play();
        }
    }

    public void Flip()
    {
        myImage.sprite = icon;
        myButton.interactable = false;
    }

    public void Hide()
    {
         myImage.sprite = hideIcon;
         myButton.interactable = true;
    }
}