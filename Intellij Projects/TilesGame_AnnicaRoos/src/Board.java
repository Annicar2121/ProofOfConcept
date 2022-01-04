import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.shape.Rectangle;
import javafx.scene.shape.Shape;

import java.util.Collections;
import java.util.LinkedList;
import java.util.Random;

/**
 * Annica Roos
 * The Board Classes creates the board according to the ROW and COLUMN sizes passed
 * in by the tilesGUI. It creates Tiles Objects and fills an array with them,creates
 * pairs for each Tiles object, and does check handling for matches, and if
 * every Tile element is set to false (hidden).
 **/

public class Board {

    /**
     * Instance Variables
     **/
    int ROWS;
    int COLUMNS;
    int MAX;

    /**
     * Board utlizes an array of Tile Objects, and fills the array
     **/
    public Tile[] MYTILES;


    /**
     * temporary color for tiles
     **/
    private final Color TEMP = Color.WHITESMOKE;

    /**
     * Contructor
     **/
    public Board(int ROWS, int COLUMNS) {
        this.ROWS = ROWS;
        this.COLUMNS = COLUMNS;
        this.MYTILES = new Tile[ROWS * COLUMNS];
        this.MAX = ROWS * COLUMNS;
    }


    /**
     * fill simply makes the tiles with their elements set to HIDDEN and the temp
     * colors/shapes EVENTUALLY this will be x,y coordinates based on info from
     *
     * @param numTiles is the number of Tiles we are making, IT MUST BE EVEN
     **/
    public void fill(int numTiles) {

        int i = 0;
        int k = 0;
        int x = 0;
        int y = 0;

        while (i < numTiles) {
            MYTILES[i] = new Tile(x, y, false, false, false, 0, 0, 0, 0,
                    0, 0);

            i++;
            y++;
            if (y == ROWS) {
                y = 0;
                x++;
            }

        }

    }


    /**
     * setPairs will place colors and shapes in the tiles and make sure they have
     * matches elements are set to false (HIDDEN) to start, so when creating pairs
     * on the board, we place elements in spaces that haven't been do it in parts,
     * start with the first elements and set those, move on to the next two
     * Error/Bug: The seed is the same everytime you run it, so the Tiles are assigned the
     * same shapes and colors on every launch of the app
     **/
    public void setPairs() {
        int maxColor = 6;
        int maxShape = 4;
        Random ranIndex = new Random(MAX);
        Random ranColor = new Random(maxColor);
        Random ranShape = new Random(maxShape);

        int ranIndexVal = 0;

        int i = 0;
        int j = 0;
        int k = 0;

        int tempCol = 0;
        int tempShape = 0;


        //create pairs for the elements
        while (i < MAX) {

            //max value of the number of tiles
            ranIndexVal = ranIndex.nextInt(MAX);
            tempCol = ranColor.nextInt(maxColor);
            tempShape = ranShape.nextInt(maxShape);

            if (MYTILES[i].elementOne == false &&
                    MYTILES[ranIndexVal].elementOne == false && ranIndexVal != i) {

                MYTILES[i].shapeOne = tempShape;
                MYTILES[i].c1 = tempCol;
                MYTILES[i].elementOne = true;
                MYTILES[ranIndexVal].shapeOne = tempShape;
                MYTILES[ranIndexVal].c1 = tempCol;
                MYTILES[ranIndexVal].elementOne = true;
            }
            if (MYTILES[i].elementOne != false) {
                i++;
            }
        }

        //set pair for element two
        while (k < MAX) {

            //max value of the number of tiles
            ranIndexVal = ranIndex.nextInt(MAX);
            tempCol = ranColor.nextInt(maxColor);
            tempShape = ranShape.nextInt(maxShape);

            if (MYTILES[k].elementTwo == false &&
                    MYTILES[ranIndexVal].elementTwo == false && ranIndexVal != k) {

                while ((MYTILES[k].shapeOne == tempShape &&
                        MYTILES[ranIndexVal].c1 == tempCol)) {
                    tempCol = ranColor.nextInt(maxColor);
                    tempShape = ranShape.nextInt(maxShape);
                }

                MYTILES[k].shapeTwo = tempShape;
                MYTILES[k].c2 = tempCol;
                MYTILES[k].elementTwo = true;
                MYTILES[ranIndexVal].shapeTwo = tempShape;
                MYTILES[ranIndexVal].c2 = tempCol;
                MYTILES[ranIndexVal].elementTwo = true;
                k++;
            } else {

            }
            if (MYTILES[k].elementTwo != false) {
                k++;
            }
        }

        //set pairs for third element
        while (j < MAX) {
            //max value of the number of tiles
            ranIndexVal = ranIndex.nextInt(MAX);
            tempCol = ranColor.nextInt(maxColor);
            tempShape = ranShape.nextInt(maxShape);

            if (MYTILES[j].elementThree == false && MYTILES[ranIndexVal].elementThree == false && ranIndexVal != j) {
                while ((MYTILES[j].shapeOne == tempShape && MYTILES[ranIndexVal].c1 == tempCol) ||
                        (MYTILES[j].shapeTwo == tempShape && MYTILES[ranIndexVal].c2 == tempCol)) {
                    tempCol = ranColor.nextInt(maxColor);
                    tempShape = ranShape.nextInt(maxShape);
                }
                if (tempShape == MYTILES[j].shapeOne) {
                    tempShape = ranShape.nextInt(maxShape);
                }

                MYTILES[j].shapeThree = tempShape;
                MYTILES[j].c3 = tempCol;
                MYTILES[j].elementThree = true;
                MYTILES[ranIndexVal].shapeThree = tempShape;
                MYTILES[ranIndexVal].c3 = tempCol;
                MYTILES[ranIndexVal].elementThree = true;

                j++;
            }

            if (MYTILES[j].elementTwo != false) {
                j++;
            }


        }
    }


