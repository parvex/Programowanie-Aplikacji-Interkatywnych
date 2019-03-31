import QtQuick 2.9
import QtQuick.Window 2.2

Window {
    id: mainWindow
    visible: true

    width: 800
    height: 800

    property var food: Qt.createComponent("Food.qml");
    property var snake: Qt.createComponent("SnakeSegment.qml");

    property int baseStepTime: 1000
    property int fixedStepTime: baseStepTime / (moveMultiplier + 1)
    property int moveMultiplier: 4
    property var gameField
    property var snakeArray
    property var foodObject
    property var previousPartDiff: [0, 0]

    Rectangle {
        id: gameArea

        width: Math.min(
                   mainWindow.width,
                   mainWindow.height)
        height: width

        border.color: "blue"
        border.width: 2
        color: "black"
        anchors.centerIn: parent

        property int fieldSize: width / gameSize
        property int gameSize: 20
    }

    function initObjects() {
        baseStepTime = 1000;
        fixedStepTime = baseStepTime / (moveMultiplier + 1)
        gameField = [];
        for (var i = 0; i < gameArea.gameSize; ++i) {
            gameField.push([]);
        }

        score.points = 0;

        snakeArray = [];
        snakeArray.push(snake.createObject(gameArea));
        gameField[snakeArray[0].x_pos][snakeArray[0].y_pos] = snakeArray[0];

        foodObject = food.createObject(gameArea);
        placeFood(foodObject);
        previousPartDiff = [0,0]

        moveTimer.restart();
    }

    function cleanObjects() {
        foodObject.destroy();
        for (var i = 0; i < snakeArray.length; ++i) {
            snakeArray[i].destroy();
        }
    }

    function placeFood(food) {
        while (true) {
            var x = Math.floor(Math.random() * gameArea.gameSize);
            var y = Math.floor(Math.random() * gameArea.gameSize);
            if (!gameField[x][y]) {
                break;
            }
        }

        gameField[x][y] = food;

        food.x_pos = x;
        food.y_pos = y;
    }

    Component.onCompleted: { initObjects(); }

    Timer {
        id: moveTimer
        running: true
        interval: fixedStepTime
        repeat: true

        function isEndOfGame() {
            // Border collision.
            if (snakeArray[0].x_pos < 0 || snakeArray[0].x_pos >= gameArea.gameSize || snakeArray[0].y_pos < 0 || snakeArray[0].y_pos >= gameArea.gameSize)
                return true;
            // Tail.
            else if (gameField[snakeArray[0].x_pos][snakeArray[0].y_pos] && gameField[snakeArray[0].x_pos][snakeArray[0].y_pos].objectName === "snake")
                return true;
            else
                return false;
        }

        function eatFood() {
            var new_segment = snake.createObject( gameArea, { x_pos: snakeArray[0].x_pos, y_pos: snakeArray[0].y_pos });
            snakeArray.push(new_segment);
            gameField[snakeArray[snakeArray.length-1].x_pos][snakeArray[snakeArray.length-1].y_pos] = new_segment;
            score.points += score.multiplier;
            if(baseStepTime > 300)
            {
                baseStepTime -= 40;
                fixedStepTime = baseStepTime / (moveMultiplier + 1);
            }

            placeFood(foodObject);
        }

        function move() {
            var last_pos = null;
            var eat = false;
            for (var i = 0; i < snakeArray.length; ++i) {
                var segment = snakeArray[i];
                var dx = segment.velocity[0];
                var dy = segment.velocity[1];

                gameField[segment.x_pos][segment.y_pos] = null;

                var this_pos = [segment.x_pos, segment.y_pos];
                if (i == 0) {
                    segment.x_pos += dx;
                    segment.y_pos += dy;
                    if (isEndOfGame()) {
                        moveTimer.running = false;
                        gameOverText.z = 1;
                        segment.x_pos -= dx;
                        segment.y_pos -= dy;
                        return;
                    }
                }
                else {
                    segment.x_pos = last_pos[0];
                    segment.y_pos = last_pos[1];
                }
                last_pos = this_pos;

                if (gameField[snakeArray[0].x_pos][snakeArray[0].y_pos] && gameField[snakeArray[0].x_pos][snakeArray[0].y_pos].objectName === "food")
                    eat = true;

                gameField[segment.x_pos][segment.y_pos] = segment;
            }
            if (eat)
                eatFood();

            if(snakeArray[1])
                previousPartDiff = [snakeArray[1].x_pos - snakeArray[0].x_pos, snakeArray[1].y_pos - snakeArray[0].y_pos];
            console.log(previousPartDiff);
        }

        onTriggered: { move() }
    }

    Item {
        id: keyControl
        focus: true

        function onKeyPressed(event) {
            if(event.key >= Qt.Key_1 && event.key <= Qt.Key_9){
                mainWindow.moveMultiplier = event.key - Qt.Key_0; // possible values: 1..9
                fixedStepTime = baseStepTime / (moveMultiplier + 1);
            }
            switch(event.key) {
            case Qt.Key_R:
                gameOverText.z = -1;
                cleanObjects();
                initObjects();
                break;
            case Qt.Key_Q:
                Qt.quit();
                break;
            case Qt.Key_Left:
                if (snakeArray[0].velocity[0] === 0 && previousPartDiff[0] !== -1)
                        snakeArray[0].velocity = [-1, 0];
                break;
            case Qt.Key_Right:
                if (snakeArray[0].velocity[0] === 0 && previousPartDiff[0] !== 1)
                        snakeArray[0].velocity = [1, 0];
                break;
            case Qt.Key_Up:
                if (snakeArray[0].velocity[1] === 0 && previousPartDiff[1] !== -1)
                        snakeArray[0].velocity = [0, -1];
                break;
            case Qt.Key_Down:
                if (snakeArray[0].velocity[1] === 0 && previousPartDiff[1] !== 1)
                        snakeArray[0].velocity = [0, 1];
                break;
            case Qt.Key_P:
                moveTimer.running = !moveTimer.running;
                break;
            }
        }

        Keys.onPressed: {
            onKeyPressed(event)
        }
    }

    Text {
        id: score

        text: points
        color: "#00d4ff"
        font.pixelSize: mainWindow.width/10
        property int multiplier: mainWindow.moveMultiplier
        property int points: 0

        x: 10
        y: 10
        z: 1
    }


    Text {
        id: gameOverText

        text: "Game over!"
        color: "white"
        font.pixelSize: Math.min(mainWindow.width, mainWindow.height)/10
        anchors.verticalCenter: gameArea.verticalCenter
        anchors.horizontalCenter: gameArea.horizontalCenter
        z: -1
    }
}
