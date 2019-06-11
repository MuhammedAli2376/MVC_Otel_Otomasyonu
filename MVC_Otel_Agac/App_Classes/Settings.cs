using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVC_Otel_Agac.App_Classes
{
    public class Settings
    {
        public static Size OtelOrtaBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["OtelOrtaWidth"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["OtelOrtaHeight"]);
                return sz;
            }
        }
        public static Size OtelBuyukBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["OtelBuyukWidth"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["OtelBuyukHeight"]);
                return sz;
            }
        }
        public static Size SliderResimBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["SliderWidth"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["SilderHeight"]);
                return sz;
            }
        }
    }
}
