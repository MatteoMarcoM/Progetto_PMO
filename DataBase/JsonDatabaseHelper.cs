using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PasswordManager.DataBase
{
    internal class JsonDatabaseHelper
    {
        //codice prof
        public static List<Utente> GetData(string dataBaseFilePath) 
        {
            List<Utente> items;

            try
            {
                JArray jsonArray = JArray.Parse(File.ReadAllText(dataBaseFilePath));
                items = jsonArray.ToObject<List<Utente>>();//lista di record

                //Decrypt data
                foreach (Utente elem in items)
                {
                    elem.Password = CypherHelper.Decode(elem.Password);
                }
            }
            catch (FileNotFoundException e)
            {
                items = new List<Utente>();
                MessageBox.Show("Data Base NOT found at " + dataBaseFilePath + "\n" + e, "File Not Found", MessageBoxButtons.OK);
            }
            catch //eccezione generica
            {
                items = new List<Utente>();
            }

            return items;
        }

        public static void SaveData(List<Utente> items, string dataBaseFilePath) //sovrascrive DB
        {
            JArray itemsArray = new JArray(                                 
                                           items.Select(i => new JObject{   //proprieta' di Utente
                                                                            { "Username", i.UserName },     
                                                                            { "Password", CypherHelper.Encode(i.Password)}
                                                                        }
                                                        )
                                           );

            try 
            {
                File.WriteAllText(dataBaseFilePath, itemsArray.ToString());
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("File not found at " + dataBaseFilePath+"\n"+e, "Error", MessageBoxButtons.OK);
            }
        }
    }
}