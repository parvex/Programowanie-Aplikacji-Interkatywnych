#include "fractalwindow.h"
#include "ui_fractalwindow.h"
#include <QGraphicsPixmapItem>
#include <QGraphicsScene>

FractalWindow::FractalWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::FractalWindow)
{
    ui->setupUi(this);
    fractalImage = new FractalImage();
    QPixmap pixMap;
    pixMap.convertFromImage(fractalImage->getBitmap());
    scene.addItem(new QGraphicsPixmapItem(pixMap));
    ui->graphicsView->setScene(&scene);

    ui->graphicsView->show();

}

FractalWindow::~FractalWindow()
{
    delete ui;
}
