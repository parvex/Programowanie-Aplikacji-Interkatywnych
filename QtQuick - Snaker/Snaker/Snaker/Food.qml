import QtQuick 2.9


Image {
    id: food
    objectName: "food"
    source: "cookie.png"
    property int size: parent.fieldSize

    property int x_pos: 0
    property int y_pos: 0

    x: size * x_pos
    y: size * y_pos

    width: size
    height: size




    Behavior on x {
        NumberAnimation { duration: 200 }
    }
    Behavior on y {
        NumberAnimation { duration: 200 }
    }
}
