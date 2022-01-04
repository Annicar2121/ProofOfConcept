/**
 * Annica Roos
 * The squares on the board
 * each square has a reference to the row and col it is in
 * a char for the letter/tile placed on it, a representation special for bonuses
 * and a boolean to see if a tile has been placed on it or not
 */

public class Square {

    int row;
    int col;
    char letter;
    char special;
    boolean filled;
    int value;
    Tile tile;

    public Square(int row, int col, char letterPlaced, char special, boolean filled, Tile tile) {
        this.row = row;
        this.col = col;
        this.letter = tile.letter;
        this.special = special;
        this.filled = filled;
        this.tile=tile;
    }

    public boolean isFilled() {
        return this.filled;
    }

    public int val(){
        return this.value;
    }

    public int addBonus(int bonus){
        return this.value*bonus;
    }

    /**
     * Calculating bonus type
     * @param special
     * @return
     */
    public int getSpecial(char special) {
        return 0;
    }


    public void printSquare() {
        System.out.println("Row: " + this.row + ", Col: " + this.col + ", Special: " + this.special );
    }

}


