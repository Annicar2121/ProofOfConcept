import javafx.application.Application;
import javafx.application.Platform;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.*;
import javafx.scene.paint.Color;
import javafx.scene.shape.Rectangle;
import javafx.scene.shape.Shape;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;

/**
 * Annica Roos
 * tilesGUI creates the application, handles click events, updates the canvas on
 * those, intializes and creates the other classes Board, Score, Tile, RectPair to be used
 */
public class tilesGUI extends Application {

    /**
     * Instance Variables and Static Variables
     */
    private static final int ROWS = 5;
    private static final int COLUMNS = 4;
    private static final int MAX = ROWS * COLUMNS;

    private int ROW_INDEX;
    private int COL_INDEX;

    private int CLICKS;

    private int CURRENTSCORE;
    private int HIGHSCORE;

    /**
     * Create colors to be used, place them in an array to which
     * the indexes will be called from Tile elements
     */
    private final Color BLUE = Color.AQUA;
    private final Color RED = Color.DARKRED;
    private final Color YELLOW = Color.YELLOW;
    private final Color GREEN = Color.DARKOLIVEGREEN;
    private final Color INDIGO = Color.INDIGO;
    private final Color SILVER = Color.SILVER;
    private final Color[] MYCOLORS = {BLUE, RED, YELLOW, GREEN, INDIGO, SILVER};

    /**
     * Create Pairs of heights and widths to be used in
     * creating rectangles, uses the RectPair Class, and
     * places these pairs in an array to which will be accessed
     * by indexes established in the Tile Elements
     */
    RectPair r1 = new RectPair(10, 40);
    RectPair r2 = new RectPair(20, 70);
    RectPair r3 = new RectPair(30, 30);
    RectPair r6 = new RectPair(70, 5);
    private final RectPair[] MYSHAPES = {r3, r2, r1, r6};

    /**
     * An array to hold the StackPanes to which Tiles
     * are built upon, it uses MAX, and MAX MUST
     * BE AN EVEN NUMBER
     */
    public StackPane[] MYPANES = new StackPane[MAX];


    /**
     * Variables that are assigned the click information
     * in the event handler
     */
    int colIndex;
    int rowIndex;
    int colIndexTwo;
    int rowIndexTwo;


    /**
     * Fills the MYPANES array with new StackPanes. Used in Init to
     * Create and update Tiles
     */
    public void fillPanes() {
        for (int i = 0; i < MAX; i++) {
            this.MYPANES[i] = new StackPane();
        }
    }

    /**
     * Sets up the Tiles in the StackPanes, and places them in the Gridpane.
     * Gets updates based on user input, and draws only elements that are set to
     * true (visible).
     * Rectangles are drawn with the RectPairs pointed to by the index
     * assigned in the tile, and they are filled with the colors pointed to
     * by the index assigned to the Tile element
     *
     * @param gridPane the overall Pane that is being used to set up the scene
     * @param tiles    an array of all the Tiles we have, and will be used to draw them
     */
    public void init(GridPane gridPane, Tile[] tiles) {

        fillPanes();
        int j = 0;
        int tempHeight = 0;
        int tempWidth = 0;
        int colorTemp = 0;

        int pairIndex1 = 0;
        int pairIndex2 = 0;
        int pairIndex3 = 0;

        int colorIndex1 = 0;
        int colorIndex2 = 0;
        int colorIndex3 = 0;

        for (int i = 0; i < 20; i++) {

            pairIndex1 = tiles[i].shapeOne;
            pairIndex2 = tiles[i].shapeTwo;
            pairIndex3 = tiles[i].shapeThree;

            colorIndex1 = tiles[i].c1;
            colorIndex2 = tiles[i].c2;
            colorIndex3 = tiles[i].c3;

            //ensures when redrawn, the element set to hidden is hidden
            MYPANES[i].setStyle("-fx-background-color: rgb(0,0,0)");

            Shape s1 = new Rectangle(0, 0, MYSHAPES[pairIndex1].getWidth(), MYSHAPES[pairIndex1].getHeight());
            s1.setFill(MYCOLORS[colorIndex1]);
            Shape s2 = new Rectangle(0, 0, MYSHAPES[pairIndex2].getWidth(), MYSHAPES[pairIndex2].getHeight());
            s2.setFill(MYCOLORS[colorIndex2]);
            Shape s3 = new Rectangle(0, 0, MYSHAPES[pairIndex3].getWidth(), MYSHAPES[pairIndex3].getHeight());
            s3.setFill(MYCOLORS[colorIndex3]);

            if (tiles[i].elementOne == true) {
                MYPANES[i].getChildren().add(s1);
            }
            if (tiles[i].elementTwo == true) {
                MYPANES[i].getChildren().add(s2);
            }
            if (tiles[i].elementThree == true) {
                MYPANES[i].getChildren().add(s3);
            }


        }

        //place the stackpanes in the grid
        for (int i = 0; i < 20; i++) {

            gridPane.setColumnIndex(MYPANES[i], tiles[i].y);
            gridPane.setRowIndex(MYPANES[i], tiles[i].x);
            gridPane.getChildren().add(MYPANES[i]);

        }

        //create and place labels for score and position keeping
        Label label1 = new Label(" Current Streak: " + CURRENTSCORE + " ");
        label1.setAlignment(Pos.CENTER);
        label1.setScaleX(1);
        label1.setScaleY(1);
        BackgroundFill bg = new BackgroundFill(Color.PALETURQUOISE,
                CornerRadii.EMPTY, Insets.EMPTY);
        Background b = new Background((bg));
        label1.setBackground(b);
        HBox hb = new HBox();
        hb.getChildren().addAll(label1);

        Label label2 = new Label(" Longest Streak: " + HIGHSCORE + " ");
        label2.setAlignment(Pos.CENTER);
        label2.setScaleX(1);
        label2.setScaleY(1);
        label2.setBackground(b);
        HBox hb2 = new HBox();
        hb2.getChildren().addAll(label2);

        Label label3 = new Label(" Current Tile: ( " + ROW_INDEX + ", " + COL_INDEX + ")");
        label3.setAlignment(Pos.CENTER);
        label3.setScaleX(1);
        label3.setScaleY(1);
        label3.setBackground(b);
        HBox hb3 = new HBox();
        hb3.getChildren().addAll(label3);

        gridPane.add(hb, 0, 6);
        gridPane.add(hb2, 4, 6);
        gridPane.add(hb3, 2, 6);

    }

