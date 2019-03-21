#include "fractalwindow.h"
#include "ui_fractalwindow.h"
#include <QGraphicsPixmapItem>
#include <QGraphicsScene>

FractalWindow::FractalWindow(QWidget *parent, int width, int height)
    : QMainWindow(parent), ui(new Ui::FractalWindow) ,width(width), height(height)
{
    ui->setupUi(this);
    fractalImage = new FractalImage();
    QPixmap pixMap;
    pixMap.convertFromImage(fractalImage->getBitmap());
    scene.addItem(new QGraphicsPixmapItem(pixMap));
    ui->graphicsView->setScene(&scene);

    this->setFixedSize(QSize(width+50, height+50));
    ui->graphicsView->show();

}

FractalWindow::~FractalWindow()
{
    delete ui;
}
