import java.lang.reflect.Array;
import java.util.ArrayList;

/**
 * Annica Roos
 * List of tiles that represent what player has
 * in their hand/tray
 */

public class Tray {

    //the amount of tiles you can have/must always have
    private static final int NUM= 7;
    private ArrayList<Tile> tray= new ArrayList<>();

    public Tray(Bag b){
        this.tray= fillTray(b);
    }

    /**
     * Calculates how many tiles are need, fills the tray
     * @param b the bag being pulled from
     * @return the tray filled
     */
    public ArrayList<Tile> fillTray(Bag b) {

        ArrayList<Tile> temp = new ArrayList<>();
        temp.addAll(tray);

        if(tray.size() != NUM) {
            int needed = NUM - tray.size();

            for (int i = 0; i < needed; i++) {
                Tile t = b.pull();
                if (t == null) {
                    i = needed;
                } else {
                    temp.add(t);
                }
            }

            return temp;
        }
        else{
            temp= this.tray;
            return temp;
        }

    }

    public Tray renew(Bag b){
        this.tray= fillTray(b);
        return this;
    }

    /**
     * Removes tiles from tray
     * @param i index
     * @return tile
     */
    public Tile remove(int i){
        Tile temp= tray.get(i);
        tray.remove(i);
        return temp;
    }

    public void add(Tile t){
        this.tray.add(t);
    }

    /**
     * Returns what the tile is at index, without removing
     * @param i index
     * @return
     */
    public Tile get(int i){
        return tray.get(i);
    }

    public int size(){
        return this.tray.size();
    }

    /**
     * Prints console representation of the tray/hand
     */
    public void printTray(){
        System.out.println("Printing Tray:");
        for(int i=0; i< tray.size(); i++){
            System.out.print(tray.get(i).letter + ", ");
        }
        System.out.println();
    }


}
