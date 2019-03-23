#include "fractalwindow.h"
#include "ui_fractalwindow.h"
#include <QFileDialog>
#include <QGraphicsPixmapItem>
#include <QGraphicsScene>
#include "fractalscene.h"
#include "mainwindow.h"

FractalWindow::FractalWindow(QWidget *parent, uint width, uint height, uint fractalTypeIndex, uint colorTypeIndex, double cReal, double cImaginary) : QMainWindow(parent), ui(new Ui::FractalWindow)
{
    ui->setupUi(this);
    scene = new FractalScene(width, height, fractalTypeIndex, colorTypeIndex, cReal, cImaginary);
    ui->graphicsView->setScene(scene);

    this->setFixedSize(QSize(width+20, height+41));
    ui->graphicsView->show();
}

FractalWindow::~FractalWindow()
{
    delete ui;
    delete scene;
}

void FractalWindow::on_actionGenerate_new_triggered()
{
    ((MainWindow*) parent())->resetValues();
    ((MainWindow*) parent())->show();
    this->close();
}

void FractalWindow::on_actionExit_triggered()
{
    QApplication::exit();
}

void FractalWindow::on_actionSave_triggered()
{

    QString fileName = QFileDialog::getSaveFileName(this,
        tr("Save fractal image"), "",
        tr("*.bmp;"));

        if (fileName.isEmpty())
            return;
        else
        {
            scene->getFractalImage()->getBitmap()->save(fileName, "bmp", 100);
        }

}
