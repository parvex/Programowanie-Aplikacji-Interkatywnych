import QtQuick 2.9

Rectangle {
    objectName: "snake"

    property var velocity: [1, 0] // [x,y]; default: right

    property int size: parent.fieldSize
    property int x_pos: 9
    property int y_pos: 9

    x: size * x_pos
    y: size * y_pos

    radius: width
    width: size
    height: width

    color: "brown"

    Behavior on x {
        NumberAnimation {
            duration: mainWindow.fixedStepTime
            easing.type: Easing.Linear
        }
    }
    Behavior on y {
        NumberAnimation {
            duration: mainWindow.fixedStepTime
            easing.type: Easing.Linear
        }
    }
}
