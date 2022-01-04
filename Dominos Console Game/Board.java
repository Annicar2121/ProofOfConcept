import java.util.LinkedList;
import java.util.ListIterator;

/**
 * Annica Roos
 * Board contains the Dominos currently placed
 */

public class Board {

    LinkedList<Domino> myBoard = new LinkedList<Domino>();

    public int addToBoard(Domino dom){
        Domino topDom= new Domino(true, 0, 0);
        Domino bottomDom= new Domino(true, 0, 0);

        if(myBoard.size() != 0){
            topDom= myBoard.getFirst();
            bottomDom= myBoard.getLast();
        }


        if(myBoard.size() == 0){
            myBoard.addFirst(dom);
            return 1;
        }
        else if((dom.secondEnd == topDom.oneEnd)){
            myBoard.addFirst(dom);
            return 1;
        }
        else if (dom.oneEnd == bottomDom.secondEnd){
            myBoard.addLast(dom);
            return 1;
        }
        else if (dom.oneEnd == 0){
            myBoard.addLast(dom);
            return 1;
        }
        else if (dom.secondEnd == 0){
            myBoard.addFirst(dom);
            return 1;
        }
        else if (topDom.oneEnd == 0){
            myBoard.addFirst(dom);
            return 1;
        }
        else if (bottomDom.secondEnd == 0){
            myBoard.addLast(dom);
            return 1;
        }
        else{
            System.out.println("Invalid Move!");
            return 0;
        }
    }

    public void printBoard(){
        int temp= 0;

        System.out.println("Board: ");

        ListIterator<Domino> iterator = this.myBoard.listIterator();

        while (iterator.hasNext()) {

            Domino current = iterator.next();
            System.out.print("[" + current.oneEnd + "|" + current.secondEnd + "]");
            temp++;
            if(temp == 7){
                temp =0;
                System.out.println();
            }
        }

        System.out.println();
        System.out.println();

    }

    public Domino firstPiece(){
        Domino temp = myBoard.getFirst();
        return temp;
    }

}
