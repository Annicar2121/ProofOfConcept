import java.util.LinkedList;
import java.util.ListIterator;

/**
 * Annica Roos
 */

public class Player {

public LinkedList<Domino> myhand = new LinkedList<Domino>();
int SCORE;

public Player (){
    this.myhand= myhand;
    this.SCORE=SCORE;
}

public int countScore(){
    int temp=0;
    ListIterator<Domino> iterator = this.myhand.listIterator();

    while (iterator.hasNext()) {

        Domino tempDom = iterator.next();
        temp+= tempDom.oneEnd;
        temp+= tempDom.secondEnd;

    }

    SCORE= temp;
    return SCORE;
}

    public void addDomino(Domino newDom){

        myhand.add(newDom);

    }

    public void printHand(){

        ListIterator<Domino> iterator = this.myhand.listIterator();
        System.out.println("Your Hand is:");

        while (iterator.hasNext()) {

            Domino current = iterator.next();
            System.out.print("[" + current.oneEnd + "|" + current.secondEnd + "]");
        }

        System.out.println();
        System.out.println();

    }

    /**
     * Basic computer strategy, places first matched domino
     * @param open domino trying to be matched to
     * @return index of the domino that matches
     */
    public int placeCom(Domino open){
        int i= 0;
        ListIterator<Domino> iterator = this.myhand.listIterator();

        while(iterator.hasNext()){
            Domino current = iterator.next();
            if(current.oneEnd == open.secondEnd){
                return i;
            }
            else if (current.secondEnd == open.oneEnd){
                return i;
            }
            else if (current.oneEnd == open.oneEnd){
                current.flip();
                myhand.remove(i);
                myhand.add(i, current);
                return i;
            }
            else if (current.secondEnd == open.secondEnd){
                current.flip();
                myhand.remove(i);
                myhand.add(i, current);
                return i;
            }
            else if(current.oneEnd == 0){
                return i;
            }
            else if(current.secondEnd == 0){
                return i;
            }
            else{
                i++;
            }
        }

        System.out.println("Should be returning -1");
        return -1;

    }

}
