using Unity.Netcode;

public class PlayerManager : NetworkBehaviour {
    private PlayerTaskManager playerTaskManager;
    private bool isAlive = true;
    private bool isEnemy;
}