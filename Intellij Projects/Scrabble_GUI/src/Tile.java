/**
 * Annica Roos
 * Class for letter tiles
 */

public class Tile {

    char letter;
    int value;

    public Tile(char letter){
        this.letter= letter;
        this.value=getValue(letter);

    }

    /**
     * Hardcoded values for what each letter is worth
     * @param letter
     * @return
     */
    public int getValue(char letter) {

        if (letter == '*') {
            return 0;
        } else if (letter == 'e') {
            return 1;
        } else if (letter == 'a') {
            return 1;
        } else if (letter == 'i') {
            return 1;
        } else if (letter == 'o') {
            return 1;
        } else if (letter == 'n') {
            return 1;
        } else if (letter == 'r') {
            return 1;
        } else if (letter == 't') {
            return 1;
        } else if (letter == 'l') {
            return 1;
        } else if (letter == 's') {
            return 1;
        } else if (letter == 'u') {
            return 1;
        } else if (letter == 'd') {
            return 2;
        } else if (letter == 'g') {
            return 2;
        } else if (letter == 'b') {
            return 3;
        } else if (letter == 'c') {
            return 3;
        } else if (letter == 'm') {
            return 3;
        } else if (letter == 'p') {
            return 3;
        } else if (letter == 'f') {
            return 4;
        } else if (letter == 'h') {
            return 4;
        } else if (letter == 'v') {
            return 4;
        } else if (letter == 'w') {
            return 4;
        } else if (letter == 'y') {
            return 4;
        } else if (letter == 'k') {
            return 5;
        } else if (letter == 'j') {
            return 8;
        } else if (letter == 'x') {
            return 8;
        } else if (letter == 'q') {
            return 10;
        } else if (letter == 'z') {
            return 10;
        }
        else{
            return 0;
        }
    }

}
