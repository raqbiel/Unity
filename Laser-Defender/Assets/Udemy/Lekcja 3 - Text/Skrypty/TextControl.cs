using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{

    public Text text;

    private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
        corridor_0 };
    private States myState;

    // Use this for initialization
    void Start()
    {

        myState = States.cell;

    }

    // Update is called once per frame
    void Update()
    {

        print(myState);
        if (myState == States.cell) { cell(); }
        else if (myState == States.sheets_0) { sheets_0(); }
        else if (myState == States.lock_0) { lock_0(); }
        else if (myState == States.mirror) { mirror(); }
        else if (myState == States.cell_mirror) { cell_mirror(); }
        else if (myState == States.lock_1) { lock_1(); }
        else if (myState == States.sheets_1) { sheets_1(); }
        else if (myState == States.corridor_0) { corridor_0(); }


    }


    #region State region Story 
    void cell()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
               "some dirty sheets on the bed, a mirror on the wall, and the door " +
               "is locked from the outside.\n\n" +
               "Press S to view Sheets, M to view Mirror and L to view Lock";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.M)) { myState = States.mirror; }
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_0; }
    }

    void sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
               "time somebody changed them. The pleasures of prison life " +
               "I guess!\n\n" +
               "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void sheets_1()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
               "time somebody changed them. The pleasures of prison life " +
               "I guess!\n\n" +
               "Press R to Return to roaming your mirror";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
    }
    void mirror()
    {
        text.text = "You look in the mirror and don't see anything wrong " +
               "only the ungle face, and nothing strange " +
               "Looks like its not the way to leave cell.\n\n" +
               "Press R to Return to roaming your cell, Press T to take the mirror";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
        else if (Input.GetKeyDown(KeyCode.T)) { myState = States.cell_mirror; }
    }
    void lock_0()
    {
        text.text = "Look like the door is locked " +
               "time to find out another way to leave this room " +
               "Let's try again!\n\n" +
               "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }

    void cell_mirror()
    {
        text.text = "You have your mirror in hand " +
               "time to find out another way to leave this room " +
               "Let's try again!\n\n" +
               "Press S to view Sheets, Press L to view Lock";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_1; }
    }
    void lock_1()
    {
        text.text = "Look like the door is locked " +
               "time to find out another way to leave this room " +
               "Let's try again!\n\n" +
               "Press R to Return to mirror, or click F to get from the cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.corridor_0; }
    }
    void corridor_0()
    {
        text.text = "Look like the door is open " +
               "You're Free!!\n\n" +
               "Press P to play again";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }
    #endregion
}
