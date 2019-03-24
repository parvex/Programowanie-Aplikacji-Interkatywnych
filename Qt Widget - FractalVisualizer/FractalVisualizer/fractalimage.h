#ifndef FRACTALIMAGE_H
#define FRACTALIMAGE_H
#include <iostream>
#include <fstream>
#include <map>
#include <QImage>

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

class FractalImage
{
    public:

    //size of the image
    static unsigned bmpXmax;
    static unsigned bmpYmax;
    //number of iterations before accepting point
    static unsigned iter_max;
    static unsigned zoom;

    QImage fractal;
    //domain in which mandelbrott set is being tested
    double xmin = -2.2;
    double xmax = 1.2;
    double ymin = -1.7;
    double ymax = 1.7;
    double height;
    double width;
    std::vector<QColor> colors;
    uint fractalTypeIndex, colorTypeIndex;
    double cReal;
    double cImaginary;

    FractalImage();

    FractalImage(uint w, uint h, uint fractalTypeIndex, uint colorTypeIndex, double cReal, double cImaginary, uint iterations);

    FractalImage(FractalImage& im);

    ~FractalImage();

    //picking random colors for every iter break numbers
    void generateColors();

    //gradient color generator from 0 to iter_max
    QColor IntToColor(uint i);

    void generateBitmap();

    //scales pixel to fit in mandelbrott domain
    DecPoint scale(double x, double y);

    QImage& getBitmap();

    void centerAndZoom(double x, double y);
};





#endif // FRACTALIMAGE_H
