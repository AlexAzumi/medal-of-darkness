using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine;
using System;

[System.Serializable]
public class SaveLoad
{
    /* Made by Aldan Project | 2018 */
    public User m_User;
    public Game[] m_Games = new Game[3];

    public void SaveUser()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/user.save");
        bf.Serialize(file, m_User);
        file.Close();
    }

    public User LoadUser()
    {
        if (File.Exists(Application.persistentDataPath + "/user.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                FileStream file = File.Open(Application.persistentDataPath + "/user.save", FileMode.Open);
                m_User = (User)bf.Deserialize(file);
                file.Close();
                return m_User;
            }
            catch(FileNotFoundException ex)
            {
                Debug.Log("No hay usuarios almacenados");
                Debug.Log("Mensaje: " + ex.Message);
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public bool DeleteUser()
    {
        if (File.Exists(Application.persistentDataPath + "/user.save"))
        {
            try
            {
                File.Delete(Application.persistentDataPath + "/user.save");
                return true;
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    /*
    public List<Game> LoadGames()
    {
        if (File.Exists(Application.persistentDataPath + "savedGames.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.save", FileMode.Open);
            m_Games = (Game[])bf.Deserialize(file);
            file.Close();
            return m_Games;
        }
        else
        {
            return null;
        }
    }


    public void SaveGame(int slot, Game actualGame)
    {
        m_Games[slot - 1] = actualGame;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.save");
        bf.Serialize(file, m_Games);
        file.Close();
    }
    */
}
