using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{
    GameInput _input;
    public Player3 player;
    // Start is called before the first frame update
    void Start()
    {
        InitializeInput();
    }

    void InitializeInput()
    {
        _input = new GameInput();
        _input.Player.Enable();
        _input.Player.Fire.performed += Fire_performed;
    }

    private void Fire_performed(InputAction.CallbackContext context)
    {
        player.Fire();
    }

    // Update is called once per frame
    void Update()
    {
        var move = _input.Player.Movement.ReadValue<Vector2>();
        player.Move(move);
    }
}
