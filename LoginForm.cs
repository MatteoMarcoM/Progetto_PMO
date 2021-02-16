using PasswordManager.ProxyPattern;
using PasswordManager.StatePattern;
using System;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class LoginForm : Form, IProxy
    {
        public readonly Register registro;
        public ILoginFormState CurrentState { get; set; }   //Proxy SI / NO

        public LoginForm()
        {
            InitializeComponent();
            CurrentState = LFLocked.Instance;   //proprieta' singleton dello stato iniziale (PROXY SI)
            registro = new Register();
        }

        //implementa IProxy
        public void CreaManagerForm(Utente elem)
        {
            Hide();
            string userDBFilePath = registro.CreateDBFileForUser(elem.UserName);
            ManagerForm manager = new ManagerForm(registro.UtentiRegistrati, elem, userDBFilePath);
            manager.ShowDialog();
            Close();
        }

        #region metodi per l'esecuzione della form

        private void TextBox_MouseClick(object sender, MouseEventArgs e)    //reset della TextBox
        {
            if(CurrentState is LFLocked)    //SI Proxy
            {
                TextBox textB = (TextBox)sender;
                textB.Text = "";
            }
        }

        private void LoginB_clicked(object sender, EventArgs e)
        {
            IProxy loadDB;

            if (CurrentState is LFLocked)   //SI Proxy
            {
                //test credenziali
                loadDB = new Proxy(this);
            }
            else    //LFUnlocked => NO Proxy
            {
                loadDB = this;           
            }

            loadDB.CreaManagerForm(registro.defaultLogin);  //NB implementazione in Proxy.cs
        }

        private void RegisterB_clicked(object sender, EventArgs e)
        {
            bool userFound = false;

            if (textBoxUser.Text != "admin")
            {                
                foreach (Utente elem in registro.UtentiRegistrati)
                {
                    if (elem.UserName == textBoxUser.Text)   //utente gia' registrato 
                    {
                        userFound = true;
                    }
                }//foreach

                if (userFound == true)
                {
                    MessageBox.Show("Username not valid!", "Invalid Username", MessageBoxButtons.OK);
                }
                else
                {
                    registro.RegistraUtente(this);
                }                
            }
            else
            {
                MessageBox.Show("Username not valid!", "Invalid Username", MessageBoxButtons.OK);
            }
        }
                
        private void UnregisterB_clicked(object sender, EventArgs e)
        {
            string userFound = null;

            if (textBoxUser.Text != "admin")
            {
                foreach (Utente elem in registro.UtentiRegistrati)
                {
                    if (elem.UserName == textBoxUser.Text)
                    {
                        userFound = elem.UserName;

                        if (elem.Password == textBoxPass.Text)
                        {
                            registro.DeregistraUtente(elem);

                            break;//foreach
                            //altrimenti eccezione lista modificata (invalid operation) riga 101
                        }
                        else
                        {
                            MessageBox.Show("Password not valid!", "Invalid Password", MessageBoxButtons.OK);
                        }
                    }
                }//end foreach
                if (userFound == null)  //l'utente non deve essere eliminato poiche' non e' presente nel DB
                {
                    MessageBox.Show("Username not present in the DataBase!", "Invalid Username", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Username not valid!", "Invalid Username", MessageBoxButtons.OK);
            }
        }

        private void ChangeB_clicked(object sender, EventArgs e)
        {
            CurrentState.UpdateState(this);

            //rendi ReadOnly le textBox se la form è LFUnlocked e le sblocca altrimenti
            textBoxUser.ReadOnly = !textBoxUser.ReadOnly;
            textBoxPass.ReadOnly = !textBoxPass.ReadOnly;
            //col pulsante logout (nuova form) i valori readonly vengono resettati a false in automatico
        }
        #endregion
    }
}
