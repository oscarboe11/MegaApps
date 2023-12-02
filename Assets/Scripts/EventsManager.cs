using UnityEngine;

// handles startup and calls functions for search periodically
public class EventsManager : MonoBehaviour {
    public GameObject AppButton;
    public GameObject SearchMenuContent;
    public GameObject SearchBar;
    public GameObject CategoriesDropDown;
    public GameObject CategoriesContent;
    
    // called before first frame
    void Start() {
        Events.InitiateCategoryOptions(CategoriesDropDown);
        Debug.Log(Application.platform.ToString());

    }
    
    // called every 0.02 seconds
    void FixedUpdate() {
        Events.InitiateSearchPage(AppButton, SearchMenuContent, SearchBar);
        Events.InitiateCategoryMenu(AppButton, CategoriesContent, CategoriesDropDown);
    }
}
