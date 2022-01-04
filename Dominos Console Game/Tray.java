import java.util.LinkedList;
import java.util.ListIterator;

/**
 * Annica Roos
 */

public class Tray {

    LinkedList<Domino> hand = new LinkedList<Domino>();

    public Tray (){
        this.hand= hand;
    }

    /**
     * Adds dominos to the players tray/hand
     * @param newDom domino being given from the boneyard
     */
    public void addDomino(Domino newDom){
        hand.add(newDom);

    }

    public void printHand(){
        ListIterator<Domino> iterator = this.hand.listIterator();

        while (iterator.hasNext()) {

            Domino current = iterator.next();
            System.out.print("[" + current.oneEnd + "|" + current.secondEnd + "]");
            System.out.println();

        }
    }

    public Domino removeDomino(int numPlace){

        return hand.removeFirst();
    }

    public Domino removeAll(){
        return hand.removeFirst();
    }

}
