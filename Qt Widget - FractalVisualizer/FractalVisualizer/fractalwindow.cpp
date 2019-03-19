#include "fractalwindow.h"
#include "ui_fractalwindow.h"
#include <QGraphicsPixmapItem>
#include <QGraphicsScene>

FractalWindow::FractalWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::FractalWindow)
{
    ui->setupUi(this);
    scene = new QGraphicsScene(this);
    ui->graphicsView->setScene(scene);

    QGraphicsPixmapItem item(QPixmap("c:\\test.png"));
    scene->addItem(&item);
    ui->graphicsView->show();

}

FractalWindow::~FractalWindow()
{
    delete ui;
    delete scene;
}
