#include "fractalwindow.h"
#include "ui_fractalwindow.h"
#include <QGraphicsPixmapItem>
#include <QGraphicsScene>
#include "fractalscene.h"

FractalWindow::FractalWindow(QWidget *parent, uint width, uint height): QMainWindow(parent), ui(new Ui::FractalWindow) ,width(width), height(height)
{
    ui->setupUi(this);
    scene = new FractalScene(width, height);
    ui->graphicsView->setScene(scene);

    this->setFixedSize(QSize(width+20, height+40));
    ui->graphicsView->show();

}

FractalWindow::~FractalWindow()
{
    delete ui;
}
