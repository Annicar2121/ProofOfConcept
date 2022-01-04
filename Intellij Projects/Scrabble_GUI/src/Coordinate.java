/**
 * Annica Roos
 * Pairs of coordinates to keep track of where human tiles get placed, before being checked as valid
 * words
 */
public class Coordinate {
    int row;
    int col;
    Tile tile;

    public Coordinate(int row, int col, Tile tile){
        this.row=row;
        this.col= col;
        this.tile=tile;
    }

    public int getRow(){
        return this.row;
    }

    public int getCol(){
        return this.col;
    }

    public Tile getTile(){
        return this.tile;
    }
}
