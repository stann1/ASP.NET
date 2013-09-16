using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.VisitorImgCounter
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["visitors"] == null)
            {
                Session["visitors"] = 1;
            }
            else
            {
                var num = (int)Session["visitors"];
                Session["visitors"] = num + 1;
            }


            Bitmap generatedImage = new Bitmap(110, 110);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    gr.FillRectangle(Brushes.BlueViolet, 0, 0, 200, 200);

                    gr.DrawString(((int)Session["visitors"]).ToString(),
                        new Font("Comic Sans MS", 25),
                        new SolidBrush(Color.AntiqueWhite),
                         new PointF(20, 20));


                    // Set response header and write the image into response stream
                    Response.ContentType = "image/jpeg";

                    //Response.AppendHeader("Content-Disposition",
                    //    "attachment; filename=\"Financial-Report-April-2013.gif\"");

                    generatedImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }

        }
    }
}