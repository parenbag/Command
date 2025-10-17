using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CommandTask
{
    public class CircleSP : Click
    {
        private readonly GameObject cubePrefab;

        public CircleSP(GameObject cubePrefab)
        {
            this.cubePrefab = cubePrefab;
        }

        public Action Execute(Vector3 clickPosition)
        {
            Vector3 spawnPosition = new Vector3(clickPosition.x, clickPosition.y, 0);

            UndoData undoData = new(Object.Instantiate(cubePrefab, spawnPosition, Quaternion.identity));
            return () => Undo(undoData);
        }

        private void Undo(UndoData undoData)
        {
            Object.Destroy(undoData.cubeGameObject);
        }

        private struct UndoData
        {
            public GameObject cubeGameObject;

            public UndoData(GameObject cubeGameObject)
            {
                this.cubeGameObject = cubeGameObject;
            }
        }
    }
}
