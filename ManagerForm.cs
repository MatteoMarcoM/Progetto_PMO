using PasswordManager.DataBase;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class ManagerForm : Form
    {
        private readonly JsonDataBase dataBase;

        public ManagerForm(List<Utente> registroUtenti, Utente login, string dBFilePath)
        {
            InitializeComponent();
            dataBase = new JsonDataBase(dBFilePath, login);
            dataBase.LoadListViewFromDB(listViewUserPass);
            dataBase.UtentiRegistrati = registroUtenti;
            textBoxUserLogged.Text = login.UserName;
        }

        #region metodi per i componenti della form

        private void TextBox_MouseClick(object sender, MouseEventArgs e)    //reset della TextBox
        {
            TextBox textB = (TextBox)sender;
            textB.Text = "";
        }

        private void AddB_clicked(object sender, EventArgs e)
        {
            bool utenteGiaRegistrato = false;

            foreach(Utente elem in dataBase.PasswordDataBase)
            {
                if (elem.UserName == textBoxUser.Text)
                {
                    utenteGiaRegistrato = true;
                }
            }

            if(utenteGiaRegistrato == false)
            {
                dataBase.PasswordDataBase.Add(new Utente(textBoxUser.Text, textBoxPass.Text));

                //ListView Control
                ListViewItem item = new ListViewItem(textBoxUser.Text);
                item.SubItems.Add(textBoxPass.Text);
                listViewUserPass.Items.Add(item);

                MessageBox.Show("Account successfully Registered in the DataBase:\nUsername: " + textBoxUser.Text + "\nPassword: " + textBoxPass.Text, "Account Registration Completed", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Username not valid! This Username is already present in the Data Base", "Invalid Username", MessageBoxButtons.OK);
            }       
        }

        private void RemoveB_clicked(object sender, EventArgs e)
        {
            if (listViewUserPass.Items.Count > 0)
            {
                try
                {
                    string user = listViewUserPass.SelectedItems[0]     //riga 0    -> record selezionato tramite mouse
                                                  .SubItems[0]          //colonna 0 -> Username
                                                  .Text.ToString();     //Username item come stringa

                    foreach (Utente elem in dataBase.PasswordDataBase)
                    {
                        if (elem.UserName == user)  //unico
                        {
                            dataBase.PasswordDataBase.Remove(elem);
                            break;//foreach: altrimenti eccezione
                        }
                    }

                    //rimuovo l'item dalla listView
                    listViewUserPass.Items.Remove(listViewUserPass.SelectedItems[0]);   //riga 0 (selezionata)
                    MessageBox.Show("Element succesfully Removed!\n" + user, "Element removed", MessageBoxButtons.OK);
                }
                catch(ArgumentOutOfRangeException)    //elemento non selezionato
                {
                    MessageBox.Show("No element selected!", "Element unselected", MessageBoxButtons.OK);
                }                            
            }
        }

        private void SaveB_clicked(object sender, EventArgs e)
        {
            JsonDatabaseHelper.SaveData(dataBase.PasswordDataBase, dataBase.dataBaseFilePath);
        }

        private void GenerateB_clicked(object sender, MouseEventArgs e)
        {
            string caratteriAmmessi = "abcdefghijklmnopqrstuvwxyz" +
                                      "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                                      "0123456789" +
                                      "!?:-_@#*%&$£";
            
            Random rnd = new Random();
            string str = "";

            if(int.TryParse(textBoxPassLength.Text, out int length))
            {
                if (length <= textBoxPassLength.MaxLength)
                {
                    for (int i = 0; i < length; i++)
                    {
                        str += caratteriAmmessi[rnd.Next(caratteriAmmessi.Length)];
                    }
                }
                else
                {
                    MessageBox.Show("Max Length: " + textBoxPassLength.MaxLength, "Password must be shorter", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("The password's length format in NOT correct!", "Format Error", MessageBoxButtons.OK);
            }

            textBoxRandPass.Text = str;
        }

        private void SearchB_clicked(object sender, EventArgs e)
        {
            bool userFound = false;

            foreach (Utente elem in dataBase.PasswordDataBase)
            {
                if (elem.UserName == textBoxUserSearch.Text)
                {
                    textBoxPassSearch.Text = elem.Password;
                    userFound = true;   //lo Username e' unico se presente: AddB_clicked()
                }
            }

            if (userFound == false)
            {
                textBoxPassSearch.Text = "";
                MessageBox.Show("The Username: "+textBoxUserSearch.Text+" is NOT present in the DataBase", "User Not Found", MessageBoxButtons.OK);
            }
        }

        private void LogoutB_clicked(object sender, MouseEventArgs e)
        {
            SaveB_clicked(null, null);//salva il DB
            
            Hide();
            //mostrare una Login Form anche nuova (le informazioni sono gia' salvate su file in locale)
            LoginForm returnToLogin = new LoginForm();
            returnToLogin.ShowDialog();//altrimenti eccezione
            Close();
        }
        #endregion
    }
}