    /**
     * Triggers a Game Over alert box once the game over state has been reached
     *
     * @param over     the value assigned by Boards checkGameOver() method, true if all Tile Elements are false
     * @param gridPane the overhead pane that all StackPanes and Vboxs are added to
     */
    public void gameOver(boolean over, GridPane gridPane) {
        Image alertImage = new Image(getClass().getClassLoader().getResourceAsStream("alertImage.png"));
        ImageView view = new ImageView(alertImage);
        view.setFitHeight(50);
        view.setFitWidth(50);
        Alert alert = new Alert(Alert.AlertType.NONE,
                "You have finished the game! Final Score: " + HIGHSCORE, ButtonType.OK);
        alert.setGraphic(view);
        alert.setTitle("Game Over");
        if (over) {
            alert.show();
        }
    }

    /**
     * Launches the app
     *
     * @param args
     */
    public static void main(String[] args) {
        launch(args);
    }

    /**
     * Creates and Initializes the other Classes Board, Score and Tile, and sets up the scene
     * Also has event handlers for user input clicks, and updates score and Tile elements based
     * on what is clicked, and if the Elements match or not
     *
     * @param primaryStage
     * @throws Exception
     */
    @Override
    public void start(Stage primaryStage) throws Exception {

        primaryStage.setTitle("Tiles");
        //makes sure the app closes when the exit button is pressed
        primaryStage.setOnCloseRequest(new EventHandler<WindowEvent>() {
            @Override
            public void handle(WindowEvent t) {
                Platform.exit();
                System.exit(0);
            }
        });

        //initialize pane array
        fillPanes();
        // create the board
        Board myBoard = new Board(ROWS, COLUMNS);
        //create and fill with tiles
        myBoard.fill(MAX);
        myBoard.setPairs();
        myBoard.printBoard();

        //create Score obj
        //set Score to zero to start
        Score myScore = new Score(CURRENTSCORE, HIGHSCORE);

        //set the current score
        myScore.setCurrentScore(CURRENTSCORE);

        //done setting up other classes

        //creates rows and columns based on global variables
        GridPane gridPane = new GridPane();
        gridPane.setStyle("-fx-background-color: Black");
        gridPane.setPrefSize(650, 600);
        int col = ROWS;
        int row = COLUMNS + 2;
        for (int c = 0; c < col; c++) {
            ColumnConstraints colConst = new ColumnConstraints();
            colConst.setPercentWidth(150 / col);
            gridPane.getColumnConstraints().add(colConst);
        }
        for (int r = 0; r < row; r++) {
            RowConstraints rowConst = new RowConstraints();
            rowConst.setPercentHeight(95 / row);
            gridPane.getRowConstraints().add(rowConst);
        }

        //Triggers warning box, and shows the scene
        Image warnImage = new Image(getClass().getClassLoader().getResourceAsStream("warning.png"));
        ImageView view = new ImageView(warnImage);
        view.setFitHeight(50);
        view.setFitWidth(50);
        init(gridPane, myBoard.MYTILES);
        Alert warn = new Alert(Alert.AlertType.NONE, "DO NOT DOUBLE CLICK ON A TILE", ButtonType.OK);
        warn.setTitle("WARNING");
        warn.setGraphic(view);
        Scene scene = new Scene(gridPane);
        primaryStage.setScene(scene);
        primaryStage.show();
        warn.show();

        /**
         * Event Handler for clicking. Sets index for rows and columns
         * based on where the user clicked on the GridPane
         */
        gridPane.setOnMousePressed(new EventHandler<MouseEvent>() {
            public void handle(MouseEvent me) {
                for (Node node : gridPane.getChildren()) {
                    node.setOnMouseClicked((MouseEvent t) -> {
                        CLICKS++;

                        /**
                         * First click, sets row and col index number one
                         */
                        if (CLICKS == 1) {
                            colIndex = gridPane.getColumnIndex(node);
                            rowIndex = gridPane.getRowIndex(node);
                            COL_INDEX = colIndex;
                            ROW_INDEX = rowIndex;
                        }
                        /**
                         * Second click, sets row/column index number two, and sends the current
                         * selected tile information to be displayed
                         */
                        else if (CLICKS > 1) {
                            colIndexTwo = gridPane.getColumnIndex(node);
                            rowIndexTwo = gridPane.getRowIndex(node);
                            COL_INDEX = colIndexTwo;
                            ROW_INDEX = rowIndexTwo;

                        } else {
                            CLICKS--;
                        }
                        /**
                         * Checks if row/col indexes one and two have an element that match,
                         * and if that was the last visible element on the Tile.
                         * Assumes that two Tiles have been clicked.
                         */
                        if (CLICKS != 1) {
                            boolean match = myBoard.checkMatch(colIndex, rowIndex, colIndexTwo, rowIndexTwo);
                            boolean clear = myBoard.checkCleared(colIndexTwo, rowIndexTwo);
                            /**
                             * the elements matched, there are still elements left
                             * update the score, and set the second clicked tile coordinates
                             * to index number ones
                             */
                            if (match == true &&
                                    clear != true) {

                                myScore.setCurrentScore(CURRENTSCORE + 1);
                                CURRENTSCORE = myScore.getCURRENTSCORE();
                                HIGHSCORE = myScore.getHIGHSCORE();
                                colIndex = colIndexTwo;
                                rowIndex = rowIndexTwo;
                                System.out.print("ColIndex is: ");
                                System.out.println(colIndex);
                                System.out.print("RowIndex is: ");
                                System.out.println(rowIndex);
                                CLICKS = 1;


                            }
                            /**
                             * The Tile elements matched, but there are no visible elements
                             * left. We don't lose the streak, so set to click 1 again, and
                             * keep the current streak going
                             */
                            else if (clear == true && match == true) {
                                System.out.println("Cleared Tile In Hanlder");
                                myScore.setCurrentScore(CURRENTSCORE + 1);
                                CURRENTSCORE = myScore.getCURRENTSCORE();
                                HIGHSCORE = myScore.getHIGHSCORE();
                                CLICKS = 0;

                            }
                            /**
                             * The elements did not match, set click to 1 again
                             * and reset current streak to zero. Update highscore
                             * if need be.
                             */
                            else if (match != true) {
                                System.out.println("Elements don't match in handler");
                                CLICKS = 0;
                                myScore.setCurrentScore(CURRENTSCORE);
                                CURRENTSCORE = 0;
                                myScore.setCurrentScore(CURRENTSCORE);

                            }
                        }
                        /**
                         * Update score and board to show/hide elements that have
                         * been edited. Also check if the game is over.
                         */
                        myScore.setCurrentScore(CURRENTSCORE);
                        CURRENTSCORE = myScore.getCURRENTSCORE();
                        HIGHSCORE = myScore.getHIGHSCORE();
                        gameOver(myBoard.checkGameOver(), gridPane);
                        init(gridPane, myBoard.MYTILES);


                    });
                }
            }
        });


    }


}




