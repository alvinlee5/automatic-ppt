using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Data.SQLite;

namespace AutoPoint
{
    public partial class Form1 : Form
    {
        private DatabaseManager m_dbManager;
        private FormEnterSong m_formEnterSong;
        public Form1()
        {
            InitializeComponent();
            m_dbManager = new DatabaseManager();
            m_dbManager.SetConnection();
            m_dbManager.CreateTable();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            PowerPoint.Application pptApplication = new PowerPoint.Application();
            
            // invisible by default
            //pptApplication.Visible = Office.MsoTriState.msoTrue;   

            PowerPoint.Presentations pptPres = pptApplication.Presentations;
            PowerPoint.Presentation pres = pptPres.Add(Office.MsoTriState.msoFalse);
            PowerPoint.Slides pptSlides = pres.Slides;
            PowerPoint.Slide pptSlide = pptSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);
            PowerPoint.Shapes pptShapes = pptSlide.Shapes;
            pptShapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 100, 100);
            PowerPoint.Shape pptShape = pptShapes[1];
            PowerPoint.TextFrame pptTextFrame = pptShape.TextFrame;
            PowerPoint.TextRange pptTextRange = pptTextFrame.TextRange;
            pptTextRange.Text = "Test Text";

            string fileName = "C:/Users/Alvin/Desktop/sample.pptx";
            pres.SaveAs(fileName, PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Office.MsoTriState.msoTriStateMixed);
            pres.Close();
            pptApplication.Quit();
            // TODO: Need to figure out how to close ppt application programmatically
            Marshal.FinalReleaseComObject(pptApplication);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            m_dbManager.Read();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            m_formEnterSong = new FormEnterSong(m_dbManager);
            m_formEnterSong.Show();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
