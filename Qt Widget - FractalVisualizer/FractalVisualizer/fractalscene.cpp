#include "fractalscene.h"

FractalScene::FractalScene()
{
}

FractalScene::FractalScene(uint width, uint height, uint fractalTypeIndex, uint colorTypeIndex, double cReal, double cImaginary)
{
    fractalImage = new FractalImage(width, height, fractalTypeIndex, colorTypeIndex,  cReal, cImaginary);
    pixMap.convertFromImage(*(fractalImage->getBitmap()));
    pixmapItem = new QGraphicsPixmapItem(pixMap);
    this->addItem(pixmapItem);
}

FractalScene::~FractalScene()
{
    delete fractalImage;
    delete pixmapItem;
}

void FractalScene::mousePressEvent(QGraphicsSceneMouseEvent *event)
{
    if(event->buttons() & Qt::LeftButton)
    {
        mouseClickPoint = event->scenePos();
        fractalImage->centerAndZoom(mouseClickPoint.x(), mouseClickPoint.y());
        pixMap.convertFromImage(*(fractalImage->getBitmap()));
        pixmapItem->setPixmap(pixMap);
    }
    else
    {
        //qtundostasck
    }

}

FractalImage* FractalScene::getFractalImage()
{
    return fractalImage;
}

