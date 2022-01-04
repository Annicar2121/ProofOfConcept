import java.util.ArrayList;
import java.util.Collections;
import java.util.EmptyStackException;

/**
 * Annica Roos
 * Class for a bag of all the tiles we have in general scrabble game
 */

public class Bag {

    private static final int NUM_TILES=96;

    private ArrayList<Tile> bag;

    public Bag(){
        this.bag= createBag();
    }

    /**
     * Create the tiles of all letters in a reg. scrabble game
     * using list of frequencies given by Brooke
     * * 0 2
     * e 1 12
     * a 1 9
     * i 1 9
     * o 1 8
     * n 1 6
     * r 1 6
     * t 1 6
     * l 1 4
     * s 1 4
     * u 1 4
     * d 2 4
     * g 2 3
     * b 3 2
     * c 3 2
     * m 3 2
     * p 3 2
     * f 4 2
     * h 4 2
     * v 4 2
     * w 4 2
     * y 4 2
     * k 5 1
     * j 8 1
     * x 8 1
     * q 10 1
     * z 10 1
     * will shuffle here also
     * @return a bag of shuffled scrabble letters
     */
    public ArrayList<Tile> createBag(){
        ArrayList<Tile> temp= new ArrayList<>();

        //adding blanks
        temp.add(new Tile ('*'));
        temp.add(new Tile ('*'));

        //adding e, k, j, x, q, z
        for(int i= 0; i<12; i++){
            temp.add(new Tile('e'));
            if(i<1){
                temp.add(new Tile('k'));
                temp.add(new Tile('j'));
                temp.add(new Tile('x'));
                temp.add(new Tile('q'));
                temp.add(new Tile('z'));
            }
        }

        //adding a, i, o, g
        for(int j=0; j<9; j++){
            temp.add(new Tile('a'));
            temp.add(new Tile('i'));
            if(j < 8){
                temp.add(new Tile('o'));
            }

            if(j<3){
                temp.add(new Tile('g'));
            }
        }

        //adding n, r, t, l, s, u, d
        for(int k=0; k<6; k++){
            temp.add(new Tile('n'));
            temp.add(new Tile('r'));
            temp.add(new Tile('t'));

            if(k < 4){
                temp.add(new Tile('l'));
                temp.add(new Tile('s'));
                temp.add(new Tile('u'));
                temp.add(new Tile('d'));
            }
        }

        //adding b, c, m, p, f, h, v, w, y
        for(int f=0; f<2; f++){
            temp.add(new Tile('b'));
            temp.add(new Tile('c'));
            temp.add(new Tile('m'));
            temp.add(new Tile('p'));
            temp.add(new Tile('f'));
            temp.add(new Tile('h'));
            temp.add(new Tile('v'));
            temp.add(new Tile('w'));
            temp.add(new Tile('y'));
        }

        temp= shuffle(temp);


        return temp;
    }

    /**
     * Shuffles tiles in the bag
     * @param un the bag of tiles being shuffled
     * @return shuffled bag
     */
    public ArrayList<Tile> shuffle (ArrayList<Tile> un){
        ArrayList<Tile> temp= un;
        Collections.shuffle(temp);
        return temp;
    }

    public int size(){
        return bag.size();
    }


    /**
     * Pulls tile from the bag to give to player tray
     * @return tile
     */
    public Tile pull()  {
        if(this.bag.isEmpty()) {
            System.out.println("The bag is empty!");
            return null;
        }
        else{
            Tile temp = this.bag.remove(0);
            return temp;

        }
    }

    /**
     * Replaces Tiles for redrawing purposes
     * @param t Tile being added back to the bag
     */
    public void replace(Tile t){
        this.bag.add(t);
    }

    /**
     * Prints a console representation of the tiles in the bag
     */
    public void printBag(){
        for(int i=0; i<bag.size(); i++ ){
            System.out.println(this.bag.get(i).letter);
        }
    }


}
