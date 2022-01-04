import java.util.ArrayList;

/**
 * Annica Roos
 * Board class for setting up specific squares on the board, using the Square class
 */

public class Board {

    private static final int NUM_ROWS = 15; //cols is the same for standard board
    private Square[][] board;

    //cannot place duplicate words
    private static ArrayList<String> alreadyPlacedWords = new ArrayList<>();


    public Board() {
        this.board = createBoard(NUM_ROWS);
    }

    /**
     * A hardcoded standard board of scrabble
     *
     * @param numBoard the number of rows and columns
     * @return the created, empty board
     */
    public static Square[][] createBoard(int numBoard) {
        int index = 0;
        Square[][] temp = new Square[numBoard][numBoard];
        Tile empty = new Tile('?');

        //. = empty space
        // D = double WORD
        //T = triple WORD
        //d= double LETTER
        //t= triple LETTER
        //X = center square w/ star, which is a double WORD

        /**
         * Creating triple word spaces
         */
        temp[0][0] = new Square(0, 0, '?', 'T', false, empty);
        temp[0][7] = new Square(0, 7, '?', 'T', false, empty);
        temp[0][14] = new Square(0, 14, '?', 'T', false, empty);
        temp[7][0] = new Square(7, 0, '?', 'T', false, empty);
        temp[7][14] = new Square(7, 14, '?', 'T', false, empty);
        temp[14][0] = new Square(14, 0, '?', 'T', false, empty);
        temp[14][7] = new Square(14, 7, '?', 'T', false, empty);
        temp[14][14] = new Square(14, 14, '?', 'T', false, empty);

        /**
         * Creating star space
         */
        temp[7][7] = new Square(7, 7, '?', 'X', false, empty); //this is the star square

        /**
         * Creating double word spaces
         */
        temp[1][1] = new Square(1, 1, '?', 'D', false, empty);
        temp[2][2] = new Square(2, 2, '?', 'D', false, empty);
        temp[3][3] = new Square(3, 3, '?', 'D', false, empty);
        temp[4][4] = new Square(4, 4, '?', 'D', false, empty);
        temp[1][13] = new Square(1, 13, '?', 'D', false, empty);
        temp[2][12] = new Square(2, 12, '?', 'D', false, empty);
        temp[3][11] = new Square(3, 11, '?', 'D', false, empty);
        temp[4][10] = new Square(4, 10, '?', 'D', false, empty);
        temp[13][1] = new Square(13, 1, '?', 'D', false, empty);
        temp[12][2] = new Square(12, 2, '?', 'D', false, empty);
        temp[11][3] = new Square(11, 3, '?', 'D', false, empty);
        temp[10][4] = new Square(10, 4, '?', 'D', false, empty);
        temp[13][13] = new Square(13, 13, '?', 'D', false, empty);
        temp[12][12] = new Square(12, 12, '?', 'D', false, empty);
        temp[11][11] = new Square(11, 11, '?', 'D', false, empty);
        temp[10][10] = new Square(10, 10, '?', 'D', false, empty);

        /**
         * Creating double letter spaces
         */
        temp[0][3] = new Square(0, 3, '?', 'd', false, empty);
        temp[3][0] = new Square(3, 0, '?', 'd', false, empty);
        temp[0][11] = new Square(0, 11, '?', 'd', false, empty);
        temp[3][14] = new Square(3, 14, '?', 'd', false, empty);
        temp[2][6] = new Square(2, 6, '?', 'd', false, empty);
        temp[2][8] = new Square(2, 8, '?', 'd', false, empty);
        temp[3][7] = new Square(3, 7, '?', 'd', false, empty);
        temp[11][0] = new Square(11, 0, '?', 'd', false, empty);
        temp[14][3] = new Square(14, 3, '?', 'd', false, empty);
        temp[14][11] = new Square(14, 11, '?', 'd', false, empty);
        temp[11][14] = new Square(11, 14, '?', 'd', false, empty);
        temp[11][7] = new Square(11, 7, '?', 'd', false, empty);
        temp[12][6] = new Square(12, 6, '?', 'd', false, empty);
        temp[12][8] = new Square(12, 8, '?', 'd', false, empty);
        temp[6][2] = new Square(6, 2, '?', 'd', false, empty);
        temp[8][2] = new Square(8, 2, '?', 'd', false, empty);
        temp[7][3] = new Square(7, 3, '?', 'd', false, empty);
        temp[6][6] = new Square(6, 6, '?', 'd', false, empty);
        temp[6][8] = new Square(6, 8, '?', 'd', false, empty);
        temp[6][12] = new Square(6, 12, '?', 'd', false, empty);
        temp[7][11] = new Square(7, 11, '?', 'd', false, empty);
        temp[8][6] = new Square(8, 6, '?', 'd', false, empty);
        temp[8][8] = new Square(8, 8, '?', 'd', false, empty);
        temp[8][12] = new Square(8, 12, '?', 'd', false, empty);

        /**
         * Creating triple letter spaces
         */
        temp[1][5] = new Square(1, 5, '?', 't', false, empty);
        temp[1][9] = new Square(1, 9, '?', 't', false, empty);
        temp[5][1] = new Square(5, 1, '?', 't', false, empty);
        temp[5][5] = new Square(5, 5, '?', 't', false, empty);
        temp[5][9] = new Square(5, 9, '?', 't', false, empty);
        temp[5][13] = new Square(5, 13, '?', 't', false, empty);
        temp[9][1] = new Square(9, 1, '?', 't', false, empty);
        temp[9][5] = new Square(9, 5, '?', 't', false, empty);
        temp[9][9] = new Square(9, 9, '?', 't', false, empty);
        temp[9][13] = new Square(9, 13, '?', 't', false, empty);
        temp[13][5] = new Square(13, 5, '?', 't', false, empty);
        temp[13][9] = new Square(13, 9, '?', 't', false, empty);

        /**
         * Fill the rest with blanks
         */
        for (int i = 0; i < numBoard; i++) {
            for (int j = 0; j < numBoard; j++) {
                if (temp[i][j] == null) {
                    temp[i][j] = new Square(i, j, '?', '.', false, empty);
                }
            }
        }

        return temp;
    }

