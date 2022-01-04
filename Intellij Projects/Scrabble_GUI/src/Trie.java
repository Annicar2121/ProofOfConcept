import java.util.HashMap;
import java.util.Map;

/**
 * Annica Roos
 * Node class for the Trie tree
 * Structure taken from https://www.programcreek.com/2014/05/leetcode-implement-trie-prefix-tree-java/
 */

public class Trie {

    private TrieNode root;

    public Trie() {
        this.root = new TrieNode();
    }

    // Inserts a word into the trie.
    //will use this look up prefixes and check words for the computer to play from their hand.
    public void insert(String word) {
        HashMap<Character, TrieNode> children = root.children;

        for(int i=0; i<word.length(); i++){
            char c = word.charAt(i);


            //check to see if a previous leaf exists
            TrieNode t;
            if(children.containsKey(c)){
                t = children.get(c);
            }else{
                //insert the new leaf
                t = new TrieNode(c);
                children.put(c, t);
            }

            children = t.children;

            //set leaf node
            if(i==word.length()-1)
                t.isLeaf = true;
        }
    }

    /** Returns if there the word in the trie
     * @param word the word we are searching for
     * @return returns true if the word exists, false if not
     */
    public boolean search(String word) {
        TrieNode t = searchNode(word);

        if(t != null && t.isLeaf) {
            return true;
        }else{
            return false;
        }

    }

    /** Returns if there is any word in the trie
     * that starts with the given prefix.
     * @param prefix the prefix we are searching for
     * @return returns true if the prfix exists, false if not
     */
    public boolean startsWith(String prefix) {

        if(searchNode(prefix) == null) {
            return false;
        }else {
            return true;
        }
    }

    /**
     * Find the node to which the word is in
     * @param str word we are looking for
     * @return null if word is not in trie, return the node the word is in
     */
    public TrieNode searchNode(String str){
        Map<Character, TrieNode> children = root.children;
        TrieNode t = null;
        for(int i=0; i<str.length(); i++){
            char c = str.charAt(i);
            if(children.containsKey(c)){
                t = children.get(c);
                children = t.children;
            }else{
                return null;
            }
        }

        return t;
    }

}
