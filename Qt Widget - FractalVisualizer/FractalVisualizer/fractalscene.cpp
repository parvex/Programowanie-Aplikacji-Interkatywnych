#include "fractalscene.h"
#include "zoomcommand.h"

FractalScene::FractalScene()
{
}

FractalScene::FractalScene(uint width, uint height, uint fractalTypeIndex, uint colorTypeIndex, double cReal, double cImaginary, QUndoStack* undoStack):
    undoStack(undoStack)
{
    fractalImage =  std::make_shared<FractalImage>(width, height, fractalTypeIndex, colorTypeIndex,  cReal, cImaginary);
    pixMap.convertFromImage(fractalImage->getBitmap());
    pixmapItem = new QGraphicsPixmapItem(pixMap);
    this->addItem(pixmapItem);
}

FractalScene::~FractalScene()
{
    delete pixmapItem;
}

void FractalScene::setFractalImage(std::shared_ptr<FractalImage> fractalImage)
{
    this->fractalImage = fractalImage;
    pixMap.convertFromImage(fractalImage->getBitmap());
    pixmapItem->setPixmap(pixMap);
}

void FractalScene::mousePressEvent(QGraphicsSceneMouseEvent *event)
{
    if(event->buttons() & Qt::LeftButton)
    {
        std::shared_ptr<FractalImage> previousImageCopy = std::make_shared<FractalImage>(*fractalImage);
        mouseClickPoint = event->scenePos();
        fractalImage->centerAndZoom(mouseClickPoint.x(), mouseClickPoint.y());
        undoStack->push(new ZoomCommand(fractalImage, previousImageCopy, this ));
        pixMap.convertFromImage(fractalImage->getBitmap());
        pixmapItem->setPixmap(pixMap);
    }
    else
    {
        if(undoStack->canUndo())
            undoStack->undo();
    }

}
std::shared_ptr<FractalImage> FractalScene::getFractalImage()
{
    return fractalImage;
}

