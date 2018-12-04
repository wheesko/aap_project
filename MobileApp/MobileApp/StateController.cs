using MobileApp.Models;
using MobileApp.Views;

namespace MobileApp
{
    public class StateController
    {
        public App program;

        public LoginController logger;

        public StateController(App prog)
        {
            program = prog;
            LoginPage log = new LoginPage();
            logger = new LoginController(log);
            StateController state = new StateController(log);
            program.MainPage = log;
        }
        public StateController(LoginPage log)
        {
            log.SignIn += (MainUser) => MainForm(MainUser);
            log.Register += () => RegisterForm();
        }
        public StateController(RegistrationPage reg)
        {
            reg.Btn_Back += () => LoginForm();
        }
        public StateController(MainPage main)
        {
        
          main.MatchesPressed += (MainUser) => MatchesForm(MainUser);
          main.ProfilePressed += (MainUser) => ProfileForm(MainUser);
        }
        public StateController(ProfileForm prof)
        {
            prof.Back += (MainUser) => MainForm(MainUser);

        }
        public StateController(MatchesPage match)
        {
            match.Back += (MainUser) => MainForm(MainUser);
        }
        public void RegisterForm()
        {
            program = App.instance;
            RegistrationPage register = new RegistrationPage();
            RegisterController controller = new RegisterController(register);
            StateController reg = new StateController(register);
            program.MainPage = register;

        }
        public void LoginForm()
        {
            program = App.instance;
            LoginPage login = new LoginPage();
            LoginController log = new LoginController(login);
            StateController state = new StateController(login);
            program.MainPage = login;
        }
        public void MainForm(User MainUser)
        {
            program = App.instance;
            MainPage main = new MainPage();
            MainController mainer = new MainController(main,MainUser);
            StateController state = new StateController(main);
            program.MainPage = main;
        }
        public void ProfileForm(User MainUser)
        {
            program = App.instance;
            ProfileForm prof = new ProfileForm();
            ProfileController mainer = new ProfileController(prof, MainUser);
            StateController state = new StateController(prof);
            program.MainPage = prof;
        }
        public void MatchesForm(User MainUser)
        {
            program = App.instance;
            MatchesPage match = new MatchesPage();
            MatchesController mainer = new MatchesController(match, MainUser);
            StateController state = new StateController(match);
            program.MainPage = match;
        }
    }
}