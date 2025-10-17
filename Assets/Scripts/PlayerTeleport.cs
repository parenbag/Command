using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandTask
{
    public class PlayerTeleport : Click
    {
        private readonly Transform playerTransform;

        public PlayerTeleport(Transform playerTransform)
        {
            this.playerTransform = playerTransform;
        }

        public Action Execute(Vector3 clickPosition)
        {
            Vector3 targetPosition = new Vector3(clickPosition.x, clickPosition.y, playerTransform.position.z);

            UndoData undoData = new(playerTransform.position);
            playerTransform.position = targetPosition;
            return () => Undo(undoData);
        }

        private void Undo(UndoData undoData)
        {
            playerTransform.position = undoData.position;
        }

        private struct UndoData
        {
            public Vector3 position;

            public UndoData(Vector3 position)
            {
                this.position = position;
            }
        }
    }
}
