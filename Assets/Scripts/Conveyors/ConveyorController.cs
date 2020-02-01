using System;
using UnityEngine;

namespace Conveyors {
    public class ConveyorController : MonoBehaviour {
        public Transform spawnPoint;

        private Conveyor[] _conveyors;

        private void Awake() {
            _conveyors = GetComponentsInChildren<Conveyor>();
        }

        public void AddRobot(Robot robot) {
            for (var i = 0; i < _conveyors.Length; i++) {
                var conveyor = _conveyors[i];
                if (!conveyor.isVertical) {
                    var positionX = conveyor.transform.position.x;
                    var leftX = positionX - conveyor.Offset / 2;
                    var rightX = positionX + conveyor.Offset / 2;
                    if (spawnPoint.position.x <= rightX && spawnPoint.position.x >= leftX) {
                        robot.transform.position = spawnPoint.position;
                        robot.transform.parent = conveyor.transform;
                    }
                }
            }
        }
    }
}