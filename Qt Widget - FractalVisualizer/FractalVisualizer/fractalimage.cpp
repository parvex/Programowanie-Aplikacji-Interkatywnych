#include "fractalimage.h"

//static fields initialization
unsigned FractalImage::bmpXmax = 1280;
unsigned FractalImage::bmpYmax = 740;
unsigned FractalImage::iter_max = 200;
unsigned FractalImage::zoom = 2;

FractalImage::FractalImage(): fractal(bmpXmax, bmpYmax, QImage::Format_RGB16)
{
    width = xmax - xmin;
    double ratio = (double) bmpYmax/bmpXmax;
    double halfHeight = width*ratio/2;
    ymax = halfHeight;
    ymin = -halfHeight;
    height = halfHeight*2;

    generateColors();
    generateBitmap();
}


FractalImage::FractalImage(uint w, uint h, uint fractalTypeIndex, uint colorTypeIndex, double cReal, double cImaginary, uint iterations): fractal(w, h, QImage::Format_RGB16),
    fractalTypeIndex(fractalTypeIndex), colorTypeIndex(colorTypeIndex), cReal(cReal), cImaginary(cImaginary)
{
    bmpXmax = w;
    bmpYmax = h;
    iter_max = iterations;
    width = xmax - xmin;
    double ratio = (double) bmpYmax/bmpXmax;
    double halfHeight = width*ratio/2;
    ymax = halfHeight;
    ymin = -halfHeight;
    height = halfHeight*2;

    generateColors();
    generateBitmap();
}

FractalImage::FractalImage(FractalImage& im) : fractal(bmpXmax, bmpYmax, QImage::Format_RGB16)
{
    xmin = im.xmin;
    xmax = im.xmax;
    ymin = im.ymin;
    ymax = im.ymax;
    height = im.height;
    width = im.width;
    cReal = im.cReal;
    cImaginary = im.cImaginary;
    fractalTypeIndex = im.fractalTypeIndex;
    colorTypeIndex = im.colorTypeIndex;
    fractal = im.fractal.copy();

    generateColors();
}

FractalImage::~FractalImage()
{
}

//picking random colors for every iter break numbers
void FractalImage::generateColors()
{
    for(uint i = 0; i < iter_max; i++)
    {
        colors.push_back(IntToColor(i));
    }
    colors.push_back(QColor(0,0,0));
}

//gradient color generator from 0 to iter_max
QColor FractalImage::IntToColor(uint i)
{
    QColor* colorz;
    if(colorTypeIndex == 0)
    {
        colorz = new QColor[8] { QColor(0,0,0), QColor(0,0,255), QColor(0,255,255), QColor(0,128,0), QColor(189,183,107), QColor(255,165,0), QColor(255,0,0), QColor(255,255,0) };
    }
    else
    {
        colorz = new QColor[8] {QColor(255,255,0), QColor(255,0,0), QColor(255,165,0), QColor(189,183,107),  QColor(0,128,0), QColor(0,255,255), QColor(0,0,255), QColor(0,0,0) };
    }

    float scaled = (float)(i) / iter_max * 7;
    QColor color0 = colorz[(int)scaled];
    QColor color1 = colorz[(int)scaled + 1];
    float fraction = scaled - (int)scaled;
    //cast?
    int resultR = ((1 - fraction) * (float)color0.red() + fraction * (float)color1.red());
    int resultG = ((1 - fraction) * (float)color0.green() + fraction * (float)color1.green());
    int resultB = ((1 - fraction) * (float)color0.blue() + fraction * (float)color1.blue());

    delete colorz;
    return QColor(resultR, resultG, resultB);
}

void FractalImage::generateBitmap()
{
    if(fractalTypeIndex == 0)
    {
        for (uint x =0; x < bmpXmax; ++x)
            for (uint y = 0; y < bmpYmax; ++y)
            {
                double Xtemp;
                DecPoint point = scale(x, y);
                DecPoint z;
                uint iter;
                for (iter = 0; iter < iter_max && z.Abs2() < 4; ++iter)
                {
                    Xtemp = z.X;
                    z.X = z.X * z.X - z.Y * z.Y + point.X;
                    z.Y = 2 * Xtemp * z.Y + point.Y;
                }

                fractal.setPixelColor(x, y, colors[iter]);
            }
    }
    else if (fractalTypeIndex == 1)
    {
        for (uint x =0; x < bmpXmax; ++x)
        {
            for (uint y = 0; y < bmpYmax; ++y)
            {
                double Xtemp;
                DecPoint point = scale(x, y);
                DecPoint z = point;
                uint iter;
                for (iter = 0; iter < iter_max && z.Abs2() < 4; ++iter)
                {
                    Xtemp = z.X;
                    z.X = z.X * z.X - z.Y * z.Y + cReal;
                    z.Y = 2 * Xtemp * z.Y + cImaginary;
                }

                fractal.setPixelColor(x, y, colors[iter]);
            }
        }
    }
}

//scales pixel to fit in mandelbrott domain
DecPoint FractalImage::scale(double x, double y)
{
    return DecPoint( ((double)x / bmpXmax) * width + xmin, ((double)y / bmpYmax) * height + ymin);
}

QImage& FractalImage::getBitmap()
{
    return fractal;
}

void FractalImage::centerAndZoom(double x, double y)
{
    DecPoint center = scale((double)x, (double)y);
    height = height / zoom;
    width = width / zoom;
    xmin = center.X - width / 2;
    xmax = center.X + width / 2;
    ymin = center.Y - height / 2;
    ymax = center.Y + height / 2;
    generateBitmap();
}
