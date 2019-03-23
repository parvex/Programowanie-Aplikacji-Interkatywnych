#ifndef FRACTALSCENE_H
#define FRACTALSCENE_H

#include "fractalimage.h"

#include <QGraphicsScene>
#include <QPixmap>
#include <QPointF>
#include <QGraphicsSceneMouseEvent>
#include <QGraphicsPixmapItem>


class FractalScene : public QGraphicsScene
{
public:
    FractalScene();
    FractalScene(uint width, uint height, uint fractalTypeIndex, uint colorTypeIndex, double cReal, double cImaginary);
    ~FractalScene();

    FractalImage* getFractalImage();
private:
    QPointF mouseClickPoint;
    QPixmap pixMap;
    FractalImage* fractalImage;
    QGraphicsPixmapItem* pixmapItem;

    void mousePressEvent(QGraphicsSceneMouseEvent *event);

};

#endif // FRACTALSCENE_H
