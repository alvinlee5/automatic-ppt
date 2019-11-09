using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace AutoPoint
{
    public class PowerPointManager
    {
        int m_currNumofSlides;
        PowerPoint.Application m_pptApplication;
        PowerPoint.Presentations m_pptPresCollection;
        PowerPoint.Presentation m_pptPres;
        PowerPoint.Slides m_pptSlides;

        public PowerPointManager()
        {
            m_pptApplication = new PowerPoint.Application();
            m_pptPresCollection = m_pptApplication.Presentations;
            // Argument to choose whether the ppt is visible or not
            m_pptPres = m_pptPresCollection.Add(Office.MsoTriState.msoFalse);
            m_pptSlides = m_pptPres.Slides;
        }

        public void CreateSlide(string slideTitle, string slideBody)
        {
            PowerPoint.Slide pptSlide = m_pptSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutText);
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