    /**
     * Will shuffle the array elements after filling the array,
     * so they are in random order when used to create the GUI
     * might be a bit redundant
     **/
    public void shuffleArray() {
        Tile temp = new Tile(0, 0, true, true, true, 0, 0, 0, 0, 0, 0);
        Random r = new Random();
        int ranNum = 0;

        for (int i = 0; i < MAX; i++) {
            ranNum = r.nextInt(MAX);
            temp = MYTILES[i];
            MYTILES[i] = MYTILES[ranNum];
            MYTILES[ranNum] = temp;

        }

    }

    /**
     * giveTiles() will send the tiles to the mainloop, so they can be
     * passed to the GUI
     **/
    public Tile[] giveTiles() {
        return MYTILES;
    }


    /**
     * checkGameOver() loops through all of the Tiles in the array
     * and makes sure that every element has been set to false (hidden)
     * returns true if every element is Hidden, and false if not. Value of
     * this will trigger the Game Over Alert Box inside the GUI
     */
    public boolean checkGameOver() {
        boolean temp = true;
        for (int i = 0; i < MAX; i++) {
            if (MYTILES[i].elementOne == true || MYTILES[i].elementTwo == true ||
                    MYTILES[i].elementThree == true) {
                return false;
            }
        }

        return true;
    }

    /**
     * It will check to see if every element in the Tile is hidden
     *
     * @param x is the row index that was clicked, and we need to check
     * @param y is the column index that was clicked, and is being checked
     * @return true if all are hidden, false otherwise
     */
    public boolean checkCleared(int x, int y) {
        int max = ROWS * COLUMNS;
        int indexOne = 0;
        Tile temp = new Tile(0, 0, false, false, false, 0, 0, 0, 0, 0, 0);

        //grab the tiles we are looking at from the list
        for (int i = 0; i < max; i++) {
            if (MYTILES[i].x == y && MYTILES[i].y == x) {
                temp = MYTILES[i];
                indexOne = i;
            }
        }
        if (temp.elementOne == false && temp.elementTwo == false &&
                temp.elementThree == false) {
            return true;
        } else {
            return false;
        }
    }


