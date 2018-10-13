using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    class Upload
    {
        public string PathR;
        public Upload()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter ="Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +

        "All files (*.*)|*.*";
            ofd.Title = "Select Photo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  
                    PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    PathR = Path.Combine(PathR, "Resources");
                    PathR = Path.Combine(PathR, "ProfilePictures");
                 
                
                    File.Copy(ofd.FileName, Path.Combine(PathR, Path.GetFileName(ofd.FileName)),true);
                    PathR = Path.Combine(PathR, Path.GetFileName(ofd.FileName));
                    MessageBox.Show(PathR);
                   

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
             ofd.Dispose();
            }
        }
        public string getPathR()
        {
            return PathR;
        }
       
    }
}


