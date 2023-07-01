using UnityEngine;
using Mono.Data.Sqlite;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;


public class VhodBD : MonoBehaviour
{
    public GameObject err;
    public GameObject panel;
    public GameObject complete;
    [SerializeField] InputField nick;
    [SerializeField] InputField pass;
    public void Vhod()
    {
        
        using (var connection = new SqliteConnection("Data Source = D:\\xlam\\рпон\\Pypets.db"))
        {
            var command = new SqliteCommand("SELECT COUNT(*) FROM User WHERE NickName = @NickName AND Password = @Password", connection);
            
            command.Parameters.AddWithValue("@NickName", Convert.ToString(nick.text));
            command.Parameters.AddWithValue("@Password", Convert.ToString(pass.text));
            connection.Open();
            if (Convert.ToInt32(command.ExecuteScalar()) == 1)
            {
                Debug.Log("Exist");
                Memory.nick = Convert.ToString(nick.text);
                SqliteDataAdapter adapter = new SqliteDataAdapter($"SELECT * FROM User WHERE Password = '{Convert.ToString(pass.text)}'", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                adapter.Dispose();
                DataTable s = dataSet.Tables[0];
                var id = Convert.ToString(s.Rows[0][0]);
                Memory.exp = Convert.ToInt32(s.Rows[0][3]);
                Memory.coins = Convert.ToInt32(s.Rows[0][4]);
                Memory.id = Convert.ToInt32(id);
                var adapter2 = new SqliteDataAdapter($"SELECT * FROM Pet WHERE IDpet = {Memory.id}", connection);
                var d = new DataSet();
                adapter2.Fill(d);
                s = d.Tables[0];
                Memory.energy = Convert.ToDouble(s.Rows[0][1])/100;
                Memory.hungry = Convert.ToDouble(s.Rows[0][2]) / 100;
                Memory.health = Convert.ToDouble(s.Rows[0][3]) / 100;
                Memory.name = Convert.ToString(s.Rows[0][4]);
                var adapter1 = new SqliteDataAdapter($"SELECT * FROM Store WHERE IDStore = {Memory.id}", connection);
                var dd = new DataSet();
                adapter1.Fill(dd);
                s = dd.Tables[0];
                Memory.food = Convert.ToInt32(s.Rows[0][1]);
                Memory.water = Convert.ToInt32(s.Rows[0][2]);
                Play("Pet");
            }
            else
            {
                err.SetActive(true);
                panel.SetActive(true);
            }
            connection.Close();
        }
    }
    public void Zareg()
    {
        Debug.Log(Convert.ToString(nick.text).Length);
        Debug.Log(Convert.ToString(pass.text).Length);
        if (Convert.ToString(nick.text).Length>3  && Convert.ToString(pass.text).Length > 3 && Convert.ToString(nick.text).Length < 15 && Convert.ToString(pass.text).Length < 15)
        {
            using (var connection = new SqliteConnection("Data Source = D:\\xlam\\рпон\\Pypets.db"))
            {
                var command = new SqliteCommand("SELECT COUNT(*) FROM User WHERE NickName = @NickName AND Password = @Password", connection);

                command.Parameters.AddWithValue("@NickName", Convert.ToString(nick.text));
                command.Parameters.AddWithValue("@Password", Convert.ToString(pass.text));
                connection.Open();
                if (Convert.ToInt32(command.ExecuteScalar()) == 1)
                {
                    Debug.Log("Exist");
                    err.SetActive(true);
                }
                else
                {
                    Debug.Log("notExist");
                    command.CommandText = "INSERT INTO User (NickName, Password) VALUES (@NickName, @Password)";
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@NickName", Convert.ToString(nick.text));
                    command.Parameters.AddWithValue("@Password", Convert.ToString(pass.text));
                    var command1 = new SqliteCommand();
                    command1.Connection = connection;
                    command1.CommandText = $"INSERT INTO Pet (Energy, Hunger, Health, Name) VALUES (100, 100,100,@name)";
                    command1.Parameters.AddWithValue("@name", "Py");
                    var command2 = new SqliteCommand();
                    command2.Connection = connection;
                    command2.CommandText = $"INSERT INTO Store (Food, Water) VALUES (3, 3)";
                    //command.Parameters.AddWithValue("@NickName", Convert.ToString(nick.text));
                    //command.Parameters.AddWithValue("@Password", Convert.ToString(pass.text));
                    //SqliteDataAdapter adapter = new SqliteDataAdapter("SELECT * FROM User ORDER BY EXP DESC", connection);

                    //DataSet dataSet = new DataSet();
                    //adapter.Fill(dataSet);
                    //adapter.Dispose();
                    //DataTable s = dataSet.Tables[0];
                    //var idBestPlayer = Convert.ToString(s.Rows[0][1]);
                    //SqliteCommand com = new SqliteCommand($"SELECT NickName FROM User WHERE IDuser = {idBestPlayer}", connection);
                    //string v = com.ExecuteScalar().ToString();
                    command.ExecuteNonQuery();
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    complete.SetActive(true);
                    panel.SetActive(false);
                }
            }
        }
        else
        {
            err.SetActive(true);
        }
    }

    void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
}
