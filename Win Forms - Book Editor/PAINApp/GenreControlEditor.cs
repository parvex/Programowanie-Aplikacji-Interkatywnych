using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace PAINApp
{
    public class GenreControlEditor : UITypeEditor
    {
        private List<Bitmap> GenreImages;
        private Genre currentGenre;

        public GenreControlEditor()
        {
            GenreImages = new List<Bitmap>();
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\desktop\\PAINApp\\PAINApp\\poetry.png"));
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\desktop\\PAINApp\\PAINApp\\castle.png"));
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\desktop\\PAINApp\\PAINApp\\gun.png"));
            currentGenre = Genre.Poetry;

        }
        public override void PaintValue(PaintValueEventArgs e)
        { 
            float width = e.Bounds.Width;
            float height = e.Bounds.Height;

            
            currentGenre = (Genre)e.Value;

            var image = GenreImages[(int)currentGenre];
            float scale = Math.Min(width / image.Width, height / image.Height);

            var bmp = new Bitmap((int)width, (int)height);

            var scaleWidth = (int)(image.Width * scale);
            var scaleHeight = (int)(image.Height * scale);

            e.Graphics.DrawImage(image, ((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight);
        }
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext
        context)
        { return true; }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc =
            (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                GenreControl genreControl = new GenreControl((string)value);
                edSvc.DropDownControl(genreControl);

                return genreControl.CurrentGenre;
            }
            return value;
        }
    }
}
