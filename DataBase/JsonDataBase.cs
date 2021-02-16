using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManager.DataBase
{
    public class JsonDataBase
    {
        //attributi contenuti nel DataBase
        public readonly string dataBaseFilePath;
        public List<Utente> UtentiRegistrati { private get; set; }
        public List<Utente> PasswordDataBase { get; set; }
        public Utente CredenzialiLogin { private get; set; }

        public JsonDataBase(string dBFilePath, Utente login)
        {
            dataBaseFilePath = dBFilePath;
            CredenzialiLogin = login;
            PasswordDataBase = JsonDatabaseHelper.GetData(dataBaseFilePath);
        }

        public void LoadListViewFromDB(ListView vista)
        {
            foreach (Utente elem in PasswordDataBase)
            {
                //ListView Control Update from DB
                ListViewItem item = new ListViewItem(elem.UserName);
                item.SubItems.Add(elem.Password);
                vista.Items.Add(item);
            }
        }
    }
}
