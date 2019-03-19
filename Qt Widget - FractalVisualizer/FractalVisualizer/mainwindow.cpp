#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->typeComboBox->addItem("Mandelbrot");
    ui->typeComboBox->addItem("Julia");
    ui->colorsComboBox->addItem("Standard");
    ui->resolutionComboBox->addItem("1280-768");
//    this->setFixedSize(QSize(460,400));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    fractalWindow = new FractalWindow(this);
    fractalWindow->show();
    this->hide();
}
