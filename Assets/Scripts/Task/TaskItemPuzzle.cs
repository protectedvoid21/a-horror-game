using UnityEngine;

public class TaskItemPuzzle : TaskItem {
    [SerializeField] private GameObject puzzleObject;
    
    public override void Interact() {
        puzzleObject.SetActive(true);
    }

    private void MarkCompleted() {
        onTaskEnded?.Invoke();
    }
}

/*
Podchodzisz do komputera
Klikasz E
odpala się interakcja z IInteractable

co teraz? 
TaskItemPuzzle włącza puzzleObject
ComputerTask siedzący na puzzleObject definiuje działanie taska
jak task się skończy to ComputerTask wywołuje metodę na TaskItemPuzzle MarkCompleted (albo wywołuje delegate)
*/
