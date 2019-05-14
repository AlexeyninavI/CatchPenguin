using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class About : UIScreen
{
    public override void Show()
    {
        base.Show();
        Debug.Log("Show About");

        DataManager dm = FindObjectOfType<DataManager>();
        if (dm.language == "rus")
        {
            ChangeRusLanguage();
            return;
        }
        if (dm.language == "eng")
        {
            ChangeEngLanguage();
            return;
        }
    }

    public void OnCloseBtn()
    {
        Hide();
        UIHome.instance.ShowMenu();
    }

     public void ChangeRusLanguage()
    {
        Debug.Log("Changed rus language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts) {
            if (text.name == "DevelopedByText") {
                text.text = "разработано"; continue;
            }
            if (text.name == "VersionText") { 
                text.text = "<size=150>версия</size>\r\n\r0.0.1 - раз."; continue;
            }
            if (text.name == "GameDirectorText") { 
                text.text = "<size=150>игровой директор</size>"; continue;
            }
            if (text.name == "Text (3)") { 
                text.text = "козлов михаил"; continue;
            }
            if (text.name == "GraphicsText") { 
                text.text = "<size=150>Графика</size>"; continue;
            }
            if (text.name == "Text (5)") { 
                text.text = "михайлов владимир"; continue;
            }  
            if (text.name == "Text (6)") {
                text.text = "козлов михаил"; continue;
            }
            if (text.name == "ProgrammingText") { 
                text.text = "<size=150>Кодирование</size>"; continue;
            }
            if (text.name == "Text (8)") { 
                text.text = "иванин алексей"; continue;
            }
            if (text.name == "Text (9)") { 
                text.text = "нейфельд олег"; continue;
            }
            if (text.name == "SoundText") { 
                text.text = "<size=150>звук</size>"; continue;
            }
            if (text.name == "Text (11)") { 
                text.text = "козлов михаил"; continue;
            }  
             if (text.name == "AnalyticsText") { 
                text.text = "<size=150>аналитика</size>"; continue;
            }
            if (text.name == "Text (13)") { 
                text.text = "зательмаер анна"; continue;
            }
            if (text.name == "TestingText") { 
                text.text = "<size=150>тестирование</size>"; continue;
            }
            if (text.name == "Text (15)") { 
                text.text = "цыдыпова жамьяна"; continue;
            }  
            if (text.name == "HelpText") {
                text.text = "для получения помощи пишите на"; continue;
            }
            if (text.name == "EmailText") { 
                text.text = "testemail@email.com"; continue;
            }
        }
    }
    public void ChangeEngLanguage()
    {
        Debug.Log("Changed eng language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "DevelopedByText") {
                text.text = "developed by"; continue;
            }
            if (text.name == "VersionText") { 
                text.text = "<size=150>version</size>\r\n\r0.0.1 - dev"; continue;
            }
            if (text.name == "GameDirectorText") { 
                text.text = "<size=150>Game director</size>"; continue;
            }
            if (text.name == "Text (3)") { 
                text.text = "kozlov mikhail"; continue;
            }
            if (text.name == "GraphicsText") { 
                text.text = "<size=150>Graphics</size>"; continue;
            }
            if (text.name == "Text (5)") { 
                text.text = "mikhailov vladimir"; continue;
            }  
            if (text.name == "Text (6)") {
                text.text = "kozlov mikhail"; continue;
            }
            if (text.name == "ProgrammingText") { 
                text.text = "<size=150>programming</size>"; continue;
            }
            if (text.name == "Text (8)") { 
                text.text = "ivanin alexey"; continue;
            }
            if (text.name == "Text (9)") { 
                text.text = "neyfeld oleg"; continue;
            }
            if (text.name == "SoundText") { 
                text.text = "<size=150>sound</size>"; continue;
            }
            if (text.name == "Text (11)") { 
                text.text = "kozlov mikhail"; continue;
            }  
             if (text.name == "AnalyticsText") { 
                text.text = "<size=150>analytics</size>"; continue;
            }
            if (text.name == "Text (13)") { 
                text.text = "zatelmaer anna"; continue;
            }
            if (text.name == "TestingText") { 
                text.text = "<size=150>testing</size>"; continue;
            }
            if (text.name == "Text (15)") { 
                text.text = "tsydypova zhamyana"; continue;
            }  
            if (text.name == "HelpText") {
                text.text = "for help send message to"; continue;
            }
            if (text.name == "EmailText") { 
                text.text = "testemail@email.com"; continue;
            }
        }
    }
}
