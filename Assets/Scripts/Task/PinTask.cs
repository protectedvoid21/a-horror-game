using UnityEngine;

public class PinTask : GameTask {
    [SerializeField] private Transform[] pinBoxSpawnPositions;
    [SerializeField] private InteractionOpen pinBox;

    private bool isCompleted;

    public override void ActivateTask() {
        int rngIndex = Random.Range(0, pinBoxSpawnPositions.Length);
        InteractionOpen interactionOpen = Instantiate(pinBox, pinBoxSpawnPositions[rngIndex].position, pinBox.transform.rotation);
        interactionOpen.InsertUIObject(FindObjectOfType<PinCodeUI>());
    }

    public override bool IsCompleted() {
        return isCompleted;
    }

    public override void AddEndedTask() {
        isCompleted = true;
    }
}