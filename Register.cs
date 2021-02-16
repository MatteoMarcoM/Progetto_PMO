using PasswordManager.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PasswordManager
{
    public class Register
    {
        private const string USERS_REGISTER_FILE_NAME = "UserRegisterDB";

        public readonly Utente defaultLogin;                    //utente di default (senza Proxy)
        public string DBFolderPath { get; set; }                //Folder che contiene tutti i DB
        public string UserRegisterDBFilePath { get; set; }      //creato in CaricaDBUtentiRegistrati()
        public Utente Login { private get; set; }
        public List<Utente> UtentiRegistrati { get; set; }

        public Register()
        {
            DBFolderPath = CreateDefaultDBDir();
            UtentiRegistrati = CaricaDBUtentiRegistrati();
            defaultLogin = InizializeDefaultAccount();
        }

        #region metodi di utilita' per la LoginForm
        private string CreateDefaultDBDir()
        {
            //MS doc
            //il folder di default e' C:\\Users\[utente corrente]\PasswordManagerDB
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);//C:\\Users\[utente corrente]
            DBFolderPath = userProfilePath + "\\PasswordManagerDB";// il carattere \\ equivale a \

            try
            {
                Directory.CreateDirectory(DBFolderPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("FATAL ERROR \nImpossible create program's DataBase folder: " + DBFolderPath + "\n" + e, "Fatal Error", MessageBoxButtons.OK);
            }

            return DBFolderPath;
        }

        private List<Utente> CaricaDBUtentiRegistrati()
        {
            UserRegisterDBFilePath = DBFolderPath + "\\" + USERS_REGISTER_FILE_NAME + ".txt";   //unico

            if (!File.Exists(UserRegisterDBFilePath))//al primo utilizzo dell'app si esegue qua
            {
                try
                {
                    FileStream fs = File.Create(UserRegisterDBFilePath);
                    fs.Close();//altrimenti rimane aperto e non può essere acceduto da altri processi
                }
                catch (Exception e)
                {
                    MessageBox.Show("FATAL ERROR \nImpossible create users' register file: " + UserRegisterDBFilePath + "\n" + e, "Fatal Error", MessageBoxButtons.OK);
                }

                UtentiRegistrati = new List<Utente>();
            }
            else
            {
                UtentiRegistrati = JsonDatabaseHelper.GetData(UserRegisterDBFilePath);
            }
            return UtentiRegistrati;
        }

        private Utente InizializeDefaultAccount()
        {
            Utente defLogin = new Utente("admin", "admin");

            //se utente admin gia' presente viene rimosso
            foreach (Utente elem in UtentiRegistrati)
            {
                if (elem.UserName == defLogin.UserName)
                {
                    UtentiRegistrati.Remove(elem);
                    SalvaDBRegistroUtenti();
                    break;
                }
            }
            
            return defLogin;
        }

        public string CreateDBFileForUser(string nomeUtente)
        {
            string filePath = DBFolderPath + "\\DB" + nomeUtente + ".txt";

            if (!File.Exists(filePath))
            {
                try
                {
                    FileStream fs = File.Create(filePath);
                    fs.Close();//altrimenti rimane aperto e non può essere acceduto da altri processi
                }
                catch (Exception e)
                {
                    MessageBox.Show("FATAL ERROR \nImpossible create user DataBase: " + filePath + "\n" + e, "Fatal Error", MessageBoxButtons.OK);
                }

                UtentiRegistrati = new List<Utente>();
            }
            else
            {
                UtentiRegistrati = JsonDatabaseHelper.GetData(filePath);
            }
            return filePath;
        }

        public void RegistraUtente(LoginForm lf)
        {
            UtentiRegistrati.Add(new Utente(lf.textBoxUser.Text, lf.textBoxPass.Text));
            MessageBox.Show("User successfully Registered:\nUsername: " + lf.textBoxUser.Text + "\nPassword: " + lf.textBoxPass.Text, "Registration Completed", MessageBoxButtons.OK);
            SalvaDBRegistroUtenti();
        }

        public void DeregistraUtente(Utente elem)
        {
            UtentiRegistrati.Remove(elem);

            SalvaDBRegistroUtenti();//aggiorna il DB

            //elimino il DB file
            string dBFilePath = DBFolderPath + "\\DB" + elem.UserName + ".txt";
            try
            {
                File.Delete(dBFilePath);
            }
            catch
            {
                MessageBox.Show("Error in deleting file at \n"+dBFilePath, "Delete error", MessageBoxButtons.OK);
            }
            
            MessageBox.Show("Username Unregistered!", "Unregistration complete", MessageBoxButtons.OK);
        }

        public void SalvaDBRegistroUtenti()     //sovrascrive il registro aggiornandolo
        {
                JsonDatabaseHelper.SaveData(UtentiRegistrati, UserRegisterDBFilePath);
        }
        #endregion
    }
}
