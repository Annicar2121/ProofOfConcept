/**
 * Annica Roos
 * Class that holds the height and width values
 * for rectangles, to be used when creating Tiles
 * in the Board, and for drawing in the gui. These are not actual
 * values, but the value of the index being pointed to.
 */

public class RectPair {

    /**
     * Instance Variables
     */
    int height;
    int width;


    /**
     * @param height sets the height index the rectangle will have
     * @param width  sets the width index the rectangle will have
     */
    public RectPair(int height, int width) {
        this.width = width;
        this.height = height;
    }


    /**
     * @return the height index assigned
     */
    public int getHeight() {
        return height;
    }

    /**
     * @return the width index assigned
     */
    public int getWidth() {
        return width;
    }

}
