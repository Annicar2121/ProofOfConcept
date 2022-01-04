/**
 * Annica Roos
 * Player classes, that hold a player's turn, score, and tray
 */

public class Player  {

    int score;
    boolean turn;
    Tray tray;
    Bag b;

    public Player(boolean turn, Bag b){
        this.turn=turn;
        this.tray= new Tray(b);
        this.b=b;
    }

    public void refill(Bag b){
       this.tray= this.tray.renew(b);
    }

    /**
     * Adds the score passed from the
     * @param newScore
     */
    public void score(int newScore){
        this.score+= newScore;
    }


}
