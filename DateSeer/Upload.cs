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
                    string iName = ofd.SafeFileName;   // <---
                    string filepath = ofd.FileName;    // <---
                  //  File.Copy(filepath, appPath + iName); // <---
                 //   picProduct.Image = new Bitmap(ofd.OpenFile());
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
             //   opFile.Dispose();
            }
        }
       
        }
    }
}

