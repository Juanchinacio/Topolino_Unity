using UnityEngine;
using DG.Tweening;
public class MenuController : MonoBehaviour
{
    #region Variables for Animations

    //Time max for animation
    private float fadeTime = 1.2f;

    //Panels positions
    private Vector2 posIn_Menu = new Vector2(0f, 0f);
    private Vector2 posOut_Menu = new Vector2(0f, -2166f);

    private Vector2 posUp_Title = new Vector2(0f, 520f);
    private Vector2 posDown_Title = new Vector2(0f, 0f);
    private Vector2 posHide_Title = new Vector2(0f, -1702f);

    private Vector2 posIn_Controls = new Vector2(0f, 0);
    private Vector2 posOut_Controls = new Vector2(3993f, 0f);

    private Vector2 posIn_Credits = new Vector2(0f, 0);
    private Vector2 posOut_Credits = new Vector2(3993f, 0f);

    private Vector2 posIn_Collectables = new Vector2(0f, 0);
    private Vector2 posOut_Collectables = new Vector2(3993f, 0f);

    private Vector2 posIn_Settings = new Vector2(0f, 0);
    private Vector2 posOut_Settings = new Vector2(3993f, 0f);

    private Vector2 posIn_LevelSelector = new Vector2(0f, 0);
    private Vector2 posOut_LevelSelector = new Vector2(3993f, 0f);

    //Generic variables for private use
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    //Audio manager
    [SerializeField] private AudioManager audioManager;

    [Header("Title")]
    public CanvasGroup cg_Title;
    public RectTransform rt_Title;

    [Header("Menu")]
    public CanvasGroup cg_Menu;
    public RectTransform rt_Menu;
    
    [Header("Level Selector")]
    public CanvasGroup cg_LevelSelector;
    public RectTransform rt_LevelSelector;

    [Header("Controls")]
    public CanvasGroup cg_Controls;
    public RectTransform rt_Controls;

    [Header("Credits")]
    public CanvasGroup cg_Credits;
    public RectTransform rt_Credits;

    [Header("Collectables")]
    public CanvasGroup cg_Collectables;
    public RectTransform rt_Collectables;

    [Header("Collectables")]
    public CanvasGroup cg_Settings;
    public RectTransform rt_Settings;

    #endregion

    private void Start()
    {
        UpTitle();
        audioManager.PlaySound(Sound.ui);
        ShowMenu();
    }


    public void PanelFade(bool fadeIn, Vector3 newPosition, Vector2 lastPosition)
    {
        //Fade in settings
        float alpha = 1f;
        Ease type = Ease.InOutQuint;

        if (!fadeIn)
        {
            //Fade out settings
            alpha = 1f;
            type = Ease.InOutQuint;
        }

        canvasGroup.alpha = alpha;
        rectTransform.transform.localPosition = newPosition;
        rectTransform.DOAnchorPos(lastPosition, fadeTime, false).SetEase(type);
        canvasGroup.DOFade(1f, fadeTime);
    }
    #region Title panel
    public void UpTitle()
    {
        //Down Menu
        canvasGroup = cg_Title;
        rectTransform = rt_Title;
        PanelFade(true, new Vector3(posDown_Title.x, posDown_Title.y, 0f), posUp_Title);
    }
    public void DownTitle()
    {
        //Down Menu
        canvasGroup = cg_Title;
        rectTransform = rt_Title;
        PanelFade(true, new Vector3(posUp_Title.x, posUp_Title.y, 0f), posDown_Title);
    }
    public void HideTitle()
    {
        //Down Menu
        canvasGroup = cg_Title;
        rectTransform = rt_Title;
        PanelFade(true, new Vector3(posUp_Title.x, posUp_Title.y, 0f), posHide_Title);
    }
    public void ShowTitle()
    {
        //Down Menu
        canvasGroup = cg_Title;
        rectTransform = rt_Title;
        PanelFade(true, new Vector3(posHide_Title.x, posHide_Title.y, 0f), posUp_Title);
    }
    #endregion

    #region Menu
    public void ShowMenu()
    {
        //Show Menu
        canvasGroup = cg_Menu;
        rectTransform = rt_Menu;
        PanelFade(true, new Vector3(posOut_Menu.x, posOut_Menu.y, 0f), posIn_Menu);
    }

    public void HideMenu()
    {
        //Hide Menu
        canvasGroup = cg_Menu;
        rectTransform = rt_Menu;
        PanelFade(true, new Vector3(posIn_Menu.x, posIn_Menu.y, 0f), posOut_Menu);
    }
    #endregion

