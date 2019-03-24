#ifndef ZOOMCOMMAND_H
#define ZOOMCOMMAND_H

#include <QUndoCommand>
#include "fractalimage.h"
#include "fractalscene.h"


class ZoomCommand : public QUndoCommand
{
public:
    ZoomCommand(std::shared_ptr<FractalImage> fractalImage, std::shared_ptr<FractalImage> previousImage,
                FractalScene* fractalScene,  QUndoCommand* parent = nullptr);
    ~ZoomCommand();
    void undo();
    void redo();

private:
    std::shared_ptr<FractalImage> fractalImage;
    std::shared_ptr<FractalImage> previousImage;
    FractalScene* fractalScene;
};

#endif // ZOOMCOMMAND_H
