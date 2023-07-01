using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characters : MonoBehaviour
{

    [SerializeField] Text exp;
    [SerializeField] GameObject panel;
    [SerializeField] Image health;
    [SerializeField] Text h;
    [SerializeField] Image energy;
    [SerializeField] Text e;
    [SerializeField] Image food;
    [SerializeField] Text f;
    [SerializeField] Text eda;
    [SerializeField] Text lec;
    [SerializeField] Text coin;

    private void Update()
    {
        try
        {
            Memory.hungry -= 0.0001;
            using (var connection = new SqliteConnection("Data Source = D:\\xlam\\рпон\\Pypets.db"))
            {
                if (Memory.health > 0 && Memory.energy > 0 && Memory.hungry > 0)
                {
                    connection.Open();
                    var command = new SqliteCommand($"Update Pet Set Energy = '{(int)(Memory.energy*100)}', Hunger = '{(int)(Memory.hungry * 100)}', Health = '{(int)(Memory.health * 100)}' WHERE IDpet ='{Memory.id}'", connection);
                    command.ExecuteNonQuery();
                    var command2 = new SqliteCommand($"Update Store Set Food = '{Memory.food}', Water = '{Memory.water}' WHERE IDStore = '{Memory.id}'", connection);
                    command2.ExecuteNonQuery();
                    var command3 = new SqliteCommand($"Update User Set Coins = '{Memory.coins}', EXP='{Memory.exp}' WHERE IDuser = '{Memory.id}'", connection);
                    command3.ExecuteNonQuery();
                    connection.Close();
                    health.fillAmount = (float)Memory.health;
                    energy.fillAmount = (float)Memory.energy;
                    food.fillAmount = (float)Memory.hungry;
                    h.text = Math.Round(Memory.health * 100).ToString();
                    e.text = Math.Round(Memory.energy * 100).ToString();
                    f.text = Math.Round(Memory.hungry * 100).ToString();
                    eda.text = Memory.food.ToString();
                    lec.text = Memory.water.ToString();
                    coin.text = Memory.coins.ToString();
                    exp.text = Memory.exp.ToString();
                }
                else
                {
                    panel.SetActive(true);
                    Memory.health = 0;
                    Memory.energy = 0;
                    Memory.hungry = 0;
                }
                if (Memory.energy < 0.1 || Memory.hungry < 0.1)
                {
                    Memory.health -= 0.001;
                    anime.anim.SetBool("ploho", true);
                }
                else
                {
                    anime.anim.SetBool("ploho", false);
                }
            }
        }

        catch (NullReferenceException)
        {

        } 
    }
    public void click()
    {
        using (var connection = new SqliteConnection("Data Source = D:\\xlam\\рпон\\Pypets.db"))
        {
            connection.Open();
            Memory.energy = 1;
            Memory.food = 3;
            Memory.coins = 0;
            Memory.health = 1;
            Memory.hungry = 1;
            Memory.water = 3;
            var command = new SqliteCommand($"Update Pet Set Energy = '{(int)(Memory.energy * 100)}', Hunger = '{(int)(Memory.hungry * 100)}', Health = '{(int)(Memory.health * 100)}' WHERE IDpet ='{Memory.id}'", connection);
            command.ExecuteNonQuery();
            var command2 = new SqliteCommand($"Update Store Set Food = '{Memory.food}', Water = '{Memory.water}' WHERE IDStore = '{Memory.id}'", connection);
            command2.ExecuteNonQuery();
            var command3 = new SqliteCommand($"Update User Set Coins = '{Memory.coins}' WHERE IDuser = '{Memory.id}'", connection);
            command3.ExecuteNonQuery();
            connection.Close();
            health.fillAmount = (float)Memory.health;
            energy.fillAmount = (float)Memory.energy;
            food.fillAmount = (float)Memory.hungry;
            h.text = Math.Round(Memory.health * 100).ToString();
            e.text = Math.Round(Memory.energy * 100).ToString();
            f.text = Math.Round(Memory.hungry * 100).ToString();
            eda.text = Memory.food.ToString();
            lec.text = Memory.water.ToString();
            coin.text = Memory.coins.ToString();
            exp.text = Memory.exp.ToString();
            panel.SetActive(false);
        }
        }
    }




