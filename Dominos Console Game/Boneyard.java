import java.util.Collections;
import java.util.LinkedList;
import java.util.ListIterator;
import java.util.Random;

/**
 * Annica Roos
 */

public class Boneyard {

    public static int NUM_DOTS;
    public static int ROWS;
    public static int COLUMNS;
    public static int TOTAL;

    //There are 28 Dominos total
    public LinkedList <Domino> yard = new LinkedList<Domino>();


    public Boneyard(int numDots, int rows, int col) {
        this.yard = yard;
        this.NUM_DOTS = numDots;
        this.ROWS= rows;
        this.COLUMNS= col;
        this.TOTAL = ROWS*COLUMNS;
    }

    /**
     * Fills the boneyard with dominos
     */
    public void fillYard() {
        int temp = 0;
        int num = NUM_DOTS;
        int k = 0;
        int i = 0;

        for (int j = 0; j < NUM_DOTS + 1; j++) {
            for (int h = temp; h < NUM_DOTS + 1; h++) {
                yard.add(new Domino(false, j, h));
                k++;
            }
            temp++;
        }


    }

    /**
     * grabs the first thing in the boneyard, and removes it
     * @return removes first thing in the boneyard
     */
    public Domino getDomino(){
        return yard.removeFirst();
    }


    /**
     * Shuffles the array of dominos at the start of the game
     * Uses Fisher–Yates algorithm modified for two-dimensional arrays
     * https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
     */
    public void shuffle() {

        Collections.shuffle(yard);

    }

    /**
     * Checks if the boneyard is empty
     * @return false if nonempty
     */
    public boolean empty(){
        if(yard.size() == 0){
            return true;
        }
        else{
            return false;
        }
    }

    /**
     * Prints a representation of the boneyard to the console
     */
    public void printYard() {
        int temp= 0;

        System.out.println("Boneyard has " + yard.size() + " elements:");

        ListIterator<Domino> iterator = this.yard.listIterator();

        while (iterator.hasNext()) {

            Domino current = iterator.next();
                System.out.print("[" + current.oneEnd + "|" + current.secondEnd + "]");
                temp++;
                if(temp == 7){
                    temp =0;
                    System.out.println();
                }
            }

    }


}
