import javafx.scene.paint.Color;
import javafx.scene.shape.Shape;

/**
 * Annica Roos
 * The Tile Class that makes up each Tile Object, and subsequently
 * used to create and draw Tiles in the GUI
 * Each tile has an x,y location, Visible/Hidden values for seperate elements
 * (elements being composed of a shape and color index value)
 */
public class Tile {

    /**
     * Instance Variables
     */
    int x;
    int y;
    boolean elementOne;
    boolean elementTwo;
    boolean elementThree;
    int c1;
    int c2;
    int c3;
    int shapeOne;
    int shapeTwo;
    int shapeThree;


    /**
     * @param x            the row index assigned to the Tile
     * @param y            the column index assigned to the Tile
     * @param elementOne   Hidden/Visible value for the first element
     * @param elementTwo   Hidden/Visible value for the second element
     * @param elementThree Hidden/Visible value for the third element
     * @param c1           Index of color for first element
     * @param c2           Index of color for second element
     * @param c3           Index of color for third element
     * @param shapeOne     Index of shape for first element
     * @param shapeTwo     Index of shape for second Element
     * @param shapeThree   Index of shape for thrird element
     */
    public Tile(int x, int y, boolean elementOne, boolean elementTwo,
                boolean elementThree, int c1, int c2, int c3, int shapeOne,
                int shapeTwo, int shapeThree) {
        this.x = x;
        this.y = y;
        this.elementOne = elementOne;
        this.elementTwo = elementTwo;
        this.elementThree = elementThree;
        this.c1 = c1;
        this.c2 = c2;
        this.c3 = c3;
        this.shapeOne = shapeOne;
        this.shapeTwo = shapeTwo;
        this.shapeThree = shapeThree;
    }


}
