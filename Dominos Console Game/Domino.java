/**
 * Annica Roos
 */

public class Domino {

    /**
     * Instance Variables
     */
    boolean visible;
    int oneEnd;
    int secondEnd;

    /**
     *
     * @param visible true if the domino is faceUp, and false if the domino is faceDown
     * @param oneEnd the number/ value of dots on the one end of the domino
     * @param secondEnd the number/ value of dots on the second end of the domino
     */
    public Domino(boolean visible, int oneEnd, int secondEnd){
    this.secondEnd = secondEnd;
    this.oneEnd = oneEnd;
    this.visible = visible;

}

    /**
     * Flips the two ends of the domino
     */
    public void flip(){
        int temp= this.oneEnd;
        this.oneEnd= this.secondEnd;
        this.secondEnd= temp;
}


}
