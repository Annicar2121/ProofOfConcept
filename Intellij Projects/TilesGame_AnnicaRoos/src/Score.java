/**
 * Annica Roos
 * Class that keeps track of the current score,
 * and the high score, and sets both of them
 * according to input from the gui
 */
public class Score {

    /**
     * Instance Variables
     */
    int CURRENTSCORE;
    int HIGHSCORE;


    /**
     * Constructor
     *
     * @param currentScore the current amount of clicks unbroken
     * @param highScore    the longest streak attained
     */
    public Score(int currentScore, int highScore) {
        this.CURRENTSCORE = currentScore;
        this.HIGHSCORE = highScore;
    }

    /**
     * @return the current unbroken streak
     */
    public int getCURRENTSCORE() {
        return CURRENTSCORE;
    }

    /**
     * @return the longest streak attained
     */
    public int getHIGHSCORE() {
        return HIGHSCORE;
    }

    /**
     * @param currentChain the number of clicks in the GUI without choosing Tiles that do not match
     * @return the current unbroken streak
     */
    public int setCurrentScore(int currentChain) {
        int current = currentChain;
        this.CURRENTSCORE = currentChain;
        if (currentChain > HIGHSCORE) {
            this.HIGHSCORE = currentChain;
            return current;
        }

        return current;
    }

    /**
     * Prints the stored scores to the console, if
     * one chooses to do so
     */
    public void printScore() {
        System.out.print("Current Score is: ");
        System.out.println(this.CURRENTSCORE);

        System.out.print("High Score is: ");
        System.out.println(this.HIGHSCORE);

    }
}
