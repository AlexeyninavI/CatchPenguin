
using UnityEngine;

public class ManagerManagers : MonoBehaviour
{
    public DataManager dataManager;
    public CharactersManager charactersManager;
    public ScoreController scoreControllersc;
    public Respawn respawnManager;
    public UIHome uiInterface;
    public GameManager gameManager;

    void LoadManagers()
    {
        dataManager = Instantiate(dataManager, transform);
        charactersManager = Instantiate(charactersManager, transform);
        scoreControllersc = Instantiate(scoreControllersc, transform);
    }
    void InitManagers()
    {
        if (dataManager == null)
            Debug.Log("Не указан префаб DataManager в ManagerManagers!");
        if (charactersManager == null)
            Debug.Log("Не указан префаб charactersManager в ManagerManagers!");
        if (scoreControllersc == null)
            Debug.Log("Не указан префаб scoreControllersc в ManagerManagers!");
        if (uiInterface == null)
            if (uiInterface == null)
                Debug.Log("Не указан префаб [INTERFACE] в ManagerManagers!");

        charactersManager.Initialize(); // Инициализируем CharactersManager (создаём персонажей)
        dataManager.Load(); // Загружаем данные в DataManager
        charactersManager.InitializeCharactersFromDataManager(); // Загружаем данные о персонажах из DataManager
        scoreControllersc.Initialize(); // Загружаем данные из DataManager в ScoreController
    }

    void Awake()
    {
        LoadManagers();
        InitManagers();

        if (respawnManager != null)
            respawnManager.SpawnCharacter();

        uiInterface = Instantiate(uiInterface, transform); // Загружаем интерфейс
        UIScreen[] screens = FindObjectsOfType<UIScreen>();
        if (screens != null)
        {
            foreach (UIScreen screen in screens)
            {
                if (screen.name == "Shop")
                {
                    ShopManager sm = screen.GetComponentInChildren<ShopManager>();
                    if (sm != null)
                    {
                        sm.Initialize();
                    }
                    else Debug.Log("ShopManage not found!");
                }
            }
        }
        else Debug.Log("Screens not found!");
    }

    void OnDisable()
    {
        Debug.Log("Disable ManagerManagers");
    }

}
