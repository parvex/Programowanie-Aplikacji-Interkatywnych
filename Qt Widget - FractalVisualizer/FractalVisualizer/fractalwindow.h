#ifndef FRACTALWINDOW_H
#define FRACTALWINDOW_H

#include "fractalimage.h"

#include <QMainWindow>
#include <QtCore>
#include <QtGui>
#include "fractalscene.h"

namespace Ui {
class FractalWindow;
}

class FractalWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit FractalWindow(QWidget *parent = nullptr, uint width = 1286, uint height = 768);
    ~FractalWindow();

private:
    Ui::FractalWindow* ui;
    FractalScene* scene;
    uint width, height;
    FractalImage* fractalImage;

};

#endif // FRACTALWINDOW_H
