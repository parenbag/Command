using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandTask
{
    public class ClickInputManager : MonoBehaviour
    {
        [SerializeField] private ClickManager commandExecutor;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject cubePrefab;

        private PlayerTeleport playerTeleportCommand;
        private CircleSP cubeSpawnCommand;

        private void Awake()
        {
            playerTeleportCommand = new(playerTransform);
            cubeSpawnCommand = new(cubePrefab);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hitInfo = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hitInfo.collider != null)
                {
                    commandExecutor.Execute(playerTeleportCommand, mousePos);
                }
                else
                {
                    commandExecutor.Execute(playerTeleportCommand, mousePos);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hitInfo = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hitInfo.collider != null)
                {
                    commandExecutor.Execute(cubeSpawnCommand, hitInfo.point);
                }
                else
                {
                    commandExecutor.Execute(cubeSpawnCommand, mousePos);
                }
            }

            if (Input.GetMouseButtonDown(2))
            {
                commandExecutor.Undo();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hitInfo = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hitInfo.collider != null)
                {
                    commandExecutor.Schedule(cubeSpawnCommand, hitInfo.point);
                }
                else
                {
                    commandExecutor.Schedule(cubeSpawnCommand, mousePos);
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                commandExecutor.ExecuteSchedule();
            }
        }
    }
}
