namespace PasswordManager.StatePattern
{
    public class LFUnlocked : ILoginFormState
    {
        //singleton
        private static readonly LFUnlocked instance = new LFUnlocked();
        private LFUnlocked() { }
        public static LFUnlocked Instance => instance;

        public void UpdateState(LoginForm context)
        {
            context.textBoxUser.Text = "Pippo1234";
            context.textBoxPass.Text = "Master Password";
            context.textBoxMode.Text = "USERNAME & PASSWORD";
            
            context.CurrentState = LFLocked.Instance;
        }
    }
}
