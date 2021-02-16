using System.Windows.Forms;

namespace PasswordManager.ProxyPattern
{
    internal class Proxy : IProxy
    {
        private readonly LoginForm loginFormInstance;

        public Proxy(LoginForm lf)
        {
            loginFormInstance = lf;
        }

        //implemeta IProxy
        public void CreaManagerForm(Utente e)   //NB parametro <e> non utilizzato qui (registro.defaultLogin)
        {
            bool userFound = false;
            string user = loginFormInstance.textBoxUser.Text;

            foreach (Utente elem in loginFormInstance.registro.UtentiRegistrati)
            {                
                if (elem.UserName == user && user != "admin")   //username default non valido
                {
                    userFound = true;

                    if (elem.Password == loginFormInstance.textBoxPass.Text)
                    {
                        loginFormInstance.registro.Login = new Utente(elem.UserName, elem.Password);
                        loginFormInstance.CreaManagerForm(elem);   //NB parametro <elem> in LoginForm.CreaManagerForm()                     
                    }
                    else
                    {
                        MessageBox.Show("Password not valid!", "Invalid Password", MessageBoxButtons.OK);
                    }
                }
            }//end foreach

            if (userFound == false)     //se user = "admin" si esegue qua
            {
                MessageBox.Show("Username not valid!", "Invalid Username", MessageBoxButtons.OK);
            }
        }
    }
}
