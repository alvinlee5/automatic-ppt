﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            m_dbManager = databaseManager;
        }

        private void InitializePowerpointObjects()
        {
            m_pptApplication = new PowerPoint.Application();
            m_pptPresCollection = m_pptApplication.Presentations;
            // Argument to choose whether the ppt is visible or not
            m_pptPres = m_pptPresCollection.Add(Office.MsoTriState.msoFalse);
            m_pptSlides = m_pptPres.Slides;
        }

        public void CreateSlide(string slideTitle, string slideBody)
        {
            if (slideBody.Contains("\r\n\r\n") || String.IsNullOrEmpty(slideBody) || slideBody == "\r\n")
            {
                return;
            }
            float slideWidth = m_pptPres.PageSetup.SlideWidth;
            float lyricsShapeWidth = 900;
            float lyricsShapeLeft = slideWidth * 0.5f - lyricsShapeWidth * 0.5f;
            int textBoxHeight = 0;

            PowerPoint.Slide pptSlide = m_pptSlides.Add(m_pptSlides.Count + 1,
                PowerPoint.PpSlideLayout.ppLayoutBlank);
            PowerPoint.Shapes pptShapes = pptSlide.Shapes;

            pptShapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal,
                /*left*/50, /*top*/50, /*width*/700, /*height*/textBoxHeight);

            PowerPoint.Shape titleTextbox = pptShapes[1];
            WriteToTextbox(slideTitle, titleTextbox, 50);

            pptShapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 
                lyricsShapeLeft, 150, lyricsShapeWidth, textBoxHeight);

            PowerPoint.Shape lyricsTextbox = pptShapes[2];
            WriteToLyricsTextbox(slideBody, lyricsTextbox, 35);
        }

        private void WriteToTextbox(string text, PowerPoint.Shape textBox, int fontSize)
        {
            PowerPoint.TextFrame pptTextFrame = textBox.TextFrame;
            PowerPoint.TextRange pptTextRange = pptTextFrame.TextRange;
            pptTextRange.Text = text;
            pptTextRange.Font.Size = fontSize;
        }
        private void WriteToLyricsTextbox(string text, PowerPoint.Shape textBox, int fontSize)
        {
            PowerPoint.TextFrame pptTextFrame = textBox.TextFrame;
            PowerPoint.TextRange pptTextRange = pptTextFrame.TextRange;
            pptTextRange.Text = text;
            pptTextRange.Font.Size = fontSize;
            pptTextRange.ParagraphFormat.Alignment = PowerPoint.PpParagraphAlignment.ppAlignCenter;
        }

        public void SavePowerPoint(string fileName)
        {
            m_pptPres.SaveAs(fileName, PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLPresentation,
                Office.MsoTriState.msoTriStateMixed);
            m_pptPres.Close();
            m_pptApplication.Quit();

            // TODO: Need to figure out how to close ppt application programmatically
            Marshal.FinalReleaseComObject(m_pptApplication);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void AddSongsToPowerPoint(ListBox.ObjectCollection songList)
        {
            InitializePowerpointObjects();
            foreach (ListBoxItem song in songList)
            {
                string lyrics = m_dbManager.GetSongLyrics(song.ValueMember);
                string songTitle = song.DisplayMember;
                if (song.DisplayMember.Contains("-"))
                {
                    songTitle = songTitle.Substring(0, songTitle.IndexOf("-") - 1);
                }
                int currVerseIndex = 0;
                Console.WriteLine("Adding Song: " + song.DisplayMember);
                for (int i = lyrics.IndexOf("\r\n\r\n"); i > -1; i = lyrics.IndexOf("\r\n\r\n", i + 4))
                {
                    if (lyrics.Substring(currVerseIndex, i - currVerseIndex).IndexOf("\r\n", 0) == 0)
                    {
                        // If user accidentally adds extra new line before the next verse, we will
                        // correct the index so the new line doesn't appear in the slides
                        currVerseIndex = currVerseIndex + 2;
                    }
                    CreateSlide(songTitle, lyrics.Substring(currVerseIndex, i - currVerseIndex));
                    // +4 because a newline is represented by \r\n\r\n. Sort of hacky, and
                    // will cause problems if a newline is not exactly \r\n\r\n.
                    currVerseIndex = i + 4;
                }
                // Add the last verse, since there will not be a newline (or shouldn't be)
                // after the last verse. 
                //TODO: Need to account for situations where there
                // is a newline due to user adding it.
                CreateSlide(songTitle, lyrics.Substring(currVerseIndex));
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
