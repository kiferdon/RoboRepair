using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Conveyors {
    public class ConveyorController : MonoBehaviour {
        public Transform spawnPoint;

        private Conveyor[] _conveyors;
        [FormerlySerializedAs("checkPoint")] [SerializeField] private TurnPoint turnPoint;
        
        private void Awake() {
            _conveyors = GetComponentsInChildren<Conveyor>();
            turnPoint.EventOnCheckPoint += AddRobbotToVertical;
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

        public void AddRobbotToVertical(Robot robot)
        {
            for (var i = 0; i < _conveyors.Length; i++) {
                var conveyor = _conveyors[i];
                if (conveyor.isVertical) {
                    var positionY = conveyor.transform.position.y;
                    var bottomY = positionY - conveyor.Offset / 2;
                    var topY = positionY + conveyor.Offset / 2;
                    if (turnPoint.transform.position.y <= topY && turnPoint.transform.position.x >= bottomY) {
                        //robot.transform.position = checkPoint.transform.position;
                        robot.transform.parent = conveyor.transform;
                    }
                }
            }
        }
    }
}