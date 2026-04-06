using UnityEngine;

public class MoveCommand : ICommand 
{
    private PlayerMover playerMover;
    private Vector3 movement;
    public MoveCommand(PlayerMover playerMover, Vector3 movement)
    {
        this.playerMover = playerMover;
        this.movement = movement;
    }
    private void RunPlayerCommand(PlayerMover playerMover, Vector3 movement)
    {
        if (playerMover == null)
        {
            return;
        }
        if (playerMover.IsValidMove(movement))
        {
            ICommand command = new MoveCommand(playerMover, movement);
            CommandInvoker.ExecuteCommand(command);
        }
    }
    public void Execute()
    {
        playerMover.Move(movement);
    }
    public void Undo()
    {
        playerMover.Move(-movement);
    }
}