    #region Controls
    public void ShowControls()
    {
        //Show Menu
        canvasGroup = cg_Controls;
        rectTransform = rt_Controls;
        PanelFade(true, new Vector3(posOut_Controls.x, posOut_Controls.y, 0f), posIn_Controls);
    }

    public void HideControls()
    {
        //Hide Menu
        canvasGroup = cg_Controls;
        rectTransform = rt_Controls;
        PanelFade(true, new Vector3(posIn_Controls.x, posIn_Controls.y, 0f), posOut_Controls);
    }
    #endregion

    #region Credits
    public void ShowCredits()
    {
        //Show Menu
        canvasGroup = cg_Credits;
        rectTransform = rt_Credits;
        PanelFade(true, new Vector3(posOut_Credits.x, posOut_Credits.y, 0f), posIn_Credits);
    }

    public void HideCredits()
    {
        //Hide Menu
        canvasGroup = cg_Credits;
        rectTransform = rt_Credits;
        PanelFade(true, new Vector3(posIn_Credits.x, posIn_Credits.y, 0f), posOut_Credits);
    }
    #endregion

    #region Collectables
    public void ShowCollectables()
    {
        //Show Menu
        canvasGroup = cg_Collectables;
        rectTransform = rt_Collectables;
        PanelFade(true, new Vector3(posOut_Collectables.x, posOut_Collectables.y, 0f), posIn_Collectables);
    }

    public void HideCollectables()
    {
        //Hide Menu
        canvasGroup = cg_Collectables;
        rectTransform = rt_Collectables;
        PanelFade(true, new Vector3(posIn_Collectables.x, posIn_Collectables.y, 0f), posOut_Collectables);
    }
    #endregion

    #region Level Selector
    public void ShowLevelSelector()
    {
        //Show LevelSelector
        canvasGroup = cg_LevelSelector;
        rectTransform = rt_LevelSelector;
        PanelFade(true, new Vector3(posOut_LevelSelector.x, posOut_LevelSelector.y, 0f), posIn_LevelSelector);
    }

    public void HideLevelSelector()
    {
        //Hide LevelSelector
        canvasGroup = cg_LevelSelector;
        rectTransform = rt_LevelSelector;
        PanelFade(true, new Vector3(posIn_LevelSelector.x, posIn_LevelSelector.y, 0f), posOut_LevelSelector);
    }

    #endregion

    #region Settings
    public void ShowSettings()
    {
        //Show Menu
        canvasGroup = cg_Settings;
        rectTransform = rt_Settings;
        PanelFade(true, new Vector3(posOut_Settings.x, posOut_Settings.y, 0f), posIn_Settings);
    }

    public void HideSettings()
    {
        //Hide Menu
        canvasGroup = cg_Settings;
        rectTransform = rt_Settings;
        PanelFade(true, new Vector3(posIn_Settings.x, posIn_Settings.y, 0f), posOut_Settings);
    }
    #endregion

    #region Button methods

    public void OpenLevelSelector()
    {
        audioManager.PlaySound(Sound.click);
        HideTitle();
        HideMenu();
        ShowLevelSelector();
    }

    public void CloseLevelSelector()
    {
        audioManager.PlaySound(Sound.click);
        ShowTitle();
        HideLevelSelector();
        ShowMenu();
    }

    public void OpenControls()
    {
        audioManager.PlaySound(Sound.click);
        HideTitle();
        HideMenu();
        ShowControls();
    }

    public void CloseControls()
    {
        audioManager.PlaySound(Sound.click);
        ShowTitle();
        HideControls();
        ShowMenu();
    }
    public void OpenCredits()
    {
        audioManager.PlaySound(Sound.click);
        HideTitle();
        HideMenu();
        ShowCredits();
    }
    public void CloseCredits()
    {
        audioManager.PlaySound(Sound.click);
        ShowTitle();
        HideCredits();
        ShowMenu();
    }

    public void OpenCollectables()
    {
        audioManager.PlaySound(Sound.click);
        HideTitle();
        HideMenu();
        ShowCollectables();
    }
    public void CloseCollectables()
    {
        audioManager.PlaySound(Sound.click);
        ShowTitle();
        HideCollectables();
        ShowMenu();
    }

    public void OpenSettings()
    {
        audioManager.PlaySound(Sound.click);
        HideTitle();
        HideMenu();
        ShowSettings();
    }
    public void CloseSettings()
    {
        audioManager.PlaySound(Sound.click);
        ShowTitle();
        HideSettings();
        ShowMenu();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    #endregion

}
