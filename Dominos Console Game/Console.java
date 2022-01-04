import java.util.Scanner;

/**
 * Annica Roos
 */

public class Console {

    static final int DOT_SIZE= 6;
    static final int HAND_SIZE= 7;
    static final int ROWS= 4;
    static final int COLUMNS= 7;

    static boolean GAME_OVER= false;
    static int HUMAN_SCORE;
    static int COMPUTER_SCORE;
    static boolean FIRST_PLAY;
    static boolean HUMAN_TURN;
    static boolean COMPUTER_TURN;

    public static void main(String args[]){

        System.out.println(".:+:. Welcome to the Dominos Game! .:+:.");
        System.out.println();

        /**
         * Create the boneyard, fill it with dominos, shuffle
         */
        Boneyard yard = new Boneyard(DOT_SIZE, ROWS, COLUMNS);
        yard.fillYard();
        yard.shuffle();
        //yard.printYard();

        /**
         * Create the Board
         */
        Board gameBoard= new Board();

        /**
         * Create the human and computer players, give them trays filled with dominos
         */
        Player human= new Player();
        Player computer= new Player();

        /**
         * Give player and computer 7 dominos each
         */
        for(int i= 0; i<HAND_SIZE; i++)
        {
            human.addDomino(yard.getDomino());
            computer.addDomino(yard.getDomino());
        }

        /**
         * Print out the hands of the Computer and the Human
         */
        FIRST_PLAY=true;
        HUMAN_TURN=true;
        COMPUTER_TURN= false;


        while(GAME_OVER == false) {
            human.printHand();
            gameBoard.printBoard();
            System.out.print("(This is Comp)");
            computer.printHand();

            // Using Scanner for Getting Input from User
            Scanner in = new Scanner(System.in);

            //int num = in.nextInt();
            //System.out.println("You entered string "+s);
            //System.out.println("You entered integer " + num);

            if(FIRST_PLAY== true){
                System.out.println("Please type the index of the first Domino you would like to place on the board.");
                int s = in.nextInt();
               Domino temp= human.myhand.remove(s);
               gameBoard.addToBoard(temp);
               FIRST_PLAY=false;
               HUMAN_TURN= false;
               COMPUTER_TURN= true;


            }

            else if(FIRST_PLAY == false){
                if(COMPUTER_TURN== true){
                    System.out.println("Computer is playing");
                    System.out.println();
                    int index = computer.placeCom(gameBoard.firstPiece());
                    if(index > -1) {
                        System.out.println("Index returned was: " + index);
                        gameBoard.addToBoard(computer.myhand.remove(index));
                    }
                    //else there was no match, pull from Boneyard
                    else{
                        System.out.println("Computer pulls from Boneyard");
                        computer.addDomino(yard.getDomino());
                    }
                    COMPUTER_TURN= false;
                    HUMAN_TURN= true;

                }
                else if(HUMAN_TURN == true) {
                    Domino temp;
                    int valid;
                    System.out.println("Type index of the Domino you would like to place on the board.");
                    int s = in.nextInt();
                    temp= human.myhand.remove(s);
                    System.out.println("Flip the Domino? 0: no, 1: yes");

                    int confirm= in.nextInt();

                    if(confirm == 1){
                        temp.flip();
                        valid= gameBoard.addToBoard(temp);

                    }
                    else {
                       valid= gameBoard.addToBoard(temp);
                    }
                    if(valid==1){
                        HUMAN_TURN= false;
                        COMPUTER_TURN= true;
                    }
                    else{
                        human.myhand.add(s, temp);
                        System.out.println("Try Again");
                    }
                }
            }
            boolean check= checkOver(yard.empty());

            if(check == true){
                GAME_OVER= true;
            }


        }

        if(GAME_OVER == true){
            HUMAN_SCORE= human.countScore();
            COMPUTER_SCORE= computer.countScore();
            System.out.println("Game is over.");
            System.out.println("Computer Score: "+ COMPUTER_SCORE);
            System.out.println("Human Score: "+ HUMAN_SCORE);

            if(HUMAN_SCORE > COMPUTER_SCORE){
                System.out.println("Computer won!");
            }
            else if(COMPUTER_SCORE > HUMAN_SCORE){
                System.out.println("You won!");
            }
            else{
                System.out.println("You tied!");
            }
        }

    }


    /**
     * Checks if the Boneyard is empty, and if there are no more possible
     * moves to play on either the human or computers hands, will trigger
     * counting the final score
     * @return
     */
    public static boolean checkOver(boolean yardEmpty){
        if(yardEmpty == true){
            return true;
        }
        else{
            return false;
        }
    }



}
