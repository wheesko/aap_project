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
            main.MatchesPressed += () => MatchesForm();
            main.ProfilePressed += () => ProfileForm();
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
        public void ProfileForm()
        {

        }
        public void MatchesForm()
        {

        }
    }
}