    /**
     * Prints a console rep. of the board
     */
    public void printBoard() {

        for (int i = 0; i < NUM_ROWS; i++) {
            for (int j = 0; j < NUM_ROWS; j++) {
                if (this.board[i][j].tile.letter != '?') {
                    System.out.print(this.board[i][j].letter + " ");
                } else {
                    System.out.print(this.board[i][j].special + " ");
                }
            }
            System.out.println();
        }
    }

    /**
     * TODO
     * Determines the multiplier for a spot on the board, calculates score
     * Replaces the multipliers with one after they have been placed, they don't count
     * after the current turn
     *
     * @param tiles list of all the modified tiles and letters for the play
     * @return calculated score
     */
    public int getSquareMultiplier(ArrayList<Coordinate> tiles) {
        int val = 0;
        int bonus = 0;
        int wordBonus = 1;
        //
        for (int i = 0; i < tiles.size(); i++) {
            Tile temp = tiles.get(i).tile;
            if (temp.letter != '!') {
                Coordinate c = tiles.get(i);
                if (board[c.row][c.col].special == 'd') {
                    System.out.println("bonus is double letter for " + board[c.row][c.col].letter);
                    System.out.println("word bonus is " + board[c.row][c.col].special);
                    bonus = 2;
                } else if (board[c.row][c.col].special == 't') {
                    System.out.println("bonus is triple letter for " + board[c.row][c.col].letter);
                    System.out.println("word bonus is " + board[c.row][c.col].special);
                    bonus = 3;
                } else {
                    System.out.println("bonus is none for " + board[c.row][c.col].letter);
                    System.out.println("word bonus is " + board[c.row][c.col].special);
                    bonus = 1;
                }

                System.out.println("Meant to be calculating word bonueses");
                System.out.println("word bonus is " + board[c.row][c.col].special);
                //calculate word bonuses
                if (board[c.row][c.col].special == 'T') {
                    System.out.println("word bonus is " + board[c.row][c.col].special + " for " + board[c.row][c.col].letter);

                    wordBonus *= 3;
                } else if (board[c.row][c.col].special == 'D' || board[c.row][c.col].special == 'X') {
                    System.out.println("word bonus is " + board[c.row][c.col].special + " for " + board[c.row][c.col].letter);
                    wordBonus *= 2;
                }
                val += (bonus * temp.value);
                board[c.row][c.col].special = '.';
            } else {
                //add the wordBonus, if any
                val = val * wordBonus;
            }

        }
        return val;
    }

