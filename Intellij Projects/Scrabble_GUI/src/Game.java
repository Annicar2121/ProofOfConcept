import javafx.application.Application;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.scene.layout.StackPane;
import javafx.scene.paint.Color;
import javafx.stage.Stage;

import javafx.application.Platform;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.*;
import javafx.stage.WindowEvent;


import java.io.*;
import java.util.ArrayList;

public class Game extends Application {

    private static final String DOUBLE_WORD = "-fx-background-color: #f08080";
    private static final String TRIPLE_LETTER = "-fx-background-color: #98fb98";
    private static final String TRIPLE_WORD = "-fx-background-color: #b22222";
    private static final String DOUBLE_LETTER = "-fx-background-color: #b0e0e6";
    private static final String GENERAL = "-fx-background-color: rgba(201,158,106,0.55)";
    private static final String TILE = "-fx-background-color: #ffdab9";

    private static final Color GENERAL_BORDER = Color.rgb(201, 158, 106, 0.55);
    private static final Color DW_BORDER = Color.rgb(150, 75, 75, 0.55);
    private static final Color DL_BORDER = Color.rgb(88, 113, 119, 0.55);
    private static final Color TL_BORDER = Color.rgb(56, 118, 56, 0.55);
    private static final Color TW_BORDER = Color.rgb(75, 16, 16, 0.55);
    private static final Color TILE_BORDER = Color.rgb(0, 0, 0, 0.32);

    private static final String DW_TEXT = "  2X\nWord";
    private static final String DL_TEXT = "  2X\nLetter";
    private static final String TW_TEXT = "  3X\nWord";
    private static final String TL_TEXT = "  3X\nLetter";
    private static final String START_TEXT = "Start\nHere";

    private static int humanScore = 0;
    private static int computerScore = 0;
    private static int clicks = 0;
    private static int colIndex = 0;
    private static int rowIndex = 0;
    private static int trayIndex = 0;

    private static char wildCard = '?';
    private static boolean isWildDis = true;

    private static boolean tileClicked = false;
    private static boolean boardClicked = false;

    private static final int MAX_TILES = 15 * 15;
    private static final int MAX_ROWS_COLS = 15;
    private static final int MAX_HAND = 7;

    private static boolean firstPlay = true;
    private static boolean humanTurn = true;
    private static boolean checkPlay = false;
    private static boolean compPass = false;
    private static boolean humanPass = false;

    private static final ArrayList<String> dictionary = new ArrayList<String>();
    private static Trie dictTrie = new Trie();
    private ArrayList<Coordinate> placedTiles = new ArrayList<>();

    private static Coordinate firstPlacedTile;

    /**
     * An array to hold the StackPanes to which Tiles
     * are built upon, it uses MAX_TILES, and MAX MUST
     * BE AN EVEN NUMBER
     */
    private static StackPane[] myPanes = new StackPane[MAX_TILES];
    private static StackPane[] tiles = new StackPane[MAX_HAND];

    /**
     * Fills the tiles array with new StackPanes to represent each tile. Used in Init to
     * Create and update Tiles,
     */
    public static void fillTray(Tray tray) {
        for (int i = 0; i < tray.size(); i++) {
            tiles[i] = new StackPane();
            tiles[i].setStyle(TILE);
            tiles[i].setBorder(new Border(new BorderStroke(TILE_BORDER,
                    BorderStrokeStyle.SOLID, CornerRadii.EMPTY, new BorderWidths(2))));
            Label l = new Label("" + tray.get(i).letter);
            l.setScaleX(1.6);
            l.setScaleY(1.6);
            BorderPane lil = new BorderPane();
            Label val = new Label("" + tray.get(i).value);
            val.setAlignment(Pos.BOTTOM_RIGHT);
            lil.setBottom(val);
            tiles[i].getChildren().add(l);
            tiles[i].getChildren().add(lil);
            tiles[i].setPadding(new Insets(5, 5, 5, 5));
        }
    }


