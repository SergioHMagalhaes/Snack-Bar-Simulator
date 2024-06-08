using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 5f;
    private Camera playerCamera;
    private NPCDialogue currentNPC;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        CheckForNPC();

        // Verifique se o botão X do controle (geralmente mapeado como "joystick button 2") foi pressionado
        if (currentNPC != null && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!currentNPC.dialogueUI.activeInHierarchy)
            {
                currentNPC.StartDialogue();
            }
            else
            {
                currentNPC.ShowNextLine();
            }
        }
    }

    private void CheckForNPC()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
        {
            NPCDialogue npcDialogue = hit.collider.GetComponent<NPCDialogue>();

            if (npcDialogue != null)
            {
                currentNPC = npcDialogue;
                return;
            }
        }

        currentNPC = null;
    }
}