    /**
     * Place tile on the board, given it is valid
     *
     * @param row       index
     * @param col       index
     * @param t         tile wanting to be placed
     * @param first     is it the first play
     * @param firstTile coordinate of the second tile placed, if any
     */
    public boolean placeMove(int row, int col, Tile t, boolean first, Coordinate firstTile) {
        if (validMove(row, col) && isFirst(row, col, first) && isTouching(row, col, first)
                && isSameRowCol(firstTile, row, col, first)) {
            System.out.println("Valid Move");
            board[row][col].tile = t;
            board[row][col].letter = t.letter;
            board[row][col].filled = true;
            return true;
        } else {
            System.out.println("Invalid move!");
            return false;
        }
    }

    /**
     * Checks if being placed in start square, if first play
     *
     * @param row   index
     * @param col   index
     * @param first is it first play
     * @return false if not placing in start square, true otherwise
     */
    public boolean isFirst(int row, int col, boolean first) {
        if (first) {
            if (row == 7 && col == 7 || board[7][7].isFilled()) {
                return true;
            }
            return false;
        } else {
            return true;
        }
    }

    /**
     * TODO
     * Makes sure the play is in the same row, or same col, but not in both.
     * Full play has to be either all across, or all down
     *
     * @param t1    coordinate representation of the second tile placed
     * @param first is firstplay
     * @return false if not in same row as the start, true otherwise
     */
    public boolean isSameRowCol(Coordinate t1, int row, int col, boolean first) {

        if (t1 == null) {
            return true;
        }

        if (row == t1.row) {
            return true;
        } else if (col == t1.col) {
            return true;
        }

        return false;
    }

    /**
     * Checks if the tile is touching another tile, and therefore
     * is a valid place to put a tile on the board
     *
     * @param row   index of place wanting to put a tile
     * @param col   index of place wanting to put a tile
     * @param first is it the first tile being placed?
     * @return true if a tile can legally be played here, false otherwise
     */
    public boolean isTouching(int row, int col, boolean first) {

        int left = col - 1;
        int right = col + 1;
        int up = row - 1;
        int down = row + 1;

        if (first) {
            return true;
        } else {
            if (left >= 0) {
                if (board[row][left].isFilled()) {
                    return true;
                }
            }

            if (right < NUM_ROWS) {
                if (board[row][right].isFilled()) {
                    return true;
                }
            }

            if (up >= 0) {
                if (board[up][col].isFilled()) {
                    return true;
                }
            }

            if (down < NUM_ROWS) {
                if (board[down][col].isFilled()) {
                    return true;
                }
            }
        }

        return false;

    }

    /**
     * Undos the moves made on the board by the player, because they were not valid
     * This works, for now
     *
     * @param played all tiles played for that turn
     */
    public void undo(ArrayList<Coordinate> played) {
        System.out.println("In undo on board");
        Tile empty = new Tile('?');
        for (int i = 0; i < played.size(); i++) {
            board[played.get(i).row][played.get(i).col].filled = false;
            board[played.get(i).row][played.get(i).col].tile = empty;
            board[played.get(i).row][played.get(i).col].letter = empty.letter;
        }
    }

    /**
     * Checks if the square being played on is valid or not
     * I.E: If it is filled or no, other methods check valid placement,
     * and valid word moves
     *
     * @param row index
     * @param col index
     * @return false if filled, true otherwise
     */
    public boolean validMove(int row, int col) {
        if (board[row][col].filled == true) {
            return false;
        } else {
            return true;
        }
    }

