using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerManagers : MonoBehaviour
{
    public DataManager dataManager;
    public CharactersManager charactersManager;
    public ScoreController scoreControllersc;

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
<<<<<<< HEAD
        if (uiInterface == null)
            if (uiInterface == null)
            Debug.Log("Не указан префаб [INTERFACE] в ManagerManagers!");
=======

>>>>>>> parent of eddaa80... Реализовал смену языка интерфейса. Для этого пришлось изменить префаб ManagerManagers и сделать так, чтобы из него загружался префаб [INTERFACE]. Для сцены SimpleScene создал копию префаба интерфейса [INTERFACE]Play. Внёс небольшие изменения в collision.cs(сделал так, чтобы при коллизии с пингвином собиралась рыба. Почемуто не работает джостик при старте игры, а если нажать на паузу, а потом продолжить, то работает

        charactersManager.Initialize(); // Инициализируем CharactersManager (создаём персонажей)
        dataManager.Load(); // Загружаем данные в DataManager
        charactersManager.InitializeCharactersFromDataManager(); // Загружаем данные о персонажах из DataManager
        scoreControllersc.Initialize(); // Загружаем данные из DataManager в ScoreController
    }
    void Start()
    {
        LoadManagers();
        InitManagers();
        UIScreen[] screens = FindObjectsOfType<UIScreen>();
        if (screens != null)
        {
            foreach (UIScreen screen in screens)
            {
                if(screen.name == "Shop")
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

}
