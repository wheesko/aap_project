using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DateSeer
{
    internal class OptionsController
    {
        Thread th;
        private User MainUser;
        private Options profile;
        private Main mainpage;
        public OptionsController(User mainUser,Options e)
        {
            this.MainUser = mainUser;
            this.profile = e;
            Option_Load();
            profile.Upload += () => UploadEV();
            profile.Exit += () => Exit();
            profile.Back += () => Back();
        }

        private void Back()
        {
            profile.Dispose();
            mainpage = new Main();
            MainController matches = new MainController(MainUser, mainpage);
            th = new Thread(OpenMain);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenMain()
        {
            Application.Run(mainpage);
        }

        private void Exit()
        {
            Application.Exit();
        }

        private void UploadEV()
        {
            Upload photo = new Upload();
            ChangeDatabase change = new ChangeDatabase(photo.getPathR(), MainUser);
            MainUser.setImage(photo.getPathR());
            Option_Load();
        }

        private void Option_Load()
        {
            profile.UserName.Text = MainUser.name;
            string PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            PathR = Path.Combine(PathR, "Resources");
            PathR = Path.Combine(PathR, "DefaultAccountPic");
            if (MainUser.getImage() == "")
            {

                if (MainUser.gender == 1)

                {

                    Image image = Image.FromFile(PathR + @"\male.png");
                    profile.pictureBox1.Image = image;

                }
                else
                {
                    Image image = Image.FromFile(PathR + @"\female.jpg");
                    profile.pictureBox1.Image = image;

                }

            }
            else
            {
                try
                {
                    Image image = Image.FromFile(MainUser.getImage());
                    profile.pictureBox1.Image = image;
                }
                catch (Exception ex) { }

                    
            }
      }
    }
}