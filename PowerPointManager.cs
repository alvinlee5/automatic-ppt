using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Office = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace AutoPoint
{
    public class PowerPointManager
    {
        PowerPoint.Application m_pptApplication;
        PowerPoint.Presentations m_pptPresCollection;
        PowerPoint.Presentation m_pptPres;
        PowerPoint.Slides m_pptSlides;
        private DatabaseManager m_dbManager;

        public PowerPointManager(DatabaseManager databaseManager)
        {
            m_pptApplication = new PowerPoint.Application();
            m_pptPresCollection = m_pptApplication.Presentations;
            // Argument to choose whether the ppt is visible or not
            m_pptPres = m_pptPresCollection.Add(Office.MsoTriState.msoFalse);
            m_pptSlides = m_pptPres.Slides;
            m_dbManager = databaseManager;
        }

        public void CreateSlide(string slideTitle, string slideBody)
        {
            PowerPoint.Slide pptSlide = m_pptSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);
            PowerPoint.Shapes pptShapes = pptSlide.Shapes;

            pptShapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 50, 50, 100, 100);
            PowerPoint.Shape titleTextbox = pptShapes[1];
            WriteToTextbox(slideTitle, titleTextbox);

            pptShapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 500);
            PowerPoint.Shape lyricsTextbox = pptShapes[2];
            WriteToTextbox(slideBody, lyricsTextbox);
        }

        private void WriteToTextbox(string text, PowerPoint.Shape textBox)
        {
            PowerPoint.TextFrame pptTextFrame = textBox.TextFrame;
            PowerPoint.TextRange pptTextRange = pptTextFrame.TextRange;
            pptTextRange.Text = text;
        }

        public void SavePowerPoint(string fileName)
        {
            m_pptPres.SaveAs(fileName, PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Office.MsoTriState.msoTriStateMixed);
            m_pptPres.Close();
            m_pptApplication.Quit();

            // TODO: Need to figure out how to close ppt application programmatically
            Marshal.FinalReleaseComObject(m_pptApplication);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        public void AddSongToPowerPoint(string songName)
        {
            string lyrics = m_dbManager.GetSongLyrics(songName);
            for (int i = lyrics.IndexOf("\r\n\r\n"); i > -1; i = lyrics.IndexOf("\r\n\r\n", i + 1))
            {
                // For each "newline" index, need to figure out indices to add 
                // to get the actual start of the next line.
                Console.WriteLine("Index of break:" + i);
            }
        }

        public void SetVisibility(bool visible)
        {
            if (visible)
            {
                m_pptApplication.Visible = Office.MsoTriState.msoTrue;
            }
            else
            {
                m_pptApplication.Visible = Office.MsoTriState.msoFalse;
            }            
        }
    }
}
