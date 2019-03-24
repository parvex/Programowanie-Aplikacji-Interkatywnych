#ifndef FRACTALWINDOW_H
#define FRACTALWINDOW_H

#include "fractalimage.h"

#include <QMainWindow>
#include <QUndoStack>
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
    explicit FractalWindow(QWidget *parent, uint width, uint height, uint fractalTypeIndex, uint colorTypeIndex, double cImaginary, double cReal, uint iterations);
    ~FractalWindow();

private slots:
    void on_actionGenerate_new_triggered();

    void on_actionExit_triggered();

    void on_actionSave_triggered();

    void on_actionUndo_zoom_triggered();

    void on_actionRedo_zoom_triggered();

private:
    Ui::FractalWindow* ui;
    FractalScene* scene;
    uint width, height;
    QUndoStack* undoStack;

};

#endif // FRACTALWINDOW_H
