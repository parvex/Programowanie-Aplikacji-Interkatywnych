#ifndef FRACTALSCENE_H
#define FRACTALSCENE_H


#include <QGraphicsScene>
#include <QPixmap>
#include <QPointF>
#include <QGraphicsSceneMouseEvent>
#include <QGraphicsPixmapItem>
#include <QUndoStack>
#include "fractalimage.h"


class ZoomCommand;

class FractalScene : public QGraphicsScene
{
public:
    FractalScene();
    FractalScene(uint width, uint height, uint fractalTypeIndex, uint colorTypeIndex, double cReal, double cImaginary, QUndoStack* undoStack, uint iterations);
    ~FractalScene();

    void setFractalImage(std::shared_ptr<FractalImage> fractalImage);
    std::shared_ptr<FractalImage> getFractalImage();
private:


    QPointF mouseClickPoint;
    QPixmap pixMap;
    std::shared_ptr<FractalImage> fractalImage;
    QGraphicsPixmapItem* pixmapItem;
    QUndoStack* undoStack;

    void mousePressEvent(QGraphicsSceneMouseEvent *event);

};

#endif // FRACTALSCENE_H
