#include "zoomcommand.h"

ZoomCommand::ZoomCommand(std::shared_ptr<FractalImage> fractalImage, std::shared_ptr<FractalImage> previousImage,
                         FractalScene* fractalScene, QUndoCommand* parent) :
    QUndoCommand(parent), fractalImage(fractalImage), fractalScene(fractalScene), previousImage(previousImage)
{
}

ZoomCommand::~ZoomCommand()
{
}

void ZoomCommand::undo()
{
    if(previousImage != nullptr)
        fractalScene->setFractalImage(previousImage);
}

void ZoomCommand::redo()
{
    fractalScene->setFractalImage(fractalImage);
}