    /**
     * First grabs the specific Tiles we are looking at, based on gui input
     * and then loops through every possible match of elements until one returns true
     * or they never do, and there are no matches
     *
     * @param x  row index of first tile clicked on
     * @param y  column index of first tile clicked on
     * @param x2 row index of second tile clicked
     * @param y2 column index of second tile clicked
     * @return returns true if any of the elements in the two selected tiles match, false if none
     */
    public boolean checkMatch(int x, int y, int x2, int y2) {
        int max = ROWS * COLUMNS;
        int indexOne = 0;
        int indexTwo = 0;
        Tile temp = new Tile(0, 0, false, false, false, 0, 0, 0, 0, 0, 0);
        Tile temp2 = new Tile(0, 0, false, false, false, 0, 0, 0, 0, 0, 0);

        //grab the tiles we are looking at from the list
        for (int i = 0; i < max; i++) {
            if (MYTILES[i].x == y && MYTILES[i].y == x) {
                temp = MYTILES[i];
                indexOne = i;
            }
            if (MYTILES[i].x == y2 && MYTILES[i].y == x2) {
                temp2 = MYTILES[i];
                indexTwo = i;
            }
        }

        if (temp.elementOne == true && temp2.elementOne == true) {
            //check each element corresponding color and shape
            if (temp.shapeOne == temp2.shapeOne && temp.c1 == temp2.c1) {
                System.out.println("Element one matched");
                MYTILES[indexOne].elementOne = false;
                MYTILES[indexTwo].elementOne = false;
                return true;
            }

        }
        if (temp.elementTwo == true && temp2.elementTwo == true) {
            if (temp.shapeTwo == temp2.shapeTwo && temp.c2 == temp2.c2) {
                System.out.println("Second Elements Matched");
                MYTILES[indexOne].elementTwo = false;
                MYTILES[indexTwo].elementTwo = false;
                return true;
            }
        }

        if (temp.elementTwo == true && temp2.elementOne == true) {
            if (temp.shapeTwo == temp2.shapeOne && temp.c2 == temp2.c1) {
                System.out.println("Second Elements Matched");
                MYTILES[indexOne].elementTwo = false;
                MYTILES[indexTwo].elementOne = false;
                return true;
            }
        }
        if (temp.elementOne == true && temp2.elementTwo == true) {
            if (temp.shapeOne == temp2.shapeTwo && temp.c1 == temp2.c2) {
                System.out.println("Second Elements Matched");
                MYTILES[indexOne].elementOne = false;
                MYTILES[indexTwo].elementTwo = false;
                return true;
            }
        }

        if (temp.elementThree == true && temp2.elementThree == true) {
            if (temp.shapeThree == temp2.shapeThree && temp.c3 == temp2.c3) {
                MYTILES[indexOne].elementThree = false;
                MYTILES[indexTwo].elementThree = false;
                return true;
            }
        }

        //element two and three
        if (temp.elementTwo == true && temp2.elementThree == true) {
            if (temp.shapeTwo == temp2.shapeThree && temp.c2 == temp2.c3) {
                MYTILES[indexOne].elementTwo = false;
                MYTILES[indexTwo].elementThree = false;
                return true;
            }
        }
        //element three and one
        if (temp.elementOne == true && temp2.elementThree == true) {
            if (temp.shapeOne == temp2.shapeThree && temp.c1 == temp2.c3) {
                MYTILES[indexOne].elementOne = false;
                MYTILES[indexTwo].elementThree = false;
                return true;
            }
        }

        if (temp.elementThree == true && temp2.elementTwo == true) {
            if (temp.shapeThree == temp2.shapeTwo && temp.c3 == temp2.c2) {
                MYTILES[indexOne].elementThree = false;
                MYTILES[indexTwo].elementTwo = false;
                return true;
            }
        }
        //element three and one
        if (temp.elementThree == true && temp2.elementOne == true) {
            if (temp.shapeThree == temp2.shapeOne && temp.c3 == temp2.c1) {
                MYTILES[indexOne].elementThree = false;
                MYTILES[indexTwo].elementOne = false;
                return true;
            }
        } else {
            return false;
        }

        return false;
    }


    /**
     * Prints a basic coordinate value of the Board, and the shapes
     * and colors assigned to the elements
     */
    public void printBoard() {
        int k = 0;
        while (k < MAX) {
            for (int i = 0; i < ROWS; i++) {
                for (int j = 0; j < COLUMNS; j++) {
                    System.out.print("(");
                    System.out.print(MYTILES[k].x);
                    System.out.print(", ");
                    System.out.print(MYTILES[k].y);
                    System.out.print(") S1: ");
                    System.out.print(MYTILES[k].shapeOne);
                    System.out.print(" C1: ");
                    System.out.print(MYTILES[k].c1);
                    System.out.print(" S2: ");
                    System.out.print(MYTILES[k].shapeTwo);
                    System.out.print(" C2: ");
                    System.out.print(MYTILES[k].c2);
                    System.out.print(" S3: ");
                    System.out.print(MYTILES[k].shapeThree);
                    System.out.print(" C3: ");
                    System.out.print(MYTILES[k].c3);
                    k++;
                }
                System.out.println();
            }
        }
    }

}
