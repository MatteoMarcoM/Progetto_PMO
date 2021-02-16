namespace PasswordManager.StatePattern
{
    public class LFLocked : ILoginFormState
    {
        //singleton
        private static readonly LFLocked instance = new LFLocked();
        private LFLocked() { }
        public static LFLocked Instance => instance;

        public void UpdateState(LoginForm context)
        {
            context.textBoxUser.Text = "admin";
            context.textBoxPass.Text = "admin";
            context.textBoxMode.Text = "DEFAULT";
            
            context.CurrentState = LFUnlocked.Instance;
        }
    }
}
