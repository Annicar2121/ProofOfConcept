import java.util.HashMap;

/**
 * Annica Roos
 * Node class for the Trie tree
 * Structure taken from https://www.programcreek.com/2014/05/leetcode-implement-trie-prefix-tree-java/
 */
public class TrieNode {
    char c;
    HashMap<Character, TrieNode> children= new HashMap<>();
    boolean isLeaf;

    public TrieNode(){}

    public TrieNode(char c){
        this.c = c;
    }


}
