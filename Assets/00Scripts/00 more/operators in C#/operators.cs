using UnityEngine;

public class operators : MonoBehaviour
{
    // operator "is" Check if an object is of a specific type.
    static object obj = "hello"!;
    bool isString = obj is string; // return true

    // operator "as" Converts object type, returns null if unsuccessful.
    string str = obj as string;

    //Returns the value on the right if the value on the left is null.
    static string str1 = null!;
    string result = str1 ?? "Default value";
        private void Start(){
        // Assign the value on the right side to the variable if the variable is currently null.
        str1 ??= "default value";
        // ternary operators
        int a = 10, b = 20;
        int min = a < b ? a : b; // if a<b return a, else return b
    }
}
