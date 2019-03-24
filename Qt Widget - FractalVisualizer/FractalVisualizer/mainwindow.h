#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QUndoStack>
#include "fractalwindow.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

    void resetValues();

private slots:
    void on_pushButton_clicked();
    void on_typeComboBox_currentIndexChanged(int index);

    void on_actionExit_triggered();

private:
    Ui::MainWindow* ui;
    FractalWindow* fractalWindow;
};

#endif // MAINWINDOW_H
