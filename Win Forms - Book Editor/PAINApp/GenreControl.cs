using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAINApp
{
    public partial class GenreControl : UserControl
    {
        private List<Bitmap> GenreImages;
        public event Action<string> genreChangeEvent;
        private Genre currentGenre;

        [Editor(typeof(GenreControlEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Genre control")]
        [Browsable(true)]
        public Genre CurrentGenre
        {
            get { return currentGenre;}
            set
            {
                if ((int)value < 0 || (int)value > 2)
                    currentGenre = Genre.Poetry;
                currentGenre = value;
                Invalidate();
                genreChangeEvent?.Invoke(currentGenre.ToString());
            }
        }

        public GenreControl()
        {
            InitializeComponent();
            GenreImages = new List<Bitmap>();
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\Desktop\\PAINApp\\PAINApp\\poetry.png"));
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\Desktop\\PAINApp\\PAINApp\\castle.png"));
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\Desktop\\PAINApp\\PAINApp\\gun.png"));
            currentGenre = Genre.Poetry;
        }

        public GenreControl(string value)
        {
            InitializeComponent();
            GenreImages = new List<Bitmap>();
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\Desktop\\PAINApp\\PAINApp\\poetry.png"));
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\Desktop\\PAINApp\\PAINApp\\castle.png"));
            GenreImages.Add(new Bitmap("C:\\Users\\grebacz\\Desktop\\PAINApp\\PAINApp\\gun.png"));
            Enum.TryParse(value, false, out Genre result);
            if (!Enum.IsDefined(typeof(Genre), result))
                currentGenre = Genre.Poetry;
            else
                currentGenre = result;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            float width = Size.Width;
            float height = Size.Height;
            var image = GenreImages[(int)currentGenre];
            float scale = Math.Min(width / image.Width, height / image.Height);

            var bmp = new Bitmap((int)width, (int)height);

            var scaleWidth = (int)(image.Width * scale);
            var scaleHeight = (int)(image.Height * scale);

            e.Graphics.DrawImage(image, ((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight);
        }

        protected override void OnClick(EventArgs e)
        {
            currentGenre = (Genre)(((int)currentGenre + 1) % 3);
            genreChangeEvent?.Invoke(currentGenre.ToString());
            Invalidate();
        }

        private void GenreControlLoad(object sender, EventArgs e)
        {
            genreChangeEvent?.Invoke(currentGenre.ToString());
        }
    }
}
