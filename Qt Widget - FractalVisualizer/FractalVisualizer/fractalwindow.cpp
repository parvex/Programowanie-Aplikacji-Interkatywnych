#include "fractalwindow.h"
#include "ui_fractalwindow.h"
#include <QGraphicsPixmapItem>
#include <QGraphicsScene>

FractalWindow::FractalWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::FractalWindow)
{
    ui->setupUi(this);
    QPixmap pixMap;
    fractalImage = new FractalImage();
    fractalImage->getBitmap().save_image("test.bmp");
    pixMap.loadFromData(fractalImage->getBitmap().data(), fractalImage->getBitmap().pixel_count()*3, "BMP");
    auto x = fractalImage->getBitmap().pixel_count();
    scene.addItem(new QGraphicsPixmapItem(QPixmap("test.bmp")));
    ui->graphicsView->setScene(&scene);

    ui->graphicsView->show();

}

FractalWindow::~FractalWindow()
{
    delete ui;
}
