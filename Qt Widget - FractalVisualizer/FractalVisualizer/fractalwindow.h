#ifndef FRACTALWINDOW_H
#define FRACTALWINDOW_H

#include "Fractalimage.h"

#include <QMainWindow>
#include <QtCore>
#include <QtGui>
#include <QGraphicsScene>

namespace Ui {
class FractalWindow;
}

class FractalWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit FractalWindow(QWidget *parent = nullptr, int width = 1286, int height = 768);
    ~FractalWindow();

private:
    Ui::FractalWindow* ui;
    QGraphicsScene scene;
    int width, height;
    FractalImage* fractalImage;

};

#endif // FRACTALWINDOW_H
