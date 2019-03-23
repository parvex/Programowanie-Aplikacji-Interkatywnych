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
    ui->colorsComboBox->addItem("Inverted");

    ui->spinBoxWidth->setRange(400,1920);
    ui->spinBoxHeight->setRange(400,1080);

    ui->spinBoxReal->setRange(-1,1);
    ui->spinBoxReal->setSingleStep(0.1);
    ui->spinBoxImaginary->setRange(-1,1);
    ui->spinBoxImaginary->setSingleStep(0.1);

    ui->spinBoxReal->hide();
    ui->spinBoxImaginary->hide();
    ui->realLabel->hide();
    ui->imaginaryLabel->hide();
}

MainWindow::~MainWindow()
{
    delete ui;
    delete fractalWindow;
}

void MainWindow::on_pushButton_clicked()
{
    fractalWindow = new FractalWindow(this, ui->spinBoxWidth->value(), ui->spinBoxHeight->value(), ui->typeComboBox->currentIndex(),
                                      ui->colorsComboBox->currentIndex(), ui->spinBoxReal->value(), ui->spinBoxImaginary->value());
    fractalWindow->show();
    this->hide();
}

void MainWindow::on_typeComboBox_currentIndexChanged(int index)
{
    if(index == 1)
    {
        ui->spinBoxReal->show();
        ui->spinBoxImaginary->show();
        ui->realLabel->show();
        ui->imaginaryLabel->show();
    }
    else
    {
        ui->spinBoxReal->hide();
        ui->spinBoxImaginary->hide();
        ui->realLabel->hide();
        ui->imaginaryLabel->hide();
    }
}

void MainWindow::resetValues()
{
    ui->typeComboBox->setCurrentIndex(0);
    ui->colorsComboBox->setCurrentIndex(0);
    ui->spinBoxWidth->setValue(0);
    ui->spinBoxHeight->setValue(0);
    ui->spinBoxReal->setValue(0);
    ui->spinBoxImaginary->setValue(0);
}

void MainWindow::on_actionExit_triggered()
{
    QApplication::quit();
}
