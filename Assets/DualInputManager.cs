using UnityEngine;
using StarterAssets;

public class DualInputManager : MonoBehaviour
{
    [Header("Player References")]
    public StarterAssetsInputs player1Inputs;
    public StarterAssetsInputs player2Inputs;

    void Update()
    {
        if (player1Inputs != null) HandlePlayer1();
        if (player2Inputs != null) HandlePlayer2();
    }
    //here are the controls for the player one 
    void HandlePlayer1()
    {
        // Movement: Arrow Keys
        float moveX = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
        float moveY = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);
        player1Inputs.MoveInput(new Vector2(moveX, moveY));

        // Actions
        player1Inputs.JumpInput(Input.GetKey(KeyCode.RightControl));
        player1Inputs.SprintInput(Input.GetKey(KeyCode.RightShift));

        // ADD THIS FOR CROUCH (Player 1)
        player1Inputs.CrouchInput(Input.GetKey(KeyCode.Keypad0));
    }
    // here are the controls for the player two
    //understood?
    void HandlePlayer2()
    {
        // Movement: WASD
        float moveX = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float moveY = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        player2Inputs.MoveInput(new Vector2(moveX, moveY));

        // Actions
        player2Inputs.JumpInput(Input.GetKey(KeyCode.Space));
        player2Inputs.SprintInput(Input.GetKey(KeyCode.LeftShift));

        // ADD THIS FOR CROUCH (Player 2)
        player2Inputs.CrouchInput(Input.GetKey(KeyCode.C));
    }
}
