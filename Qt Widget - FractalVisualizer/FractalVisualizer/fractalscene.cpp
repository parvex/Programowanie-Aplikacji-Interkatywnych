#include "fractalscene.h"

FractalScene::FractalScene()
{
}

FractalScene::FractalScene(unsigned width, unsigned height)
{
    fractalImage = new FractalImage(width, height);
    pixMap.convertFromImage(fractalImage->getBitmap());
    pixmapItem = new QGraphicsPixmapItem(pixMap);
    this->addItem(pixmapItem);
}

void FractalScene::mousePressEvent(QGraphicsSceneMouseEvent *event)
{
    if(event->buttons() & Qt::LeftButton)
    {
        mouseClickPoint = event->scenePos();
        fractalImage->centerAndZoom(mouseClickPoint.x(), mouseClickPoint.y());
        pixMap.convertFromImage(fractalImage->getBitmap());
        pixmapItem->setPixmap(pixMap);
    }
    else
    {
        //qtundostasck
    }

}
