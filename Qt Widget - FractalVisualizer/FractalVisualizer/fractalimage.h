#ifndef FRACTALIMAGE_H
#define FRACTALIMAGE_H
#include <iostream>
#include <fstream>
#include <map>
#include <QImage>
#include "bitmap_image.hpp"


class FractalImage
{
    public:
    QImage fractal;
    //size of the image
    static unsigned bmpXmax;
    static unsigned bmpYmax;
    //number of iterations before accepting point
    static unsigned iter_max;
    static unsigned zoom;
    //domain in which mandelbrott set is being tested
    double xmin = -2.2;
    double xmax = 1.2;
    double ymin = -1.7;
    double ymax = 1.7;
    double height;
    double width;
    QColor colors[151];


    class DecPoint
    {
        public:
        DecPoint(): X(0), Y(0) { }
        DecPoint(double x, double y) { X = x;  Y = y; }
        double X;
        double Y;

        double Abs2()
        {
            return X * X + Y * Y;
        }
    };

    FractalImage(): fractal(bmpXmax, bmpYmax, QImage::Format_RGB16)
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

    FractalImage(FractalImage& im) : fractal(bmpXmax, bmpYmax, QImage::Format_RGB16)
    {
        xmin = im.xmin;
        xmax = im.xmax;
        ymin = im.ymin;
        ymax = im.ymax;
        height = im.height;
        width = im.width;
        generateColors();
    }

    //picking random colors for every iter break numbers
    void generateColors()
    {
        for(int i = 0; i < iter_max; i++)
        {
            colors[i] = IntToColor(i);
        }
        colors[iter_max] = QColor(0,0,0);
    }

    //gradient color generator from 0 to iter_max
    static QColor IntToColor(int i)
    {
        QColor colorz[] = { QColor(0,0,0), QColor(0,0,255), QColor(0,255,255), QColor(0,128,0), QColor(189,183,107), QColor(255,165,0), QColor(255,0,0), QColor(255,255,0) };
        float scaled = (float)(i) / iter_max * 7;
        QColor color0 = colorz[(int)scaled];
        QColor color1 = colorz[(int)scaled + 1];
        float fraction = scaled - (int)scaled;
        //cast?
        int resultR = ((1 - fraction) * (float)color0.red() + fraction * (float)color1.red());
        int resultG = ((1 - fraction) * (float)color0.green() + fraction * (float)color1.green());
        int resultB = ((1 - fraction) * (float)color0.blue() + fraction * (float)color1.blue());
        return QColor(resultR, resultG, resultB);
    }

    void generateBitmap()
    {
        for (int x =0; x < bmpXmax; ++x)
            for (int y = 0; y < bmpYmax; ++y)
            {
                double Xtemp;
                DecPoint point = scale(x, y);
                DecPoint z;
                int iter;
                for (iter = 0; iter < iter_max && z.Abs2() < 4; ++iter)
                {
                    Xtemp = z.X;
                    z.X = z.X * z.X - z.Y * z.Y + point.X;
                    z.Y = 2 * Xtemp * z.Y + point.Y;
                }

                fractal.setPixelColor(x, y, colors[iter]);
            }
    }

    //scales pixel to fit in mandelbrott domain
    DecPoint scale(double x, double y)
    {
        return DecPoint( ((double)x / bmpXmax) * width + xmin, ((double)y / bmpYmax) * height + ymin);
    }

    QImage& getBitmap()
    {
        return fractal;
    }

    void centerAndZoom(double x, double y)
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
};





#endif // FRACTALIMAGE_H
