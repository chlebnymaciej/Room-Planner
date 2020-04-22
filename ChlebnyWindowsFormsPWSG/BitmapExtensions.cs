using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChlebnyWindowsFormsPWSG
{
    // https://stackoverflow.com/questions/2201016/how-to-make-a-system-drawing-image-semitransparent
    public static class BitmapExtensions
    {
        public static Image SetOpacity(this Image image, float opacity)
        {
            if (image == null) return null;
            var colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacity;
            var output = new Bitmap(image.Width, image.Height);

            using (var imageAttributes = new ImageAttributes())
            {
                imageAttributes.SetColorMatrix(
                    colorMatrix,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);
                using (var gfx = Graphics.FromImage(output))
                {
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    gfx.DrawImage(
                        image,
                        new Rectangle(0, 0, image.Width, image.Height),
                        0,
                        0,
                        image.Width,
                        image.Height,
                        GraphicsUnit.Pixel,
                        imageAttributes);
                }
            }
            return output;
        }
    }
}