    /**
     * Checks if the word attempting to be played is an
     * actual word
     *
     * @param str  word being played
     * @param dict the dictionary
     * @return true if a word, false otherwise
     */
    public boolean validWord(String str, Trie dict) {
        if (dict.search(str)) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * TODO
     * DONT KNOW IF THIS IS NEEDED
     * Checks all crossed words make actual words
     *
     * @param dict    dictionary we are checking against
     * @param crosses all crossed, comes from allCrossed() method
     * @return true if all crosses are words, false otherwise
     */
    public boolean validCrosses(Trie dict, ArrayList<ArrayList<Tile>> crosses) {
        return false;
    }

    /**
     * finds all words on the board, across and down, puts them in a list
     * and returns that
     *
     * @return list of strings of all words on the board
     */
    public ArrayList<String> allWords() {
        String temp = "";
        ArrayList<String> all = new ArrayList<>();
        //across words
        for (int i = 0; i < NUM_ROWS; i++) {
            for (int j = 0; j < NUM_ROWS; j++) {
                if (board[i][j].filled) {
                    char let = board[i][j].tile.letter;
                    Character.toLowerCase(let);
                    temp += let;
                } else {
                    if (temp.length() >= 2) {
                        all.add(temp);
                    }
                    temp = "";
                }
            }
        }


        temp = "";

        //down words
        for (int i = 0; i < NUM_ROWS; i++) {
            for (int j = 0; j < NUM_ROWS; j++) {
                if (board[j][i].filled) {
                    char let = board[j][i].tile.letter;
                    Character.toLowerCase(let);
                    temp += let;
                } else {
                    if (temp.length() >= 2) {
                        all.add(temp);
                    }
                    temp = "";
                }
            }
        }

        return all;
    }

    /**
     * TODO
     * Finds the anchors of the tiles that the player placed, and create a list of the words made, or modified
     * Tests the tiles against a list of strings, to make sure no duplicates
     * are added
     *
     * @param played the tiles played in the current move
     * @return list of all words created and modified
     */
    public ArrayList<Coordinate> wordsMade(ArrayList<Coordinate> played, Trie dictTrie) {

        ArrayList<Coordinate> modified = new ArrayList<>();
        ArrayList<Coordinate> start = new ArrayList<>();
        String check = "";

        for (int i = 0; i < played.size(); i++) {
            Coordinate temp = played.get(i);
            int row = temp.row;
            int col = temp.col;
            Tile t = temp.tile;
            int spacesBack = col;
            int spacesUp = row;
            boolean dup = false;

            boolean isSingle = true;

            //check if something to left
            if (spacesBack - 1 >= 0) {
                if (board[row][spacesBack - 1].isFilled()) {
                    isSingle = false;
                }
            }
            //check if something to right
            if (spacesBack + 1 < NUM_ROWS) {
                if (board[row][spacesBack + 1].isFilled()) {
                    isSingle = false;
                }
            }

            //go to the leftmost part of the word
            while (board[row][spacesBack].isFilled()) {
                if (spacesBack - 1 >= 0) {
                    spacesBack -= 1;

                }
            }
            spacesBack += 1;

            //check duplicates
            for (int j = 0; j < start.size(); j++) {
                if (start.get(j).col == spacesBack && start.get(j).row == row) {
                    j = start.size();
                    dup = true;
                }
            }

            //add things to start
            if (dup == false && isSingle == false) {
                start.add(new Coordinate(row, spacesBack, new Tile(board[row][spacesBack].letter)));
            }

            dup = false;

            isSingle = true;

            //check if something on top
            if (spacesUp - 1 >= 0) {
                if (board[spacesUp - 1][col].isFilled()) {
                    isSingle = false;
                }
            }
            //check if something below
            if (spacesUp + 1 < NUM_ROWS) {
                if (board[spacesUp + 1][col].isFilled()) {
                    isSingle = false;
                }
            }


            //find the topmost
            while (board[spacesUp][col].isFilled() && isSingle == false) {
                if (spacesUp - 1 >= 0) {
                    spacesUp -= 1;
                }

            }
            if (isSingle == false) {
                spacesUp += 1;
            }

            //check duplicates
            for (int j = 0; j < start.size(); j++) {
                if (start.get(j).row == spacesUp && start.get(j).col == col) {
                    j = start.size();
                    dup = true;
                }
            }

            //add things to start
            if (dup == false && isSingle == false) {
                start.add(new Coordinate(spacesUp, col, new Tile(board[spacesUp][col].letter)));
            }

        }

        System.out.println("All start letters are ");
        for (int i = 0; i < start.size(); i++) {
            System.out.println(start.get(i).tile.letter);
        }


        //checking down
        for (int k = 0; k < start.size(); k++) {
            for (int j = start.get(k).row; j < NUM_ROWS; j++) {
                if (board[j][start.get(k).col].isFilled()) {
                    if (j == start.get(k).row && j + 1 < NUM_ROWS) {
                        if (board[j + 1][start.get(k).col].isFilled()) {
                            modified.add(new Coordinate(j, start.get(k).col, board[j][start.get(k).col].tile));
                        }
                    } else {
                        if (board[j][start.get(k).col].isFilled()) {
                            modified.add(new Coordinate(j, start.get(k).col, board[j][start.get(k).col].tile));
                        }
                    }

                } else {
                    j = NUM_ROWS;
                    //add a bogey tile to seperate words, with a letter !
                    modified.add(new Coordinate(0, 0, new Tile('!')));
                }
            }
        }


        //checking across
        for (int k = 0; k < start.size(); k++) {
            for (int j = start.get(k).col; j < NUM_ROWS; j++) {
                if (board[start.get(k).row][j].isFilled()) {
                    if (j == start.get(k).col && j + 1 < NUM_ROWS) {
                        System.out.println("Chcking across, not on edge of board");
                        if (board[start.get(k).row][j + 1].isFilled()) {
                            modified.add(new Coordinate(start.get(k).row, j, board[start.get(k).row][j].tile));
                        }
                    } else {
                        if (board[start.get(k).row][j].isFilled()) {
                            modified.add(new Coordinate(start.get(k).row, j, board[start.get(k).row][j].tile));
                        }
                    }
                } else {
                    j = NUM_ROWS;
                    //add a bogey tile to seperate words, with a letter !
                    modified.add(new Coordinate(0, 0, new Tile('!')));
                }
            }
        }

        System.out.println("All words are ");
        for (int i = 0; i < modified.size(); i++) {
            System.out.println(modified.get(i).tile.letter);
        }

        int length = 0;
        ArrayList<Coordinate> modified2 = new ArrayList<>();
        ArrayList<Coordinate> modifiedALL = new ArrayList<>();
        //remove nonwords
        for (int i = 0; i < modified.size(); i++) {
            if (modified.get(i).tile.letter != '!') {
                check += modified.get(i).tile.letter;
                modified2.add(modified.get(i));
                length++;
            } else {
                if (dictTrie.search(check) && alreadyPlacedWords.contains(check) == false) {
                    for (int j = 0; j < modified2.size(); j++) {
                        modifiedALL.add(modified2.get(j));
                        alreadyPlacedWords.add(check);
                    }
                    modifiedALL.add(new Coordinate(0, 0, new Tile('!')));

                }
                modified2.clear();
            }

        }


        System.out.println("All words after checking bogus are ");
        for (int i = 0; i < modifiedALL.size(); i++) {
            System.out.println(modifiedALL.get(i).tile.letter);
        }


        return modifiedALL;
    }


    /**
     * Check if everything placed on the board is valid
     * calls allWords method, and validWord method
     *
     * @param dict  dictionary for checking words
     * @param first is it the first play or not
     * @return
     */
    public boolean validOverall(Trie dict, boolean first) {
        ArrayList<String> all = allWords();
        for (int i = 0; i < all.size(); i++) {
            if (dict.search(all.get(i)) != true) {
                return false;
            }
        }
        if (first && board[7][7].filled) {
            return true;
        } else if (first && board[7][7].filled == false) {
            return false;
        } else {
            return true;
        }
    }

    /**
     * Returns the square at some index
     *
     * @param row
     * @param col
     * @return that square
     */
    public Square getSquare(int row, int col) {
        return this.board[row][col];
    }
}
