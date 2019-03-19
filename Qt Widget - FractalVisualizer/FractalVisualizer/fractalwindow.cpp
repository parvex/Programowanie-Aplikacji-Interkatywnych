#include "fractalwindow.h"
#include "ui_fractalwindow.h"
#include <QGraphicsPixmapItem>
#include <QGraphicsScene>

FractalWindow::FractalWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::FractalWindow)
{
    ui->setupUi(this);

    scene.addItem(new QGraphicsPixmapItem(QPixmap("c:\\test.jpg")));
    ui->graphicsView->setScene(&scene);

    ui->graphicsView->show();

}

FractalWindow::~FractalWindow()
{
    delete ui;
}
