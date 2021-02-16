using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PasswordManager.DataBase
{
    internal class CypherHelper
    {
        //MS Documentation
        private static readonly byte[] additionalEntropy = { 9, 8, 7, 6, 5 };

        public static string Encode(string clearText)
        {
            byte[] encryptedData = null;
                                   
            try
            {
                byte[] data = clearText.Select(
                                               x => (byte)x
                                               ).ToArray();     //stackoverflow

                // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
                // only by the same current user.
                encryptedData = ProtectedData.Protect(data, additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Password's Format is NOT correct! The password will not be saved correctly. DELETE THE RECORD AND TYPE A NEW CORRECT PASSWORD.\n" + e.ToString(),
                                "Invalid Password", MessageBoxButtons.OK);
            }
            catch (CryptographicException e)
            {
                MessageBox.Show("Data was not encrypted. An error occurred.\n"+e.ToString(), "Password Encryption Error", MessageBoxButtons.OK);                
            }

            return (encryptedData != null) ?
                   new string(encryptedData.Select(
                                                   x => (char)x
                                                   ).ToArray()
                              )//da char[] a string
                   : null;     
        }

        //Analogo
        public static string Decode(string cypherText)
        {
            byte[] decryptedData = null;
                        
            try
            {
                byte[] data = cypherText.Select(
                                                x => (byte)x
                                                ).ToArray();    //stackoverflow

                // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
                // only by the same current user.
                decryptedData = ProtectedData.Unprotect(data, additionalEntropy, DataProtectionScope.CurrentUser);//NB
            }
            catch (FormatException e)
            {
                MessageBox.Show("Encryption format is not correct. Password's decryption failed!\n" + e.ToString(), "Password Decription Error", MessageBoxButtons.OK);
            }
            catch (CryptographicException e)
            {
                MessageBox.Show("Data was not decrypted. An error occurred.\n" + e.ToString(), "Decription Error", MessageBoxButtons.OK);
            }

            return (decryptedData != null) ? 
                   new string(decryptedData.Select(
                                                   x => (char)x
                                                   ).ToArray()
                              )
                   : null;
        }
    }
}
