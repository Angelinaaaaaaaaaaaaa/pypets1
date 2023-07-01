using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class action : MonoBehaviour
{
    public void pit()
    {
        Memory.health += 0.05;
        if (Memory.health > 1)
        {
            Memory.health = 1;
        }
        Memory.energy -= 0.02;
        Memory.hungry += 0.001;
        if (Memory.hungry > 1)
        {
            Memory.hungry = 1;
        }
        Memory.coins += 1;
        Memory.exp += 1;
    }
    public void korm()
    {
        if (Memory.food > 0)
        {
            Memory.food--;
            Memory.hungry += 0.10;
            if (Memory.hungry > 1)
            {
                Memory.hungry = 1;
            }
            Memory.energy += 0.2;
            if (Memory.energy > 1)
            {
                Memory.energy = 1;
            }
        }
    }
    public void lek()
    {
        if (Memory.water > 0)
        {
            Memory.water--;
            Memory.health += 0.40;
            if (Memory.health > 1)
            {
                Memory.health = 1;
            }
        }
    }
    public void pereim(Text name)
    {
        using (var connection = new SqliteConnection("Data Source = D:\\xlam\\рпон\\Pypets.db"))
        {
            connection.Open();
            var command = new SqliteCommand($"Update Pet Set Name = '{name.text}' WHERE IDpet ='{Memory.id}'", connection);
            Memory.name = name.text;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