    /**
     * Fills the myPanes array with new StackPanes. Used in Init to
     * Create and update Tiles, fill the bg according to board
     * bonuses
     */
    public static void fillPanes(Board board) {
        for (int i = 0; i < MAX_TILES; i++) {
            myPanes[i] = new StackPane();
        }
        int index = 0;
        for (int k = 0; k < MAX_ROWS_COLS; k++) {
            for (int p = 0; p < MAX_ROWS_COLS; p++) {
                if (index < myPanes.length) {
                    Square s = board.getSquare(k, p);
                    char bonus = s.special;
                    // this.myPanes[index].setPadding(new Insets(10,10,10,10));
                    //. = empty space
                    // D = double WORD
                    //T = triple WORD
                    //d= double LETTER
                    //t= triple LETTER
                    //X = center square w/ star, which is a double WORD


                    //see if a tile is on the space, print the tile if so, otherwise print general board spaces
                    if (s.letter != '?') {
                        myPanes[index].setStyle(TILE);
                        myPanes[index].setBorder(new Border(new BorderStroke(TILE_BORDER,
                                BorderStrokeStyle.SOLID, CornerRadii.EMPTY, new BorderWidths(2))));
                        Label l = new Label("" + s.letter);
                        l.setScaleX(1.6);
                        l.setScaleY(1.6);
                        BorderPane lil = new BorderPane();
                        Label val = new Label("" + s.tile.value);
                        val.setAlignment(Pos.BOTTOM_RIGHT);
                        lil.setBottom(val);
                        myPanes[index].getChildren().add(l);
                        myPanes[index].getChildren().add(lil);
                        myPanes[index].setPadding(new Insets(5, 5, 5, 5));
                    } else {
                        if (bonus == '.') {
                            myPanes[index].setStyle(GENERAL);
                            myPanes[index].setBorder(new Border(new BorderStroke(GENERAL_BORDER,
                                    BorderStrokeStyle.SOLID, CornerRadii.EMPTY, new BorderWidths(3))));
                        } else if (bonus == 'D') {
                            myPanes[index].setStyle(DOUBLE_WORD);
                            myPanes[index].setBorder(new Border(new BorderStroke(DW_BORDER,
                                    BorderStrokeStyle.DASHED, CornerRadii.EMPTY, new BorderWidths(3))));
                            myPanes[index].getChildren().add(new Label(DW_TEXT));
                        } else if (bonus == 'd') {
                            myPanes[index].setStyle(DOUBLE_LETTER);
                            myPanes[index].setBorder(new Border(new BorderStroke(DL_BORDER,
                                    BorderStrokeStyle.DASHED, CornerRadii.EMPTY, new BorderWidths(3))));
                            myPanes[index].getChildren().add(new Label(DL_TEXT));
                        } else if (bonus == 'T') {
                            myPanes[index].setStyle(TRIPLE_WORD);
                            myPanes[index].setBorder(new Border(new BorderStroke(TW_BORDER,
                                    BorderStrokeStyle.DASHED, CornerRadii.EMPTY, new BorderWidths(3))));
                            myPanes[index].getChildren().add(new Label(TW_TEXT));
                        } else if (bonus == 't') {
                            myPanes[index].setStyle(TRIPLE_LETTER);
                            myPanes[index].setBorder(new Border(new BorderStroke(TL_BORDER,
                                    BorderStrokeStyle.DASHED, CornerRadii.EMPTY, new BorderWidths(3))));
                            myPanes[index].getChildren().add(new Label(TL_TEXT));
                        } else {
                            myPanes[index].setStyle(DOUBLE_WORD);
                            myPanes[index].setBorder(new Border(new BorderStroke(DW_BORDER,
                                    BorderStrokeStyle.DOTTED, CornerRadii.EMPTY, new BorderWidths(5))));
                            myPanes[index].getChildren().add(new Label(START_TEXT));
                        }
                    }
                    index++;
                }
            }
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
     */
    public static void init(GridPane gridPane, GridPane tray, Board b, Button check, Tray huTray, BorderPane base, BorderPane right) {

        //initialize pane array
        fillPanes(b);
        //fill panes in human tray
        fillTray(huTray);

        //create and place labels for score and position keeping
        Label humanScoreLabel = new Label("Human Score:\n " + humanScore + " ");
        humanScoreLabel.setAlignment(Pos.CENTER);
        BackgroundFill bg = new BackgroundFill(GENERAL_BORDER,
                CornerRadii.EMPTY, Insets.EMPTY);
        Background bg1 = new Background((bg));
        humanScoreLabel.setBackground(bg1);
        HBox hb = new HBox();
        hb.getChildren().addAll(humanScoreLabel);

        Label computerScoreLabel = new Label("Computer Score:\n " + computerScore + " ");
        computerScoreLabel.setAlignment(Pos.CENTER);
        computerScoreLabel.setScaleX(1);
        computerScoreLabel.setScaleY(1);
        computerScoreLabel.setBackground(bg1);
        HBox hb2 = new HBox();
        hb2.getChildren().addAll(computerScoreLabel);

        BorderPane left = new BorderPane();
        left.setStyle("-fx-background-color: White");
        left.setPadding(new Insets(5, 5, 5, 5));
        left.setBottom(hb2);
        left.setCenter(hb);
        base.setLeft(left);
        base.setRight(right);

        //add panes for board
        int index = 0;
        for (int i = 0; i < MAX_ROWS_COLS; i++) {
            for (int j = 0; j < MAX_ROWS_COLS; j++) {
                gridPane.add(myPanes[index], j, i);
                index++;
            }
        }

        //add panes to tray
        for (int k = 0; k < tiles.length; k++) {
            tray.add(tiles[k], k, 1);
        }
        //add label to tray
        Label trayText = new Label("    Your Letters:");
        trayText.setScaleY(1.3);
        trayText.setScaleX(1.3);
        trayText.setAlignment(Pos.CENTER);
        tray.add(trayText, 0, 0);
        tray.add(check, tiles.length + 1, 1);
        check.setPadding(new Insets(10, 10, 10, 10));

    }

    /**
     * TODO
     * Keep things updating
     * Seems to work for now
     */
    public static void update(Player human, Player comp, Bag b, GridPane gridPane, GridPane tray, Button check, Board board, BorderPane base, BorderPane right) {
        System.out.println("Updating...");
        //Check how many tiles got placed, for bingo, before refilling trays
        if (human.tray.size() == 0) {
            humanScore += 50;
        }
        if (comp.tray.size() == 0) {
            computerScore += 50;
        }

        if (humanTurn == false) {
            human.refill(b);
        } else {
            comp.refill(b);
        }
        gridPane.getChildren().removeAll();
        tray.getChildren().removeAll();
        gridPane.getChildren().clear();
        tray.getChildren().clear();
        myPanes = new StackPane[MAX_TILES];
        tiles = new StackPane[human.tray.size()];
        init(gridPane, tray, board, check, human.tray, base, right);

    }

    /**
     * Triggers a Game Over alert box once the game over state has been reached
     *
     * @param human    player
     * @param computer player
     * @param b        bag of tiles
     */
    public void gameOver(Player human, Player computer, Bag b) {
        String winner = "won";
        String won = "";

        //is the game over, if the bag is empty, the players trays are empty, or
        //the bag is empty and both the players have passed
        if ((human.tray.size() == 0 && computer.tray.size() == 0 && b.size() == 0) ||
                (b.size() == 0 && humanPass && compPass)) {

            //set the win message
            if (computerScore > humanScore) {
                won = "Computer " + winner;
            } else if (computerScore == humanScore) {
                won = "You tied";
            } else {
                won = "You " + winner;
            }


            Alert alert = new Alert(Alert.AlertType.NONE,
                    "You have finished the game!\nHuman Score: " + humanScore + "\nComputer Score: " + computerScore + "\n" + won, ButtonType.OK);
            alert.setTitle("Game Over");
            alert.show();
        }
    }


    /**
     * Adds the dictionary words to the Trie,
     *
     * @param dict
     */
    public static void createDictTrie(ArrayList<String> dict) {

        for (int i = 0; i < dict.size(); i++) {
            dictTrie.insert(dict.get(i));
        }
    }


    public static void main(String[] args) throws IOException {

        BufferedReader scan;
        //creating File instance to reference text file in Java
        InputStream dict = Game.class.getClassLoader().getResourceAsStream("resources/dict.txt");
        scan = new BufferedReader(new InputStreamReader(dict));
        String line = scan.readLine();

        int runThrough = 0;

        //add words from dictionary file to list
        while (line != null) {
            dictionary.add(line);
            line = scan.readLine();

        }
        //Create the dictionary trie
        createDictTrie(dictionary);


        launch(args);

    }

    /**
     * Handels the gameplay logic
     */
    public boolean gamePlay(Bag b, Board board, Player human, Player computer) {

        /**
         * Game logic
         */

        //for human
        if (humanTurn) {
            if (boardClicked && tileClicked && !checkPlay) {
                if (trayIndex < human.tray.size()) {
                    System.out.println("Placing on the board");
                    //keeps placing tiles on board until check button is pressed
                    Tile temp = human.tray.get(trayIndex);
                    if (temp.letter == '*') {
                        temp.letter = wildCard;
                    }
                    //used for making sure all tiles on a play are either
                    //all across, or all down
                    if (placedTiles.size() >= 2) {
                        firstPlacedTile = placedTiles.get(1);
                    } else {
                        firstPlacedTile = null;
                    }
                    if (board.placeMove(rowIndex, colIndex, temp, firstPlay, firstPlacedTile)) {
                        System.out.println("Was a valid move");
                        placedTiles.add(new Coordinate(rowIndex, colIndex, temp));
                        //keeping track of where things, in case word is not valid
                        human.tray.remove(trayIndex);
                        //don't remove the tile from the tray unless it was a valid square to be placed
                        //upon
                        firstPlay = false;
                        return true;
                    } else {
                        System.out.println("Invalid Move");
                    }
                }
            }

            /**
             * We have placed all the tiles we want, and are checking the play
             */
            if (checkPlay) {
                if (board.validOverall(dictTrie, firstPlay)) {
                    if (firstPlay == true) {
                        //we played the first move, will need to make sure it
                        //was played on the middle square
                        firstPlay = false;
                    }

                    //grab the words made/modified for this turn
                    //Calculate the score
                    ArrayList<Coordinate> words = board.wordsMade(placedTiles, dictTrie);
                    System.out.println("words length is " + words.size());
                    for (int i = 0; i < words.size(); i++) {
                        System.out.println(words.get(i).tile.letter);
                    }

                    //Calculate the score
                    int tempScore = board.getSquareMultiplier(words);
                    humanScore += tempScore;
                    checkPlay = false;
                    boardClicked = false;
                    tileClicked = false;
                    humanTurn = false;
                    placedTiles.clear();
                    return true;

                } else {
                    System.out.println("The play was invalid, try again");
                    board.undo(placedTiles);
                    for (int i = 0; i < placedTiles.size(); i++) {
                        human.tray.add(placedTiles.get(i).tile);
                    }
                    placedTiles.clear();
                    checkPlay = false;
                    boardClicked = false;
                    tileClicked = false;
                    return false;
                }
            }
        } else {
            //Computer turn,
            //TODO
            //Would have called on methods from the Solver class, had I actually managed to get it to work
            //I am going to have it set humanTurn to true, so you can keep playing yourself, and racking up points
            //where the computer earns none
            humanTurn=true;
        }

        return false;

    }


    @Override
    public void start(Stage primaryStage) throws Exception {

        primaryStage.setTitle("Scrabble");
        //makes sure the app closes when the exit button is pressed
        primaryStage.setOnCloseRequest(new EventHandler<WindowEvent>() {
            @Override
            public void handle(WindowEvent t) {
                Platform.exit();
                System.exit(0);
            }
        });

        //create the bag
        Bag b = new Bag();
        //create the board
        Board board = new Board();
        //create the players, give them trays
        Player human = new Player(true, b);
        Player computer = new Player(false, b);

        GridPane gridPane = new GridPane();
        gridPane.setStyle("-fx-background-color: White");
        gridPane.setPrefSize(700, 700);
        gridPane.setPadding(new Insets(5, 5, 5, 5));

        GridPane trayPane = new GridPane();
        trayPane.setStyle("-fx-background-color: White");
        trayPane.setPrefSize(700, 150);
        trayPane.setPadding(new Insets(5, 5, 5, 5));
        trayPane.setAlignment(Pos.CENTER);

        BorderPane base = new BorderPane();
        base.setPrefSize(900, 850);
        BorderPane right = new BorderPane();
        VBox listRight = new VBox();
        right.setStyle("-fx-background-color: White");
        listRight.setSpacing(10);

        GridPane bot = new GridPane();
        bot.setPadding(new Insets(5, 5, 5, 5));
        bot.setAlignment(Pos.CENTER);

        Button check = new Button("Check Play");
        Button redraw = new Button("Redraw Tray");
        redraw.setAlignment(Pos.BOTTOM_LEFT);

        Button choose = new Button("Choose a letter");
        char al[] = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        //char al[] = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        ChoiceBox ch = new ChoiceBox(FXCollections.observableArrayList(
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        ));

        ch.setDisable(isWildDis);

        listRight.getChildren().add(redraw);
        listRight.getChildren().add(ch);
        right.setBottom(listRight);
        base.setBottom(check);
        base.setRight(right);

        //set constraints for board
        int col = 15;
        int row = 15 + 2;
        for (int c = 0; c < col; c++) {
            ColumnConstraints colConst = new ColumnConstraints();
            colConst.setPercentWidth(350 / col);
            gridPane.getColumnConstraints().add(colConst);
        }
        for (int r = 0; r < row; r++) {
            RowConstraints rowConst = new RowConstraints();
            rowConst.setPercentHeight(350 / row);
            gridPane.getRowConstraints().add(rowConst);
        }

        //set constraints for tray
        col = MAX_HAND;
        row = 2;
        for (int c = 0; c < col; c++) {
            ColumnConstraints colConst = new ColumnConstraints();
            colConst.setPercentWidth(80 / col);
            trayPane.getColumnConstraints().add(colConst);
        }
        for (int r = 0; r < row; r++) {
            RowConstraints rowConst = new RowConstraints();
            rowConst.setPercentHeight(150 / row);
            trayPane.getRowConstraints().add(rowConst);
        }

        init(gridPane, trayPane, board, check, human.tray, base, right);


        /**
         * Event Handler for clicking on the board. Sets index for rows and columns
         * based on where the user clicked on the GridPane
         */
        gridPane.setOnMousePressed(new EventHandler<MouseEvent>() {
            public void handle(MouseEvent me) {
                for (Node node : gridPane.getChildren()) {
                    node.setOnMouseClicked((MouseEvent t) -> {
                        clicks++;

                        /**
                         * index of square on the board
                         */
                        colIndex = gridPane.getColumnIndex(node);
                        rowIndex = gridPane.getRowIndex(node);
                        boardClicked = true;

                        gamePlay(b, board, human, computer);
                        update(human, computer, b, gridPane, trayPane, check, board, base, right);

                    });
                }
            }
        });


        /**
         * Event Handler for clicking on the tray. Sets index for column
         * based on where the user clicked on the tray
         */
        trayPane.setOnMousePressed(new EventHandler<MouseEvent>() {
            public void handle(MouseEvent me) {
                for (Node node : trayPane.getChildren()) {
                    node.setOnMouseClicked((MouseEvent t) -> {
                        /**
                         * index of square on the board
                         */
                        if (gridPane.getColumnIndex(node) < human.tray.size()) {
                            trayIndex = gridPane.getColumnIndex(node);
                            tileClicked = true;

                            if (human.tray.get(trayIndex).letter == '*') {
                                System.out.println("We registered it was a wildcard");
                                isWildDis = false;
                                ch.setDisable(isWildDis);

                            }

                        }
                        gamePlay(b, board, human, computer);
                        update(human, computer, b, gridPane, trayPane, check, board, base, right);
                    });
                }
            }
        });

        //check button action handler
        check.setOnMousePressed(value -> {
            checkPlay = true;
            System.out.println("Checkplay is now " + checkPlay);
            gamePlay(b, board, human, computer);
            update(human, computer, b, gridPane, trayPane, check, board, base, right);
        });

        //redraw button action handler
        redraw.setOnMousePressed(value -> {
            if(humanTurn) {
                humanTurn = false;
                System.out.println("You are using a turn to redraw your tray");
                for (int i = 0; i < human.tray.size(); i++) {
                    Tile ret = human.tray.remove(i);
                    b.replace(ret);
                }
                if (b.size() == 0) {
                    humanPass = true;
                }
                update(human, computer, b, gridPane, trayPane, check, board, base, right);
                gamePlay(b, board, human, computer);
            }
        });

        // add a listener
        ch.getSelectionModel().selectedIndexProperty().addListener(new ChangeListener<Number>() {

            // if the item of the list is changed
            public void changed(ObservableValue ov, Number value, Number new_value) {

                // set the text for the label to the selected item
                wildCard = al[new_value.intValue()];
                System.out.println("The wildcard is " + wildCard);
                isWildDis = true;
                human.tray.get(trayIndex).letter= wildCard;
                update(human,computer, b, gridPane, trayPane, check, board, base, right);
                ch.setDisable(isWildDis);
            }
        });

        gameOver(human, computer, b);

        base.setCenter(gridPane);
        base.setBottom(trayPane);

        Scene scene = new Scene(base);
        primaryStage.setScene(scene);
        primaryStage.show();


    }
}
